using AutoMapper;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence.SchemaChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
//using ICare.Constant;

namespace Emr.Infrastructure.Hepper.Lib
{
    /// <summary>
    /// Nguyễn Phi Trường Creator 02/10/2019
    /// </summary>
    public static class Library
    {

        //ConverImgToByte
        public static byte[] ConvertImgToByte(string _strPath)
        {
            if (!string.IsNullOrEmpty(_strPath))
            {
                if (!Directory.Exists(_strPath))
                {
                    FileStream fs;
                    fs = new FileStream(_strPath, FileMode.Open, FileAccess.Read);
                    byte[] picbyte = new byte[fs.Length];
                    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();
                    return picbyte;
                }
            }
            return null;
        }

        public static string GetFullPathOnServer(string _strFileName, string _strName)
        {
            MoveFileModel dom = new MoveFileModel()
            {
                imgname = _strFileName,
                folder = _strName
            };
            return GetFullPathOnServer(dom);
        }
        public static string GetFullPathOnServer(MoveFileModel dom)
        {
            string strRootFolder = GetApplicationSetting(Constant.ResourceFolder);
            string UploadFolder = PathCombine(strRootFolder.ToString(), Constant.HospCode.ToString(), dom.folder.ToString());
            string DestinationFolder = PathCombine(UploadFolder);
            if (!string.IsNullOrEmpty(DestinationFolder))
            {
                if (!Directory.Exists(DestinationFolder)) { Directory.CreateDirectory(DestinationFolder); }
                return PathCombine(DestinationFolder, dom.imgname);
            }
            return null;
        }
        public static string GetApplicationSetting(string key, string session = null)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key]?.Trim();
        }
        public static string PathCombine(params string[] paths)
        {
            if (paths.Length == 0)
                return string.Empty;
            else if (paths.Length == 1)
                return paths[0];
            else
            {
                string escapePath = Uri.EscapeUriString(paths[0]);
                if (Uri.IsWellFormedUriString(escapePath, UriKind.Absolute))
                {
                    for (int i = 0; i < paths.Length; i++)
                    {
                        paths[i] = paths[i].TrimStart('/').TrimEnd('/');
                    }

                    return string.Join("/", paths);
                }
                else
                {
                    return Path.Combine(paths);
                }
            }
        }
        public static string ImageToBase64(System.Drawing.Image _ima)
        {
            string base64String = "";
            using (var memStream = new MemoryStream())
            {
                _ima.Save(memStream, _ima.RawFormat);
                byte[] imageBytes = memStream.ToArray();

                base64String = Convert.ToBase64String(imageBytes);
            }
            return base64String;
        }
        public static string ImageToBase64(string _strPath, string _strFileName, string _strName)
        {
            try
            {
                MoveFileModel dom = new MoveFileModel()
                {
                    filepath = _strPath,
                    imgname = _strFileName,
                    folder = _strName
                };
                return ImageToBase64(Image.FromFile(GetFullPathOnServer(dom)));
                //  return ImageToBase64(Image.FromFile(GetFullPathOnServer(string filepath, string imgname, string folder)));
            }
            catch { return null; }

        }
        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        public static MoveFileModel MoveFile(MoveFileModel dom)
        {
            string DesFilePath = GetFullPathOnServer(dom);
            if (dom.image != "")
            {
                Image img = Base64ToImage(dom.image);
                img.Save(DesFilePath, ImageFormat.Png);
            }
            else if (!string.IsNullOrEmpty(DesFilePath))
            {
                try { DeleteFile(DesFilePath); }
                catch { }

                try { CopyFile(dom.filepath, DesFilePath); }
                catch { return null; }
            }
            else { return null; }

            return dom;
        }
        //_strImgFilePathServer, _strImgFileName, _strImgNameResultFoder, _strImgBase64
        public static MoveFileModel SaveFile(string _strImgFilePathServer, string _strImgFileName, string _strImgNameResultFoder, string _strImgBase64)
        {
            MoveFileModel dom = new MoveFileModel()
            {
                filepath = _strImgFilePathServer,
                folder = _strImgNameResultFoder,
                imgname = _strImgFileName,
                image = _strImgBase64
            };
            return MoveFile(dom);
        }
        public class MoveFileModel
        {
            public string filepath { get; set; }
            public string folder { get; set; }
            public string imgname { get; set; }
            public string image { get; set; }
        }
        public static void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
        public static bool IsFolderExist(string path)
        {
            return Directory.Exists(path);
        }
        public static bool IsFileExist(string path)
        {
            return File.Exists(path);
        }
        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void CopyFile(string srcPath, string destPath, bool bOverride = false)
        {
            string escapeSrcPath = Uri.EscapeUriString(srcPath);
            string escapeDestPath = Uri.EscapeUriString(destPath);

            if (Uri.IsWellFormedUriString(escapeSrcPath, UriKind.Absolute))
            {
                // Source file is put on web

                if (Uri.IsWellFormedUriString(escapeDestPath, UriKind.Absolute))
                {
                    // Dest file is on web
                    throw new NotSupportedException();
                }
                else
                {
                    #region Download from Web url to local file
                    HttpWebRequest aRequest = (HttpWebRequest)WebRequest.Create(escapeSrcPath);
                    HttpWebResponse aResponse = null;

                    try
                    {
                        aRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                        aResponse = (HttpWebResponse)aRequest.GetResponse();

                        if (bOverride)
                        {
                            File.Delete(destPath);
                        }

                        using (Stream writer = CreateOutputFileStream(destPath))
                        {
                            aResponse.GetResponseStream().CopyTo(writer);
                            NetDataCounter.Download.Add("FILE", writer.Position);
                        }
                    }
                    catch (WebException)
                    {
                        throw new FileNotFoundException(string.Format("'{0}' not found.", escapeSrcPath), escapeSrcPath);
                        //img = null;
                    }
                    finally
                    {
                        if (aResponse != null)
                            aResponse.Dispose();
                    }
                    #endregion
                }
            }
            else
            {
                // Source file is on not on web
                if (Uri.IsWellFormedUriString(escapeDestPath, UriKind.Absolute))
                {
                    // Dest file in on web
                    throw new NotSupportedException();
                }
                else
                {
                    #region Copy Local to Local
                    try
                    {
                        File.Copy(srcPath, destPath, bOverride);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                        File.Copy(srcPath, destPath, bOverride);
                    }
                    #endregion
                }
            }
        }
        public static Stream CreateOutputFileStream(string strPath)
        {
            Stream s = null;
            try
            {
                s = new FileStream(strPath, FileMode.Create, FileAccess.Write);
            }

            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
                s = new FileStream(strPath, FileMode.Create, FileAccess.Write);
            }

            return s;
        }
        public static void MoveFile(string srcPath, string destPath)
        {
            CopyFile(srcPath, destPath);
            DeleteFile(srcPath);
        }
        public class NetDataCounter
        {
            public static DataCounter Upload = new DataCounter();
            public static DataCounter Download = new DataCounter();
        }
        public class DataCounter
        {
            internal class CountEntry
            {
                public double Size { get; set; }
                public long Calls { get; set; }
            }

            private Dictionary<string, CountEntry> _counters = new Dictionary<string, CountEntry>();
            public DataCounter()
            {
            }
            public double Total
            {
                get { return _Total; }
            }
            private double _Total;
            public void ResetCounters()
            {
                _counters.Clear();
                _Total = 0;
            }
            public void Add(string part, double measure)
            {
                CountEntry entry;

                if (!_counters.TryGetValue(part, out entry))
                {
                    entry = new CountEntry();
                    entry.Calls = 0;
                    entry.Size = 0;
                    _counters[part] = entry;
                }

                entry.Size += measure;
                entry.Calls += 1;
                _Total += measure;
            }
            public void DumpCounters(Action<string, double, long, object> writer, object customData)
            {
                foreach (var p in _counters)
                {
                    writer.Invoke(p.Key, p.Value.Size, p.Value.Calls, customData);
                }
            }
        }

        public static int CalculateOffsetIndex(int i_Offset, int i_Limit)
        {
            try
            {
                return i_Offset > 0 ? i_Offset * i_Limit : i_Offset;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<T> CopyListObject<T>(List<T> source)
        {
            MapperConfiguration configCopy;
            IMapper iMapperCopy;

            configCopy = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            iMapperCopy = configCopy.CreateMapper();
            return iMapperCopy.Map<List<T>, List<T>>(source);
        }

        public static T CopyObject<T>(this T source)
        {
            MapperConfiguration configCopy;
            IMapper iMapperCopy;

            configCopy = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            iMapperCopy = configCopy.CreateMapper();
            return iMapperCopy.Map<T, T>(source);
        }

        public static List<SchemasMMYYModel> GetSchemaNamesByFromToDate(DateTime i_DateStart, DateTime i_DateEnd)
        {
            List<SchemasMMYYModel> lstResult = new List<SchemasMMYYModel>();
            //i_DateStart = DateTime.Parse("2023-10-01");

            int yearStart = i_DateStart.Year;
            int yearEnd = i_DateEnd.Year;
            int monthStart = i_DateStart.Month;
            int monthEnd = i_DateEnd.Month;

            if (i_DateEnd.Year == i_DateStart.Year)
            {
                for (int i = 0; i <= monthEnd - monthStart; i++)
                {
                    lstResult.Add(new SchemasMMYYModel
                    {
                        mmyy = (i_DateEnd.AddMonths(-i)).ToString("MMyy"),
                        mmyyName = "mmyy" + (i_DateEnd.AddMonths(-i)).ToString("MMyy")
                    });
                }
            }
            else if (i_DateEnd.Year > i_DateStart.Year)
            {
                int monthStart1 = i_DateStart.Month;
                for (int i = 0; i <= 12 - monthStart1; i++)
                {
                    lstResult.Add(new SchemasMMYYModel
                    {
                        mmyy = (i_DateStart.AddMonths(i)).ToString("MMyy"),
                        mmyyName = "mmyy" + (i_DateStart.AddMonths(i)).ToString("MMyy")
                    });
                }
                int monthEnd1 = i_DateEnd.Month;
                for (int i = 0; i < 12 - (12 - monthEnd1); i++)
                {
                    lstResult.Add(new SchemasMMYYModel
                    {
                        mmyy = (i_DateEnd.AddMonths(-i)).ToString("MMyy"),
                        mmyyName = "mmyy" + (i_DateEnd.AddMonths(-i)).ToString("MMyy")
                    });
                }
                lstResult = lstResult.OrderBy(o => o.mmyy).ToList();
            }
            return lstResult;
        }

        public static List<SchemasMMYYModel> GetSchemaNamesByPatient(PatientReadModel i_patientRead)
        {
            List<SchemasMMYYModel> lstResult = new List<SchemasMMYYModel>();
            var mmyys = i_patientRead.mmyy;
            string Schemaname = "mmyy";
            if (mmyys.Contains('|'))
            {
                var checkmmyys = i_patientRead.mmyy.Split('|').ToList();

                if (checkmmyys.Count > 0)
                {
                    foreach (var mmyy in checkmmyys)
                    {
                        lstResult.Add(new SchemasMMYYModel { mmyy = mmyy, mmyyName = Schemaname + mmyy });
                    }
                }
            }
            else
            {
                lstResult.Add(new SchemasMMYYModel { mmyy = mmyys.ToString(), mmyyName = Schemaname + mmyys.ToString() });
            }
            return lstResult;
        }

        public static SchemaChangeDbContext GetSchemaChangeDbContext(string? schema = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchemaChangeDbContext>()
                                 .UseSqlServer(ConnectionStrings.DefaultConnection)
                                 .ReplaceService<IModelCacheKeyFactory, DbSchemaAwareModelCacheKeyFactory>();

            return new SchemaChangeDbContext(optionsBuilder.Options, schema == null ? null : new DbContextSchema(schema));
        }

        public static DateTime GetFomatDate(string strDateValue)
        {
            DateTime dateValue = DateTime.Now;
            dateValue = DateTime.ParseExact(strDateValue, "yyyyMMdd", CultureInfo.InvariantCulture);
            dateValue = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day);

            return dateValue;
        }
    }
}
