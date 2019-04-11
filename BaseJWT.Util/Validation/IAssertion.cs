using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Util.Validation
{
    public interface IAssertion
    {
        Task Check<T, TParam>(TParam param)
            where T : IAssertionHandler<TParam> where TParam : IAssertionArgs;
    }
}
