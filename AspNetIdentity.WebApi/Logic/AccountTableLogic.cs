using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic

{
    public class AccountTableLogic
    {

        Accounts ModCtx = new Accounts();

        public int GetAccountId(string Id)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                Users users = context.Users.Where(w => w.Id_Hash.Equals(Id, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                return users.Id_Account;
            }
        }

        public AccountTableModel Crear(AccountTableModel a)
        {
            using (ZonasFEntities Ctx = new ZonasFEntities())
            {
                Accounts Nuevo = new Accounts
                {
                  Id_Account = a.Id_Account ,
                  Id_Country=a.Id_Country,
                  Id_Code=a.Id_Code,
                  Name=a.Name,
                  CreationDate = DateTime.Now,
                  ImageName =a.ImageName,
                  Active=a.Active,
                  LastChangeDate = DateTime.Now,
                  LastChangeUser = 12
                };
                Ctx.Accounts.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<AccountTableModel> Consulta()
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var lista = Ctx.Accounts
                 .Join(Ctx.CtPais, b => b.Id_Country, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.Id_Account, b.Id_Country, b.Id_Code, b.Name, b.CreationDate,b.ImageName,b.Active,b.LastChangeDate,b.LastChangeUser, NombrePais = c.NOMBRE })
                .Where(d => d.Active == true)
                .Select(a => new AccountTableModel
                {
                    Id_Account = a.Id_Account,
                    Id_Country = a.Id_Country,
                    NombreCountry = a.NombrePais,
                    Id_Code = a.Id_Code,
                    Name = a.Name,
                    CreationDate = a.CreationDate,
                    ImageName = a.ImageName,
                    Active = a.Active,
                    LastChangeDate = a.LastChangeDate,
                    LastChangeUser = a.LastChangeUser
                });

            return lista.ToList();
        }
        
        public AccountTableModel ConsultarId(int id)
        {
            ZonasFEntities Ctx = new ZonasFEntities();
            var a = Ctx.Accounts
                .Join(Ctx.CtPais, b => b.Id_Country, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.Id_Account, b.Id_Country, b.Id_Code, b.Name, b.CreationDate, b.ImageName, b.Active, b.LastChangeDate, b.LastChangeUser, NombrePais = c.NOMBRE })
                .Where(w => w.Id_Account == id).Select(s => s).FirstOrDefault();
                AccountTableModel x = new AccountTableModel();

                x.Id_Account = a.Id_Account; 
                x.Id_Country = a.Id_Country ;
                x.NombreCountry = a.NombrePais;
                x.Id_Code = a.Id_Code;
                x.Name = a.Name;
                x.CreationDate = a.CreationDate;
                x.ImageName = a.ImageName;
                x.Active = a.Active;
                x.LastChangeDate = a.LastChangeDate;
                x.LastChangeUser = a.LastChangeUser;

                return x;
        }
         
        public AccountTableModel Actualizar(AccountTableModel a)
        {
            using (var Ctx = new ZonasFEntities())
            {
                var x = Ctx.Accounts.Where(s => s.Id_Account == a.Id_Account).FirstOrDefault();
                if (x != null)
                {
                    x.Id_Account = a.Id_Account;
                    x.Id_Country = a.Id_Country;
                    x.Id_Code = a.Id_Code;
                    x.Name = a.Name;
                    x.CreationDate = a.CreationDate;
                    x.ImageName = a.ImageName;
                    x.Active = a.Active;
                    x.LastChangeDate = DateTime.Now;
                    x.LastChangeUser = 12;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new Accounts();
            using (var Ctx = new ZonasFEntities())
            {
                ResCtx = Ctx.Accounts.Where(s => s.Id_Account == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.Active = false;
                    Ctx.SaveChanges();
                }
            }
            return ResCtx.Id_Account.ToString();
        }
    }
}