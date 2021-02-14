using AspNetIdentity.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class AssessmentsLogic
    {
        public string GetAssessmentsByAccountId(int Id)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                var result = context.Users
                    .Join(context.AspNetUsers, a => a.Id_Hash, b => b.Id, (a, b) => new {a.Id_Hash, a.Id_User, a.Name, a.FirstName, a.LastName, a.Email, a.CreationDate, a.Active, a.Id_Account, b.Level })
                    .Join(context.AspNetUserRoles, a => a.Id_Hash, b => b.UserId, (a, b) => new {b.RoleId, a.Id_User, a.Name, a.FirstName, a.LastName, a.Email, a.CreationDate, a.Active, a.Id_Account, a.Level })
                    .Join(context.AspNetRoles, a => a.RoleId, b => b.Id, (a, b) => new {NameRole =b.Name,a.RoleId, a.Id_User, a.Name, a.FirstName, a.LastName, a.Email, a.CreationDate, a.Active, a.Id_Account, a.Level })
                    .Where(w => w.Id_Account == Id )
                    .Select(s => new { s.Id_User, s.Name, s.FirstName, s.LastName, s.Email, s.CreationDate, s.Active, s.NameRole })
                    .ToList();

                return JsonConvert.SerializeObject(result);
            }
        }

        public List<string>  GetRole()
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                var result = context.AspNetRoles.Select(x => x.Name).ToList();

                return result;
            }
        }
    }
}