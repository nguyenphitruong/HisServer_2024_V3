namespace ServiceProvider
{
    public class ServiceInfo
    {
        public int id { get; set; }
        public string serverIP { get; set; }
        public string code { get; set; }
        public string module { get; set; }
        public string content { get; set; }
        public string method { get; set; }
        public string version { get; set; }
        public string uri
        {
            //get { return serverIP + "/" + content; }
            get { return  content; }
        }
    }
}
