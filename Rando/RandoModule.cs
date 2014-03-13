using System;
using System.Configuration;
using Nancy;
using TweetSharp;

namespace Rando
{
    public class RandoModule : NancyModule
    {
        public RandoModule()
        {
            Post["/rando"] = x => WriteRando();
        }

        private Response WriteRando()
        {
            Guid password = Request.Form.password;
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            var token = ConfigurationManager.AppSettings["token"];
            var tokenSecret = ConfigurationManager.AppSettings["tokenSecret"];
            //require a password so people don't just randomly spam this endpoint
            if (password == new Guid(ConfigurationManager.AppSettings["password"]))
            {
                var rando = Rando.Console.Program.GenerateRando(System.Web.HttpContext.Current.Server.MapPath("~"));
                var service = new TwitterService(consumerKey, consumerSecret, token, tokenSecret);
                
                service.BeginSendTweet(new SendTweetOptions {Status = rando});
            }
            return new Response() { StatusCode = HttpStatusCode.OK };
        }
    }
}