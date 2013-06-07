using System.Net;
using System.Web.Mvc;
using Awesomely.OAuth.Orkut;

namespace Awesomely.OAuth.Sample.MVC.Controllers {
    public class OrkutController : Controller {

        public ActionResult Authentication(string code) {

            if (!string.IsNullOrEmpty(code)) {

                var oAuthAuthentication = new OAuthAuthentication(new WebRequestService(), new OrkutUriAuthentication(), new OrkutExtractTokenFromText());

                if (oAuthAuthentication.Authenticate(code, RequestType.Post)) {

                    string info;
                    using (var webClient = new WebClient()) {
                        info = webClient.DownloadString(string.Format("https://www.orkut.com/social/rest/people/@me?access_token={0}", oAuthAuthentication.Token));
                    }

                    Response.Write(info);
                }
            }

            return null;
        }
    }
}