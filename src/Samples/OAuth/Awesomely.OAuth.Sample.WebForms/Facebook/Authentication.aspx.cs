using System;
using Awesomely.OAuth.Facebook;
using Facebook.Lib;

namespace Awesomely.OAuth.Sample.WebForms.Facebook {
    public partial class Authentication : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(Request["error_reason"])) {

                var oAuthAuthentication = new OAuthAuthentication(new WebRequestService(), new FacebookUriAuthentication(Request.IsSecureConnection), new FacebookExtractTokenFromText());
                if (oAuthAuthentication.Authenticate(Request["code"], RequestType.Get)) {

                    var client = new FacebookClient(oAuthAuthentication.Token);
                    var info = client.Get("me?fields=id,name");
                    var facebookId = (string)info.id;
                    var facebookName = (string)info.name;

                    Response.Write("id:" + facebookId + "- name::" + facebookName);
                }
            }

            Response.Flush();
            Response.End();
        }
    }
}