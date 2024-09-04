using static Web.StaticDetails;

namespace Web.Models
{
    public class APIRequest
    {
        public object Data { get; set; }
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
