using Microsoft.AspNetCore.Identity;
using Quiztastic.Models.Auth;
using Quiztastic.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiztastic.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                          UserManager<AppUser> userManager,
                          RoleManager<AppRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Member";
            string desc2 = "This is the regular members role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new AppRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new AppRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("a@a.a") == null)
            {
                var user = new AppUser
                {
                    UserName = "a",
                    Email = "a@a.a",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Street = "Granville St",
                    City = "Vancouver",
                    Province = "BC",
                    PostalCode = "V5U K8I",
                    Country = "Canada",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }

            if (await userManager.FindByNameAsync("m@m.m") == null)
            {
                var user = new AppUser
                {
                    UserName = "m",
                    Email = "m@m.m",
                    FirstName = "Madeline",
                    LastName = "Barker",
                    Street = "Vermont St",
                    City = "Surrey",
                    Province = "BC",
                    PostalCode = "V1P I5T",
                    Country = "Canada",
                    PhoneNumber = "7788951456",
                    BadgeBookId = "Maddy1"
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role2);
                }
            }

            if (context.Quizzes != null && context.Quizzes.Any())
            {
                return; // DB Seeded
            }

            var quiz = new Quiz
            {
                QuizId = "Javascript",
                QuizName = "Javascript",
                NumberOfQuestions = 5
            };

            var q1 = new Question
            {
                QuestionId = "JS-Q1",
                QuestionContent = "Inside which HTML element do we put the JavaScript?",
                QuizId = "Javascript",
            };

            var q2 = new Question
            {
                QuestionId = "JS-Q2",
                QuestionContent = "Inside which HTML element do we put the JavaScript?",
                QuizId = "Javascript",
            };

            var q3 = new Question
            {
                QuestionId = "JS-Q3",
                QuestionContent = "Inside which HTML element do we put the JavaScript?",
                QuizId = "Javascript",
            };

            var q4 = new Question
            {
                QuestionId = "JS-Q4",
                QuestionContent = "Inside which HTML element do we put the JavaScript?",
                QuizId = "Javascript",
            };

            var q5 = new Question
            {
                QuestionId = "JS-Q5",
                QuestionContent = "Inside which HTML element do we put the JavaScript?",
                QuizId = "Javascript",
            };
        }
    }
}
