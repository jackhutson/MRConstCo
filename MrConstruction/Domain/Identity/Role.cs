using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Domain.Identity {
    public class Role : IdentityRole {
        public const string Admin = "Admin";
        public const string Contractor = "Contractor";
    }
}