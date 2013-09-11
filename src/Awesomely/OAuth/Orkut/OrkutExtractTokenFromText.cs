using System.Text.RegularExpressions;

namespace Awesomely.OAuth.Orkut
{
    public class OrkutExtractTokenFromText : IExtractTokenFromText {

        public string Extract(string text) {

            if (text != null) {
                var match = Regex.Match(text, @"access_token\""?\s:?\s\""(?<access_token>[\w|\.|-]+)\""");
                if (match.Groups["access_token"].Success) {
                    return match.Groups["access_token"].Value;
                }
            }

            return null;
        }
    }
}