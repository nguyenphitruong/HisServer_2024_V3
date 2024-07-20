using System.ComponentModel;
namespace ServiceProviderCore.Util
{
    public class ExtendedDictionary<K, T> : Dictionary<K, T>, INotifyPropertyChanged
    {
        public ExtendedDictionary()
        {
        }

        public ExtendedDictionary(IDictionary<K, T> dictionary)
            : base(dictionary)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public new T this[K key]
        {
            get
            {
                try
                {
                    return base[key];
                }
                catch (KeyNotFoundException ex)
                {
                    throw new KeyNotFoundException(string.Format("The given key ({0}) was not present in the dictionary", key), ex.InnerException);
                }
            }
            set
            {
                base[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key.ToString()));
            }
        }

        public new void Add(K key, T value)
        {
            try
            {
                base.Add(key, value);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(string.Format("Item with key '{0}' already existed.", key));
            }
        }
    }
}
