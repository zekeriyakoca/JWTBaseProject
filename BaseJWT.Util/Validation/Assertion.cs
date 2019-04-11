using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BaseJWT.Util.Validation
{
    public class Assertions : IAssertion
    {
        private ServiceProvider provider;

        public Assertions(IServiceCollection container)
        {
            provider = container.BuildServiceProvider();
        }

        public async Task Check<T, TParam>(TParam param)
            where T : IAssertionHandler<TParam>
            where TParam : IAssertionArgs
        {
            if (provider != null)
            {
                foreach (var handler in provider.GetServices<T>())
                {
                    await handler.Check(param);
                }
            }
        }
    }
}
