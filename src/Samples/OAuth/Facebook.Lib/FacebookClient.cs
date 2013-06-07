using System;
using System.IO;
using System.Net;
using System.Text;
using DynamicRest;

namespace Facebook.Lib {

    public class FacebookClient {

        private readonly string _token = string.Empty;
        private const string GraphUrl = "https://graph.facebook.com/";

        public FacebookClient() { }

        public FacebookClient(string token) {
            _token = token;
        }

        public dynamic Get(string path) {
            var requestUrl = string.Format("{0}{1}{3}access_token={2}", GraphUrl, path, _token,
                                           path.Contains("?") ? "&" : "?");

            try {
                var request = CreateRequest(requestUrl);
                var jsonText = GetResponse(request);

                var jsonReader = new JsonReader(jsonText);
                dynamic jsonObject = jsonReader.ReadValue();

                return jsonObject;
            }
            catch (Exception) {
                return new object();
            }
        }

        private static string GetResponse(HttpWebRequest request) {
            var response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            var jsonText = string.Empty;

            if (receiveStream != null) {
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                jsonText = readStream.ReadToEnd();
                response.Close(); readStream.Close();

                return jsonText;
            }

            return jsonText;
        }

        private static HttpWebRequest CreateRequest(string requestUrl) {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;

            return request;
        }
    }
}