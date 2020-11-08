using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class AsignacionLogic
    {

        public string AsignarExp(string NumeroExp, string User, string Tipo)
        {
            string Resultado = "";
            using (ZonasFEntities Ctx = new ZonasFEntities())// --------------------- //
            {
                if (Tipo == "1")
                {
                    CaracterizacionSolicitante querysolicitante = Ctx.BaldiosPersonaNatural
                        .Join(Ctx.CaracterizacionSolicitante, b => b.id, c => c.IdExpediente, (b, c) => new { b, c })
                        .Where(a => a.b.NumeroExpediente == NumeroExp)
                        .Select(x => x.c).FirstOrDefault();

                    if (querysolicitante != null ) {
                        if (querysolicitante.Gestion == null)
                        {
                            var ResCtx = Ctx.CaracterizacionSolicitante.Where(s => s.Id == querysolicitante.Id && s.Estado == true).FirstOrDefault();
                            if (ResCtx != null)
                            {
                                ResCtx.IdAspNetUser = User;
                                Resultado = "El registro se modifico";
                            }
                            
                        }
                        else
                        {
                            return "El registro ya tiene Gestion ";
                        }


                    } else {

                        var IdExpediente = Ctx.BaldiosPersonaNatural.Where(x => x.NumeroExpediente == NumeroExp).FirstOrDefault().id;
                        CaracterizacionSolicitante CaracterizacionSolicitante_ = new CaracterizacionSolicitante
                        {
                            IdExpediente = IdExpediente,
                            Estado = true,
                            IdAspNetUser = User,
                            FechaModificacion = DateTime.Now,
                            TipoDocumento = 1,
                            TipoDocumentoConyuge = 1
                        };
                        Ctx.CaracterizacionSolicitante.Add(CaracterizacionSolicitante_);
                        Resultado = "El registro se creo";

                    }

                }
                else if (Tipo == "2")
                {
                    CaracterizacionJuridica querysolicitante = Ctx.BaldiosPersonaNatural
                        .Join(Ctx.CaracterizacionJuridica, b => b.id, c => c.IdExpediente, (b, c) => new { b, c })
                        .Where(a => a.b.NumeroExpediente == NumeroExp)
                        .Select(x => x.c).FirstOrDefault();

                    if (querysolicitante != null)
                    {
                        if (querysolicitante.Gestion == null)
                        {
                            var ResCtx = Ctx.CaracterizacionJuridica.Where(s => s.Id == querysolicitante.Id && s.Estado == true).FirstOrDefault();
                            if (ResCtx != null)
                            {
                                ResCtx.IdAspNetUser = User;
                                Resultado = "El registro se modifico";
                            }
                            
                        }
                        else
                        {
                            return "El registro ya tiene Gestion ";
                        }

                    }
                    else
                    {

                        var IdExpediente = Ctx.BaldiosPersonaNatural.Where(x => x.NumeroExpediente == NumeroExp).FirstOrDefault().id;
                        CaracterizacionJuridica CaracterizacionJuridica_ = new CaracterizacionJuridica
                        {
                            Id =1,
                            IdExpediente = IdExpediente,
                            Estado = true,
                            IdAspNetUser = User,
                            FechaModificacion = DateTime.Now,
                        };
                        Ctx.CaracterizacionJuridica.Add(CaracterizacionJuridica_);
                        Resultado = "El registro se creo";

                    }

                }
                else if (Tipo == "3")
                {
                    Registro querysolicitante = Ctx.BaldiosPersonaNatural
                        .Join(Ctx.Registro, b => b.id, c => c.IdExpediente, (b, c) => new { b, c })
                        .Where(a => a.b.NumeroExpediente == NumeroExp)
                        .Select(x => x.c).FirstOrDefault();

                    if (querysolicitante != null)
                    {
                        if (querysolicitante.Estado == null)
                        {
                            var ResCtx = Ctx.Registro.Where(s => s.Id == querysolicitante.Id && s.EstadoRegistro == true).FirstOrDefault();
                            if (ResCtx != null)
                            {
                                ResCtx.IdAspNetUser = User;
                                Resultado = "El registro se modifico";
                            }
                        }
                        else
                        {
                            return "El registro ya tiene Gestion ";
                        }


                    }
                    else
                    {

                        var IdExpediente = Ctx.BaldiosPersonaNatural.Where(x => x.NumeroExpediente == NumeroExp).FirstOrDefault().id;
                        Registro Registro_ = new Registro
                        {
                            IdExpediente = IdExpediente,
                            EstadoRegistro = true,
                            IdAspNetUser = User,
                            FechaInsercion = DateTime.Now,
                        };
                        Ctx.Registro.Add(Registro_);
                        Resultado = "El registro se creo";

                    }

                }
                else if (Tipo == "4")
                {
                        GeneracionDocumentos querysolicitante = Ctx.BaldiosPersonaNatural
                        .Join(Ctx.GeneracionDocumentos, x => x.id, c =>c.IdExpediente.Value, (x, c) => new { x, c })
                        .Where(a => a.x.NumeroExpediente == NumeroExp)
                        .Select(f => f.c).FirstOrDefault();

                    if (querysolicitante != null)
                    {
                        if (querysolicitante.Gestion == null)
                        {
                            var ResCtx = Ctx.GeneracionDocumentos.Where(s => s.Id == querysolicitante.Id && s.Estado == true).FirstOrDefault();
                            if (ResCtx != null)
                            {
                                ResCtx.IdAspNetUser = User;
                                Resultado = "El registro se modifico";
                            }
                        }
                        else
                        {
                            return "El registro ya tiene Gestion ";
                        }

                    }
                    else
                    {

                        var IdExpediente = Ctx.BaldiosPersonaNatural.Where(x => x.NumeroExpediente == NumeroExp).FirstOrDefault().id;
                        GeneracionDocumentos GeneracionDocumentos_ = new GeneracionDocumentos
                        {
                            IdExpediente = Convert.ToInt32(IdExpediente),
                            Estado = true,
                            IdAspNetUser = User,
                            FechaCargue = DateTime.Now,
                        };
                        Ctx.GeneracionDocumentos.Add(GeneracionDocumentos_);
                        Resultado = "El registro se creo";

                    }

                }

                Ctx.SaveChanges();

                return Resultado;
            }

        }
    }
}