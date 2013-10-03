using System.Web.Mvc;
using Awesomely.OAuth.Facebook;
using Facebook.Lib;

namespace Awesomely.OAuth.Sample.MVC.Controllers {
    public class FacebookController : Controller {

        public ActionResult Authentication(string error_reason,
                                           string error,
                                           string error_description,
                                           string code) {

            if (string.IsNullOrEmpty(error_reason)) {
                if (!string.IsNullOrEmpty(code)) {

                    var oAuthAuthentication = new OAuthAuthentication(new WebRequestService(),
                                                                      new FacebookUriAuthentication(Request.IsSecureConnection),
                                                                      new FacebookExtractTokenFromText());

                    if (oAuthAuthentication.Authenticate(code, RequestType.Get)) {

                        var client = new FacebookClient(oAuthAuthentication.Token);

                        var info = client.Get("me?fields=id,name");
                        var facebookId = (string)info.id;
                        var facebookName = (string)info.name;

                        Response.Write("id:" + facebookId + "- name::" + facebookName);
                    }
                }
            }

            return null;
        }
    }
}