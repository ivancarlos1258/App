using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTOs.Auth
{
    public class MyClaim : Claim
    {
        public MyClaim(string type, string value, string valueType, string issuer, string originalIssuer) :
            base(type, value, valueType, issuer, originalIssuer)
        { }
    }
}
