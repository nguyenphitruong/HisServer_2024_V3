namespace ServiceProviderCore.Util
{
    public class DataObject : ExtendedDictionary<string, object>
    {
        public DataObject()
        {
        }

        public DataObject(IDataObject dictionary)
            : base(dictionary)
        {
        }

        public virtual bool Contains(string strName)
        {
            return this.ContainsKey(strName);
        }
    }
}
