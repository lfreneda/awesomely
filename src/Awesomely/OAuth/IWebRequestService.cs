namespace Awesomely.OAuth {

    public interface IWebRequestService {
        string Get(string uri);
        string Post(string uri);
    }
}
