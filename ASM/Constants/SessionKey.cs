using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Constants
{
    public static class SessionKey
    {
        public static class User
        {
            public const string UserName = "UserName";
            public const string FullName = "FullName";
            public const string Valid = "Valid";
            public const string UserContext = "UserContext";
        }
        public static class Customer
        {
            public const string Cus_Email = "Cus_Email";
            public const string Cus_FullName = "Cus_FullName";
            public const string CustomerContext = "CustomerContext";
        }
        //public const string UserName = "UserName";
    }
}
