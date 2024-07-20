using System;
using System.Numerics;

namespace Emr.Infrastructure.Hepper.Lib
{
    public static class LibHospCode
    {
        /// <summary>
        /// Ref hospcode - mã BN, bệnh viện quy định
        /// </summary>
        /// <returns></returns>
        //public static string GetHospcode(Decimal _dec = 0)
        //{
        //    if (_dec == 0)
        //        return Library.intgSiterf.ToString().PadLeft(3, '0') + DateTime.Now.ToString("yy") + Library.ByteArrayToHexString(Library.GetGuid64());
        //    else { return GetHospcode(new BigInteger(_dec).ToByteArray()); }
        //}

        ///// <summary>
        ///// Ref hospcode - mã BN, bệnh viện quy định
        ///// </summary>
        ///// <returns></returns>
        //public static string GetHospcode(byte[] _Patcode)
        //{
        //    return _Patcode[0].ToString().PadLeft(3, '0') + _Patcode[1].ToString() + Library.ByteArrayToHexString(Library.GetByte(_Patcode, 2));
        //}
        ///// <summary>
        /// Số Vào Viện
        /// </summary>
        /// <param name="_number"></param>
        /// <returns></returns>
        public static string GetHospNumber(int? _number, int year)
        {
            int totalNumber = 6;

            int current = DateTime.Now.Year;
            if (current > year)
                _number = 1;
            string result = "";
            for (int i = totalNumber; i > _number.ToString().Length; i--)
            {
                result += "0";
            }
            
            return result + _number.ToString();
        }

        public static string GetMedicalCode(string _hospnumber)
        {
            string proCode = "110";
            string hosCode = "130";
            string yy = DateTime.Now.ToString("yy");
            return  proCode + hosCode + yy + _hospnumber ;
        }
    }
}
