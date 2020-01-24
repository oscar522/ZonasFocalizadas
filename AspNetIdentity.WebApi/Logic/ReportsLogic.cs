using AspNetIdentity.WebApi.Charts;
using AspNetIdentity.WebApi.Models;
using AspNetIdentity.WebApi.Reports;
using AspNetIdentity.WebApi.Reports.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class ReportsLogic
    {
        public string GetReportsByUserId(string Id)
        {
            using (ZonasFEntities context = new ZonasFEntities())
            {
                int id_Account = context.Users.Where(w => w.Id_Hash == Id).FirstOrDefault().Id_Account;

                var result = context.Temp_AspNetUsersTests
                    .Join(context.Users, a => a.Id_User, b => b.Id_Hash, (a, b) => new { a.Id_Test, b.Id_Account, a.Id_StatusTest, a.Id_UserTest, a.LastUpdate, b.Name, b.FirstName, b.LastName, b.Email })
                    .Join(context.CT_Tests, b => b.Id_Test, c => c.Id_Test, (b, c) => new { b.Id_Account, b.Id_StatusTest, b.Id_UserTest, b.LastUpdate, b.Name, b.FirstName, b.LastName, b.Email, c.Test })
                    .Join(context.Cat_StatusTest, c=>c.Id_StatusTest, d=>d.Id_StatusTest, (c,d)=> new { c.Id_Account, c.Id_StatusTest, c.Id_UserTest, c.LastUpdate, c.Name, c.FirstName, c.LastName, c.Email, c.Test, d.StatusTest })
                    .Where(w => w.Id_Account == id_Account)
                    .Select(s => new { s.Id_UserTest, s.LastUpdate, s.Name, s.FirstName, s.LastName, s.Email, s.Test, s.Id_StatusTest, s.StatusTest })
                    .ToList();

                return JsonConvert.SerializeObject(result);
            }
        }

        public string GetReportById(int Id)
        {
            int Id_Test = 0;

            ReportParts reportParts = new ReportParts();
            reportParts.headerPart = new HeaderPart();
            reportParts.bodyParts = new List<BodyPart>();

            SectionParts _sectionParts2 = new SectionParts();
            _sectionParts2.Title = "Resultados";
            _sectionParts2.SubSections = new List<SectionParts>();

            using (ZonasFEntities context = new ZonasFEntities())
            {
                var generals = context.Temp_AspNetUsersTests
                    .Join(context.Users, a => a.Id_User, b => b.Id_Hash, (a, b) => new { b.Id_Account, a.Id_Test, a.Id_UserTest, a.LastUpdate, b.Name, b.FirstName, b.LastName })
                    .Join(context.Accounts, b => b.Id_Account, c => c.Id_Account, (b, c) => new { b.Id_Test, b.Id_UserTest, b.LastUpdate, b.Name, b.FirstName, b.LastName, Account = c.Name })
                    .Join(context.CT_Tests, c => c.Id_Test, d => d.Id_Test, (c, d) => new { c.Id_UserTest, c.LastUpdate, c.Name, c.FirstName, c.LastName, c.Account, d.Test, d.Id_Test, d.ImageName })
                    .Where(w => w.Id_UserTest == Id)
                    .Select(s => new { s.LastName, s.Name, s.FirstName, s.LastUpdate, s.Account, s.Test, s.Id_Test, s.ImageName })
                    .FirstOrDefault();

                if (generals != null)
                {
                    reportParts.headerPart.Company = generals.Account;
                    reportParts.headerPart.EvaluationDate = generals.LastUpdate;
                    reportParts.headerPart.Test = generals.Test;
                    reportParts.headerPart.Name = generals.Name + " " + generals.FirstName + " " + generals.LastName;
                    reportParts.headerPart.CoverPageImage = ConfigurationManager.AppSettings["ImgPortada"] + generals.ImageName;
                    Id_Test = generals.Id_Test;
                }

                var scores = context.Temp_AspNetUsersTests
                    .Join(context.Temp_AspNetUsersTests_Details, a => a.Id_UserTest, b => b.Id_UserTest, (a, b) => new { a.Id_UserTest, b.Answer })
                    .Join(context.CT_Answers, b => b.Answer, c => c.Id_Answer.ToString(), (b, c) => new { b.Id_UserTest, c.Weight, c.Id_Question })
                    .Join(context.CT_Questions, c => c.Id_Question, d => d.Id_Question, (c, d) => new { c.Id_UserTest, c.Weight, d.Id_Factor })
                    .Join(context.CT_Factors, d => d.Id_Factor, e => e.Id_Factor, (d, e) => new { d.Id_UserTest, d.Weight, e.Id_Dimension })
                    .Join(context.CT_Dimensions, e => e.Id_Dimension, f => f.Id_Dimension, (e, f) => new { e.Id_UserTest, e.Weight, f.Id_Dimension, f.Dimension, f.R, f.G, f.B, f.Visible })
                    .Join(context.CT_Dimension_Notes, f => f.Id_Dimension, g => g.Id_Dimension, (f, g) => new { f.Id_UserTest, f.Weight, f.Id_Dimension, f.Dimension, g.W_Max, g.W_Min, g.Score, g.Note, f.R, f.G, f.B, f.Visible })
                    .Where(w => w.Id_UserTest == Id && w.Visible == true)
                    .GroupBy(gb => new { gb.Id_Dimension, gb.Dimension, gb.W_Min, gb.W_Max, gb.Score, gb.Note, gb.R, gb.G, gb.B })
                    .Where(w => w.Sum(ss => ss.Weight) >= w.Key.W_Min && w.Sum(ss => ss.Weight) <= w.Key.W_Max)
                    .Select(s => new { s.Key.Dimension, s.Key.Score, s.Key.Note, s.Key.R, s.Key.G, s.Key.B })
                    .ToList();

                scores.ForEach(
                    fe => _sectionParts2.SubSections.Add(
                        new SectionParts()
                        {
                            Title = fe.Dimension,
                            Description = fe.Note,
                            Value = fe.Score,
                            Color = new Dictionary<string, int>() { { "r", fe.R.Value }, { "g", fe.G.Value }, { "b", fe.B.Value } }
                        }));

                _sectionParts2.Image = CustomCharts.Chart(_sectionParts2.SubSections.Select(s => new XY() { xValue = s.Title, yValue = s.Value, rgbColor = s.Color }).ToList());
            }

            
            BodyPart bodyPart = new BodyPart() { Id_Test = Id_Test, sectionParts = new List<SectionParts>() };

            SectionParts sectionPartsDescription = DescriptionsTest(Id_Test);
            bodyPart.sectionParts.Add(sectionPartsDescription);
            bodyPart.sectionParts.Add(_sectionParts2);

            reportParts.bodyParts.Add(bodyPart);

            MakeReport makeReport = new MakeReport(reportParts);
            MemoryStream _MemoryStream = makeReport.Make();
            string base64String = Convert.ToBase64String(_MemoryStream.ToArray());

            return base64String;
        }

        private SectionParts DescriptionsTest(int Id_Test)
        {
            SectionParts _sectionParts = new SectionParts();

            switch (Id_Test)
            {
                case 1:
                    _sectionParts.Title = "Text de Personalidad Operativo";
                    _sectionParts.Description = "La personalidad son aquellas características únicas y estables (cogniciones, conductas y emociones) de la persona, las cuáles perduran a través del tiempo y en diferentes situaciones; dichas características subyacen tanto de la naturaleza de la persona como del aprendizaje. El Test de Personalidad GTH se basa en las recientes teorías de personalidad y fue desarrollado para el ámbito organizacional, definiendo cinco factores:";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Responsabilidad",
                            Description = "Las personas responsables son meticulosas, cuidadosas, organizadas, y planificadoras.",
                            Color = new Dictionary<string, int>() { { "r", 242 }, { "g", 200 }, { "b", 31 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Amabilidad",
                            Description = "Las personas amables son cordiales, amistosas, sociables, comprensivas y agradables.",
                            Color = new Dictionary<string, int>() { { "r", 77 }, { "g", 184 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Inestabilidad Emocional",
                            Description = "Las personas inestables emocionalmente muestran poco control emocional, inquietos, intolerantes e impacientes.",
                            Color = new Dictionary<string, int>() { { "r", 96 }, { "g", 110 }, { "b", 159 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Apertura",
                            Description = "Las personas abiertas son curiosas, creativas, sensibles, flexibles y abiertas.",
                            Color = new Dictionary<string, int>() { { "r", 11 }, { "g", 79 }, { "b", 163 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Extraversión",
                            Description = "Las personas extrovertidas son sociables, enérgicas, desenvueltas y locuaces.",
                            Color = new Dictionary<string, int>() { { "r", 251 }, { "g", 120 }, { "b", 132 } },
                            Value = -1
                        });
                    break;

                case 2:
                    _sectionParts.Title = "Text de Personalidad Administrativo";
                    _sectionParts.Description = "La personalidad son aquellas características únicas y estables (cogniciones, conductas y emociones) de la persona, las cuáles perduran a través del tiempo y en diferentes situaciones; dichas características subyacen tanto de la naturaleza de la persona como del aprendizaje. El Test de Personalidad GTH se basa en las recientes teorías de personalidad y fue desarrollado para el ámbito organizacional, definiendo cinco factores:";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Responsabilidad",
                            Description = "Las personas responsables son meticulosas, cuidadosas, analíticas y ordenadas.",
                            Color = new Dictionary<string, int>() { { "r", 242 }, { "g", 200 }, { "b", 31 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Amabilidad",
                            Description = "Las personas son cordiales, empáticas, comprensivas y cooperativas.",
                            Color = new Dictionary<string, int>() { { "r", 77 }, { "g", 184 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Estabilidad Emocional",
                            Description = "Las personas estables emocionalmente muestran un control emocional, tranquilidad, tolerancia y paciencia.",
                            Color = new Dictionary<string, int>() { { "r", 96 }, { "g", 110 }, { "b", 159 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Apertura Mental",
                            Description = "Las personas son curiosas, creativas, sensibles, flexibles y abiertas.",
                            Color = new Dictionary<string, int>() { { "r", 11 }, { "g", 79 }, { "b", 163 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Energía",
                            Description = "Las personas enérgicas son sociables, activas, desenvueltas y locuaces.",
                            Color = new Dictionary<string, int>() { { "r", 251 }, { "g", 120 }, { "b", 132 } },
                            Value = -1
                        });
                    break;

                case 3:
                    _sectionParts.Title = "Text de Personalidad Gerencial";
                    _sectionParts.Description = "La personalidad son aquellas características únicas y estables (cogniciones, conductas y emociones) de la persona, las cuáles perduran a través del tiempo y en diferentes situaciones; dichas características subyacen tanto de la naturaleza de la persona como del aprendizaje. El Test de Personalidad GTH se basa en las recientes teorías de personalidad y fue desarrollado para el ámbito organizacional, definiendo cinco factores:";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Responsabilidad",
                            Description = "Las personas responsables son meticulosas, cuidadosas, analíticas y ordenadas.",
                            Color = new Dictionary<string, int>() { { "r", 242 }, { "g", 200 }, { "b", 31 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Amabilidad",
                            Description = "Las personas son cordiales, empáticas, comprensivas y cooperativas.",
                            Color = new Dictionary<string, int>() { { "r", 77 }, { "g", 184 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Estabilidad Emocional",
                            Description = "Las personas estables emocionalmente muestran un control emocional, tranquilidad, tolerancia y paciencia.",
                            Color = new Dictionary<string, int>() { { "r", 96 }, { "g", 110 }, { "b", 159 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Apertura Mental",
                            Description = "Las personas son curiosas, creativas, sensibles y flexibles.",
                            Color = new Dictionary<string, int>() { { "r", 11 }, { "g", 79 }, { "b", 163 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Energía",
                            Description = "Las personas enérgicas son sociables, activas, desenvueltas y locuaces.",
                            Color = new Dictionary<string, int>() { { "r", 251 }, { "g", 120 }, { "b", 132 } },
                            Value = -1
                        });
                    break;

                case 4:
                    _sectionParts.Title = "Text de Ventas Operativo";
                    _sectionParts.Description = "Las habilidades comerciales son comportamientos, actitudes y aptitudes que implican el manejo de estrés, organización, iniciativa, competitividad y servicio al cliente para identiticar y desarrollar al personal comercial en cualquier ámbito de mercado. El Test de Ventas GTH se basa en las recientes teorías de personalidad y de habilidades comerciales y fue desarrollado para el ámbito organizacional, definido por 14 factores: ";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Manejo del estrés",
                            Description = "Es la capacidad de mantener el control emocional y racional ante situaciones de crisis en el ambiente.",
                            Color = new Dictionary<string, int>() { { "r", 192 }, { "g", 192 }, { "b", 192 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Trabajo en equipo",
                            Description = "Es la habilidad para colaborar y relacionarse con personas para el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Autoconfianza",
                            Description = "Es la seguridad y valoración que se tiene de la individualidad y las decisiones personales.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Organización",
                            Description = "Es la capacidad de estructurar y ordenar las actividades laborales.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Tolerancia a la frustración",
                            Description = "Es la habilidad de soportar situaciones adversas buscando la forma de lograr los objetivos establecidos.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Planeación",
                            Description = "Es la capacidad de visualizar y plasmar las ideas en una serie de actividades para lograr un objetivo.",
                            Color = new Dictionary<string, int>() { { "r", 185 }, { "g", 119 }, { "b", 14 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Extroversión",
                            Description = "Es la habilidad social para relacionarse y desenvolverse con diferentes personas.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Diplomacia",
                            Description = "Es la capacidad de expresar sus ideas de forma clara y respetuosa.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Logro",
                            Description = "Es la capacidad de cumplir las metas establecidas.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Motivación",
                            Description = "Es la estimulación interna o externa que tiene la persona para realizar su trabajo.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Iniciativa",
                            Description = "Es la capacidad para realizar cambios o desarrollar nuevas formas de trabajo que faciliten el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Competitividad",
                            Description = "Es la capacidad de esfuerzo máximo para resaltar ante un grupo.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Cierre de ventas",
                            Description = "Es la habilidad persuasiva para resaltar los beneficios del producto o servicio y lograr convencer al cliente.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Disposición para ventas",
                            Description = "Es la habilidad para identificar las necesidades del cliente con el producto o servicio que se ofrece en la organización.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    break;

                case 5:
                    _sectionParts.Title = "Text de Ventas Administrativo";
                    _sectionParts.Description = "Las habilidades comerciales son comportamientos, actitudes y aptitudes que implican el manejo de estrés, organización, iniciativa, competitividad y servicio al cliente para identiticar y desarrollar al personal comercial en cualquier ámbito de mercado. El Test de Ventas GTH se basa en las recientes teorías de personalidad y de habilidades comerciales y fue desarrollado para el ámbito organizacional, definido por 14 factores: ";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Manejo del estrés",
                            Description = "Es la capacidad de mantener el control emocional y racional ante situaciones de crisis en el ambiente.",
                            Color = new Dictionary<string, int>() { { "r", 192 }, { "g", 192 }, { "b", 192 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Trabajo en equipo",
                            Description = "Es la habilidad para colaborar y relacionarse con personas para el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Autoconfianza",
                            Description = "Es la seguridad y valoración que se tiene de la individualidad y las decisiones personales.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Organización",
                            Description = "Es la capacidad de estructurar y ordenar las actividades laborales.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Tolerancia a la frustración",
                            Description = "Es la habilidad de soportar situaciones adversas buscando la forma de lograr los objetivos establecidos.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Planeación",
                            Description = "Es la capacidad de visualizar y plasmar las ideas en una serie de actividades para lograr un objetivo.",
                            Color = new Dictionary<string, int>() { { "r", 185 }, { "g", 119 }, { "b", 14 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Extroversión",
                            Description = "Es la habilidad social para relacionarse y desenvolverse con diferentes personas.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Diplomacia",
                            Description = "Es la capacidad de expresar sus ideas de forma clara y respetuosa.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Logro",
                            Description = "Es la capacidad de cumplir las metas establecidas.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Motivación",
                            Description = "Es la estimulación interna o externa que tiene la persona para realizar su trabajo.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Iniciativa",
                            Description = "Es la capacidad para realizar cambios o desarrollar nuevas formas de trabajo que faciliten el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Competitividad",
                            Description = "Es la capacidad de esfuerzo máximo para resaltar ante un grupo.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Cierre de ventas",
                            Description = "Es la habilidad persuasiva para resaltar los beneficios del producto o servicio y lograr convencer al cliente.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Disposición para ventas",
                            Description = "Es la habilidad para identificar las necesidades del cliente con el producto o servicio que se ofrece en la organización.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    break;

                case 6:
                    _sectionParts.Title = "Text de Ventas Gerencial";
                    _sectionParts.Description = "Las habilidades comerciales son comportamientos, actitudes y aptitudes que implican el manejo de estrés, organización, iniciativa, competitividad y servicio al cliente para identiticar y desarrollar al personal comercial en cualquier ámbito de mercado. El Test de Ventas GTH se basa en las recientes teorías de personalidad y de habilidades comerciales y fue desarrollado para el ámbito organizacional, definido por 14 factores: ";
                    _sectionParts.SubSections = new List<SectionParts>();
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Manejo del estrés",
                            Description = "Es la capacidad de mantener el control emocional y racional ante situaciones de crisis en el ambiente.",
                            Color = new Dictionary<string, int>() { { "r", 192 }, { "g", 192 }, { "b", 192 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Trabajo en equipo",
                            Description = "Es la habilidad para colaborar y relacionarse con personas para el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Autoconfianza",
                            Description = "Es la seguridad y valoración que se tiene de la individualidad y las decisiones personales.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Organización",
                            Description = "Es la capacidad de estructurar y ordenar las actividades laborales.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Tolerancia a la frustración",
                            Description = "Es la habilidad de soportar situaciones adversas buscando la forma de lograr los objetivos establecidos.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Planeación",
                            Description = "Es la capacidad de visualizar y plasmar las ideas en una serie de actividades para lograr un objetivo.",
                            Color = new Dictionary<string, int>() { { "r", 185 }, { "g", 119 }, { "b", 14 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Extroversión",
                            Description = "Es la habilidad social para relacionarse y desenvolverse con diferentes personas.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Diplomacia",
                            Description = "Es la capacidad de expresar sus ideas de forma clara y respetuosa.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Logro",
                            Description = "Es la capacidad de cumplir las metas establecidas.",
                            Color = new Dictionary<string, int>() { { "r", 255 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Motivación",
                            Description = "Es la estimulación interna o externa que tiene la persona para realizar su trabajo.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 0 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Iniciativa",
                            Description = "Es la capacidad para realizar cambios o desarrollar nuevas formas de trabajo que faciliten el logro de objetivos.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 0 }, { "b", 255 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Competitividad",
                            Description = "Es la capacidad de esfuerzo máximo para resaltar ante un grupo.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 255 }, { "b", 0 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Cierre de ventas",
                            Description = "Es la habilidad persuasiva para resaltar los beneficios del producto o servicio y lograr convencer al cliente.",
                            Color = new Dictionary<string, int>() { { "r", 128 }, { "g", 128 }, { "b", 128 } },
                            Value = -1
                        });
                    _sectionParts.SubSections.Add(
                        new SectionParts()
                        {
                            Title = "Disposición para ventas",
                            Description = "Es la habilidad para identificar las necesidades del cliente con el producto o servicio que se ofrece en la organización.",
                            Color = new Dictionary<string, int>() { { "r", 0 }, { "g", 128 }, { "b", 0 } },
                            Value = -1
                        });
                    break;
            }

            return _sectionParts;
        }
    }
}