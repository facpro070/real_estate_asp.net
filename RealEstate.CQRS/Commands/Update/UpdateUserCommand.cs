﻿using MediatR;
using RealEstate.MediatR.BehaviorModels.ResponseModels;

namespace RealEstate.MediatR.Commands.Update
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public string UserName { get; }

        public string Email { get; }

        //public string Password { get; }


        // TODO Update commands depending on the input fields 
        public UpdateUserCommand(string username, string email, string password)
        {
            UserName = username;
            Email = email;
            //Password = password;
        }
    }
}
