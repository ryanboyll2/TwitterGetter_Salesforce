using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TweetSharp;
using TwitterGetter.Models;
using TwitterGetter.Util;
using System.Configuration;

namespace TwitterGetter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Twitter Getter 2017";

            try
            {
                if (Request != null && Request.QueryString["oauth_token"] != null && Session["user"] == null)
                {
                    TwitterSignInCallback(Request.QueryString["oauth_token"], Request.QueryString["oauth_verifier"]);
                }
            
                if ((Session["user"] != null) && (!String.IsNullOrWhiteSpace(Session["user"].ToString())))
                    ViewBag.LoggedInUser = Session["user"].ToString();
                }
            catch (Exception)
            {
            }

            return View();
        }

        public ActionResult TwitterSignIn()
        {
            TwitterService twitterService = new TwitterService(ConfigurationManager.AppSettings["oauth_key"], ConfigurationManager.AppSettings["oauth_secret"]);
            
            OAuthRequestToken requestToken = twitterService.GetRequestToken();
            
            Uri uri = twitterService.GetAuthorizationUri(requestToken);
            return new RedirectResult(uri.ToString(), false);
        }
        
        public ActionResult TwitterSignInCallback(string oauth_token, string oauth_verifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauth_token };
            
            TwitterService twitterService = new TwitterService(ConfigurationManager.AppSettings["oauth_key"], ConfigurationManager.AppSettings["oauth_secret"]);
            OAuthAccessToken accessToken = twitterService.GetAccessToken(requestToken, oauth_verifier);
            
            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);
            TwitterUser user = twitterService.VerifyCredentials(new VerifyCredentialsOptions() { });
            bool successfulLogin = user != null;

            if (successfulLogin)
                Session["user"] = user.ScreenName ;

            return RedirectToAction("Index", "Home");
        }
    }
}
