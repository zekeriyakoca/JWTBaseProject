using System;
using System.Threading.Tasks;

namespace BaseJWT.Domain.Interface
{
    public interface IUnitOfWork
    {
        Task<int> Complete();
        Task TransactionComplete(Action function);
        Task TransactionCompleteAsync(Func<Task> function);
    }
}