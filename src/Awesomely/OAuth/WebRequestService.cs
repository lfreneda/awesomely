using System;
using System.IO;
using System.Net;
using System.Text;

namespace Awesomely.OAuth {

    public class WebRequestService : IWebRequestService {

        public string Get(string uri) {
            try {

                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                request.Credentials = CredentialCache.DefaultCredentials;
                var response = (HttpWebResponse)request.GetResponse();
                var receiveStream = response.GetResponseStream();


                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var result = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return result;
            }
            catch { return null; }
        }

        public string Post(string uri) {
            try {
                var values = uri.Split('?');
                return Post(values[0], values[1]);
            }
            catch (Exception) {
                return null;
            }
        }

        private string Post(string uri, string parameters) {

            Stream os = null;

            try {

                var webRequest = WebRequest.Create(uri);
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                var bytes = Encoding.ASCII.GetBytes(parameters);

                webRequest.ContentLength = bytes.Length;
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);

                var webResponse = webRequest.GetResponse();
                var sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (Exception) { return null; }
            finally { if (os != null) os.Close(); }
        }
    }
}