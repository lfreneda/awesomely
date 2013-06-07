using System;
using System.Net;
using Awesomely.OAuth.Orkut;

namespace Awesomely.OAuth.Sample.WebForms.Orkut {
    public partial class Authentication : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            var authorizationCode = Request["code"];
            if (!string.IsNullOrEmpty(authorizationCode)) {

                var oAuthAuthentication = new OAuthAuthentication(new WebRequestService(), new OrkutUriAuthentication(), new OrkutExtractTokenFromText());

                if (oAuthAuthentication.Authenticate(authorizationCode, RequestType.Post)) {

                    string info;
                    using (var webClient = new WebClient()) {
                        info = webClient.DownloadString(string.Format("https://www.orkut.com/social/rest/people/@me?access_token={0}", oAuthAuthentication.Token));
                    }

                    Response.Write(info);
                }
            }
        }
    }
}