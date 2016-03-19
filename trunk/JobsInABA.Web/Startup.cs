using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Web.Hosting;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(JobsInABA.Web.Startup))]
namespace JobsInABA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureOAuth(app);
        //    //Rest of code is here;
        //}

        //public void ConfigureOAuth(IAppBuilder app)
        //{
        //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/token"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        Provider = new SimpleAuthorizationServerProvider()
        //    };

        //    // Token Generation
        //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //}
    }

    //public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    //{
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //    }

    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

    //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

    //        IdentityUser user = await _userManager.FindAsync(context.UserName, context.Password);

    //        if (user == null)
    //        {
    //            context.SetError("invalid_grant", "The user name or password is incorrect.");
    //            return;
    //        }

    //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //        identity.AddClaim(new Claim("sub", context.UserName));
    //        identity.AddClaim(new Claim("role", "user"));

    //        context.Validated(identity);
    //    }
    //}
}
