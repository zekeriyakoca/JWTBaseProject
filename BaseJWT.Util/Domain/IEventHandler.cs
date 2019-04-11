using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Util.Domain
{
    public interface IEventHandler<TParam>
    {
        Task Handle(TParam param);
    }
}
