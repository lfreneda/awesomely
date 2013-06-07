namespace Awesomely.OAuth
{
    public interface IConfiguration {
        string ApplicationId { get; }
        string ApplicationSecret { get; }
        string RedirectUri { get; }
    }
}