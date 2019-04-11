using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWT.Util.Infrastructure
{
    public class AppException : Exception
    {
        public AppException(string message)
            : base(message)
        {
        }
    }
}
