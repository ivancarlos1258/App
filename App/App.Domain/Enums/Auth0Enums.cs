using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace G_BOV.Domain.Enums
{
    public class Auth0Enums
    {
        public enum UrlBoolean
        {
            [EnumMember(Value = "true")]
            True,

            [EnumMember(Value = "false")]
            False,

            [EnumMember(Value = null)]
            Null
        }
    }
}
