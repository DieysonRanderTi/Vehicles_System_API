using Domain.Data;
using Domain.Entities;
using Domain.Response;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Services.Servives
{
    public class UserService: IUserService
    {
        bool validade = false;
        VehiclesContext context = new VehiclesContext();

        public ResultResponse<User> InsertUser(User user)
        {
            validadeUser(user);

            try
            {
                if(validade)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return new ResultResponse<User> { Data = user };
                }
                else
                {
                    return Error<User>(HttpStatusCode.InternalServerError, "Não foi possivel Cadastrar o usuário", "");
                }
            }
            catch (Exception ex)
            {
                return Error<User>(HttpStatusCode.InternalServerError, "Não foi possivel Cadastrar o usuário", ex.Message);             
            }
        } 
        
        public ResultResponse<User> UpdateUser(int id, User user)
        {
            validadeUser(user);
            try
            {
                if (validade)
                {
                    var result = context.Users.Where(x => x.Id == id).FirstOrDefault();
                    result.Id = id;
                    result.UserName = user.UserName;
                    result.Password = user.Password;
                    result.Admin = user.Admin;

                    context.SaveChanges();

                    return new ResultResponse<User> { Data = user };

                }
                else
                {
                    return Error<User>(HttpStatusCode.InternalServerError, "Erro ao editar o usuário", "");
                }
            }
            catch (Exception ex)
            {
                return Error<User>(HttpStatusCode.InternalServerError, "Erro ao editar o usuário", ex.Message);
            }
        }

        public ResultResponse<User> DeleteUser(int id)
        {
            try
            {

               var result = context.Users.Where(x => x.Id == id).FirstOrDefault();
               context.Remove(result);
               context.SaveChanges();

               return new ResultResponse<User> { Data = result };

            }
            catch (Exception ex)
            {
                return Error<User>(HttpStatusCode.InternalServerError, "Erro ao deletar o usuário", ex.Message);
            }
        }

        public void validadeUser(User user)
        {
            if(user.UserName != null && user.Password != null)
            {
                validade = true;
            }
        }

        private ResultResponse<T> Error<T>(HttpStatusCode status, string message, string details) where T : new()
        {
            return new ResultResponse<T>
            {
                Error = true,
                Errors = new List<Errors>
                {
                    new Errors
                    {
                        Id = Guid.NewGuid(), Message = message, Details = details
                    }
                },
                StatusCode = status
            };
        }
    }
}
