using BaseJWT.Domain.DTO.Account;
using BaseJWT.Infrastructure.EntityFramework.Context;
using BaseJWT.Util.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseJWT.Infrastructure.Security.Events
{
    public class UserRegisterEvent : IDomainEvent
    {
        public readonly UserTypeEnum Type;
        public readonly string Token;
        public readonly string Email;

        public UserRegisterEvent(UserTypeEnum type, string email, string token)
        {
            Type = type;
            Email = email;
            Token = token;
        }
    }

    public class UserRegisterComplated : IHandler<UserRegisterEvent>
    {
        readonly DataContext context;

        public UserRegisterComplated(DataContext context)
        {
            this.context = context;
        }

        public async Task Handle(UserRegisterEvent eventParams)
        {
            //TODO Complete
        }
    }
}
