using AspNetIdentity.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class EmployeeLogic
    {
        public string GetPrivPoliByUserId(string Id)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                int Id_Account = aspNetIdentityEntities.Users.Where(w => w.Id_Hash == Id).Select(s => s.Id_Account).FirstOrDefault();

                var result = aspNetIdentityEntities.Accounts_AdditionalInformation.Where(w => w.Id_Account == Id_Account).Select(
                    s => new
                    {
                        Active = s.PrivPoliActive,
                        TextButton = s.PrivPoliButton,
                        Title = s.PrivPoliTitle,
                        Description = s.PrivPoliDescription
                    }).FirstOrDefault();

                return JsonConvert.SerializeObject(result);
            }
        }

        public string GetAboutByUserId(string Id)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                int Id_Account = aspNetIdentityEntities.Users.Where(w => w.Id_Hash == Id).Select(s => s.Id_Account).FirstOrDefault();

                var result = aspNetIdentityEntities.Accounts_AdditionalInformation.Where(w => w.Id_Account == Id_Account).Select(
                    s => new
                    {
                        Active = s.AboutActive,
                        Title = s.AboutTitle,
                        Description = s.AboutDescription
                    }).FirstOrDefault();

                return JsonConvert.SerializeObject(result);
            }
        }

        public string GetMyProcessByUserId(string Id)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                var result = aspNetIdentityEntities.Temp_AspNetUsersTests
                    .Where(w => w.Id_User == Id && w.Id_StatusTest < 3)
                    .Join(aspNetIdentityEntities.CT_Tests, a => a.Id_Test, b => b.Id_Test, (a, b) => new { b, a.Id_UserTest, a.Id_StatusTest })
                    .Select(s => new { s.Id_UserTest, s.Id_StatusTest, s.b.Test, s.b.Description, s.b.Version, ApplicationTime = s.b.ApplicationTime / 60 })
                    .ToList();

                return JsonConvert.SerializeObject(result);
            }
        }

        public string GetTechnicalTestByTestId(int Id)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                Temp_AspNetUsersTests temp_AspNetUsersTests = aspNetIdentityEntities.Temp_AspNetUsersTests.Where(w => w.Id_UserTest == Id).FirstOrDefault();

                List<int> questionsAnswered = aspNetIdentityEntities.Temp_AspNetUsersTests_Details.Where(w => w.Id_UserTest == Id).Select(s => s.Id_Question).ToList();

                var allQuestions = aspNetIdentityEntities.CT_Dimensions
                    .Where(w => w.Id_Test == temp_AspNetUsersTests.Id_Test)
                    .Join(aspNetIdentityEntities.CT_Factors, a => a.Id_Dimension, b => b.Id_Dimension, (a, b) => new { b.Id_Factor })
                    .Join(aspNetIdentityEntities.CT_Questions, b => b.Id_Factor, c => c.Id_Factor, (b, c) => new { c.Id_Question, c.Id_Type, c.Question, c.Has_Time, c.Time })
                    .Join(aspNetIdentityEntities.CT_Answers, c => c.Id_Question, d => d.Id_Question, (c, d) => new { c.Id_Question, c.Id_Type, c.Question, c.Has_Time, c.Time, d.Id_Answer, d.Answer })
                    .Where(w => !questionsAnswered.Contains(w.Id_Question))
                    .Select(s => new { s.Id_Question, s.Id_Type, s.Question, s.Has_Time, s.Time, s.Id_Answer, s.Answer })
                    .ToList();

                var result = allQuestions.GroupBy(gp => new { gp.Id_Question, gp.Id_Type, gp.Question, gp.Has_Time, gp.Time })
                    .Select(s => new
                    {
                        s.Key.Id_Question,
                        s.Key.Id_Type,
                        s.Key.Question,
                        s.Key.Has_Time,
                        s.Key.Time,
                        Answers = s.Where(w => w.Id_Question == s.Key.Id_Question).Select(
                            ss => new
                            {
                                ss.Id_Answer,
                                ss.Answer
                            }).ToList()
                    });


                List<int> takeTen = ShuffleList<int>(result.Select(s => s.Id_Question).ToList(), 10);

                if(takeTen.Count == 0)
                {
                    temp_AspNetUsersTests.Id_StatusTest = 3;
                    temp_AspNetUsersTests.LastUpdate = DateTime.Now;

                    aspNetIdentityEntities.SaveChanges();
                }

                return JsonConvert.SerializeObject(result.Where(w => takeTen.Contains(w.Id_Question)));
            }
        }

        public string SetTechnicalTest(int Id, Dictionary<string, string> keyValuePairs)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                keyValuePairs.ToList().ForEach(
                    fe => aspNetIdentityEntities.Temp_AspNetUsersTests_Details.Add(
                        new Temp_AspNetUsersTests_Details()
                        {
                            Id_UserTest = Id,
                            Id_Question = Convert.ToInt32(fe.Key),
                            Answer = fe.Value
                        }));

                aspNetIdentityEntities.SaveChanges();

                Temp_AspNetUsersTests temp_AspNetUsersTests = aspNetIdentityEntities.Temp_AspNetUsersTests.Where(w => w.Id_UserTest == Id).FirstOrDefault();
                temp_AspNetUsersTests.Id_StatusTest = 2;
                temp_AspNetUsersTests.LastUpdate = DateTime.Now;

                aspNetIdentityEntities.SaveChanges();

                return GetTechnicalTestByTestId(Id);
            }
        }

        private List<E> ShuffleList<E>(List<E> inputList, int outputNumber)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList.Take(outputNumber).ToList(); //return the new random list
        }



        public void TestsAssignById(string Id)
        {
            using (AspNetIdentityEntities aspNetIdentityEntities = new AspNetIdentityEntities())
            {
                List<int> testIds = aspNetIdentityEntities.CT_Tests.Select(s => s.Id_Test).ToList();

                foreach (int testId in testIds)
                {
                    aspNetIdentityEntities.Temp_AspNetUsersTests.Add(
                        new Temp_AspNetUsersTests()
                        {
                            Id_User = Id,
                            Id_Test = testId,
                            CreationDate = DateTime.Now,
                            LastUpdate = DateTime.Now,
                            Id_StatusTest = 1
                        });
                }

                if (testIds.Count > 0)
                    aspNetIdentityEntities.SaveChanges();
            }
        }
    }
}