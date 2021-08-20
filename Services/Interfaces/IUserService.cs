using Domain.Entities;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public ResultResponse<User> InsertUser(User user);

        public ResultResponse<User> UpdateUser(int id, User user);

        public ResultResponse<User> DeleteUser(int id);
    }
}
