using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMFLMS
{
    public class AuthorizeUsers : AuthorizeAttribute
    {
        public AuthorizeUsers()
        {
            Roles="SuperAdmin,Admin,MainAdmin";
        }
    }
}