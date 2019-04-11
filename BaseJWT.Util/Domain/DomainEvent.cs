using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Util.Domain
{
    public static class DomainEvents
    {
        private static List<Delegate> actions;
        private static ServiceProvider provider;

        public static void Init(IServiceCollection container)
        {
            provider = container.BuildServiceProvider();
        }

        //Registers a callback for the given domain event, used for testing only
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static async Task Raise<T>(T args) where T : IDomainEvent
        {
            if (provider != null)
            {
                foreach (var handler in provider.GetServices<IHandler<T>>())
                {
                    await handler.Handle(args);
                }
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }

        public static async Task Call<TEvent, TParam>(TParam param) where TEvent : IEventHandler<TParam>
        {
            foreach (var handler in provider.GetServices<TEvent>())
            {
                await handler.Handle(param);
            }
        }
    }
}
