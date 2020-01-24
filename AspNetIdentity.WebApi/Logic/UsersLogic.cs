using AspNetIdentity.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class UsersLogic
    {
        public string GetUsersByAccountId(int Id)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                var result = context.Users
                    .Join(context.AspNetUsers, a => a.Id_Hash, b => b.Id, (a, b) => new { a.Id_User, a.Name, a.FirstName, a.LastName, a.Email, a.CreationDate, a.Active, a.Id_Account, b.Level })
                    .Where(w => w.Id_Account == Id && w.Level == 2)
                    .Select(s => new { s.Id_User, s.Name, s.FirstName, s.LastName, s.Email, s.CreationDate, s.Active })
                    .ToList();

                return JsonConvert.SerializeObject(result);
            }
        }

        public string GetUserById(int Id)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                var result = context.Users
                    .Where(w => w.Id_User == Id)
                    .Select(s => new { s.Id_User, s.Name, s.FirstName, s.LastName, s.Email, s.CreationDate, s.Active })
                    .FirstOrDefault();

                return JsonConvert.SerializeObject(result);
            }
        }

        public void CreateUser(CreateUserBindingModel pModel, string HashId)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                int UserId = context.Users.Where(w => w.Id_Hash.Equals(pModel.Id_User, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Id_User;

                Users users =
                    new Users()
                    {
                        Id_Account = pModel.Id_Account,
                        Id_Hash = HashId,
                        Name = pModel.Name,
                        FirstName = pModel.FirstName,
                        LastName = pModel.LastName,
                        Email = pModel.Email,
                        CreationDate = DateTime.Now,
                        LastChangeDate = DateTime.Now,
                        CreationUser = UserId,
                        LastChangeUser = UserId,
                        RootUser = pModel.RootUser,
                        Active = true,
                        ImageName = string.Empty
                    };

                context.Users.Add(users);
                context.SaveChanges();
            }
        }

        public bool UpdateUser(PutUsersBindingModel putUser)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                if (putUser.Id_User > 0)
                {
                    Users users = context.Users.Where(w => w.Id_User == putUser.Id_User).FirstOrDefault();
                    users.Name = putUser.Name;
                    users.FirstName = putUser.FirstName;
                    users.LastName = putUser.LastName;
                    users.Email = putUser.Email;
                    users.Active = putUser.Active;
                    users.LastChangeDate = DateTime.Now;

                    AspNetUsers aspNetUsers = context.AspNetUsers.Where(w => w.Id.Equals(users.Id_Hash, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    aspNetUsers.FirstName = users.Name;
                    aspNetUsers.LastName = users.FirstName + " " + users.LastName;
                    aspNetUsers.Email = users.Email;
                    aspNetUsers.UserName = users.Email;

                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                using (ZonasFEntities context = new ZonasFEntities())
                {
                    Users user = context.Users.Where(w => w.Id_User == Id).FirstOrDefault();
                    string IDH = user.Id_Hash;
                    context.Users.Remove(user);

                    AspNetUsers aspNetUser = context.AspNetUsers.Where(w => w.Id.Equals(IDH, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    context.AspNetUsers.Remove(aspNetUser);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}