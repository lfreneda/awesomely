using System.Text.RegularExpressions;

namespace Awesomely.OAuth.Facebook
{
    public class FacebookExtractTokenFromText : IExtractTokenFromText {
        
        public string Extract(string text) {

            if (text != null) {
                var match = Regex.Match(text, @"access_token=(?<access_token>[\w|\.|-]+)&expires=\d+");
                if (match.Groups["access_token"].Success) {
                    return match.Groups["access_token"].Value;
                }
            }

            return null;
        }
    }
}