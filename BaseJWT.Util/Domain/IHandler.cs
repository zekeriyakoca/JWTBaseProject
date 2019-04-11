using System.Threading.Tasks;

namespace BaseJWT.Util.Domain
{
    public interface IHandler<T> where T : IDomainEvent
    {
        Task Handle(T eventParams);
    }
}
