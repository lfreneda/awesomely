namespace Awesomely.OAuth {

    public interface IUriAuthentication {
        string GetUriInitializeAuthentication();
        string GetUriTokenRetrieve(string authorizationCode);
    }
}
