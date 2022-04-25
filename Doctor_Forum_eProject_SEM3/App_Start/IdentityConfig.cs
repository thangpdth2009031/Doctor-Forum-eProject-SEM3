using Doctor_Forum_eProject_SEM3.Data;
using Doctor_Forum_eProject_SEM3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {   
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/AccountModels/Login"),
            });
        }

    }
}