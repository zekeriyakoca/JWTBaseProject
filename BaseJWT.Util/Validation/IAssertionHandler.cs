using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Util.Validation
{
    public interface IAssertionHandler<T>
    {
        Task Check(T param);
    }
}
