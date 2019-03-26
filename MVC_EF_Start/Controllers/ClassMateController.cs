using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web;


namespace MVC_EF_Start.Controllers
{
    public class ClassMateController : Controller
    {

        public ApplicationDbContext dbContext;

        public ClassMateController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IQueryable<Food> GetFoods()
        {
            return dbContext.Set<Food>();
        }

        public IQueryable<Vacation> GetVacations()
        {
            return dbContext.Set<Vacation>();
        }

        public IQueryable<IdealSaturday> GetIdealSaturdays()
        {
            return dbContext.Set<IdealSaturday>();
        }
        public IQueryable<EmailAddress> GetEmailAddress()
        {
            return dbContext.Set<EmailAddress>();
        }
        public async Task<ViewResult> HandleForm()
        {
            ClassMateQuestions classMateQuestions = new ClassMateQuestions();
            List<Food> allfoods = GetFoods().ToList();
            List<Vacation> vacations = GetVacations().ToList();
            List<IdealSaturday> idealSaturdays = GetIdealSaturdays().ToList();
            classMateQuestions.saturdays = idealSaturdays;
            classMateQuestions.vacations = vacations;
            classMateQuestions.foods = allfoods;
            return View(classMateQuestions);
        }

        public async Task<String> SendEmail()
        {

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rishiraj@mail.usf.edu", "Group4App");
            var subject = "This is a test";
            var to = new EmailAddress();

            List<ClassMate> emails = dbContext.ClassMates.ToList();

            foreach (ClassMate cl in emails)
            {
                //cl.email
                to = new EmailAddress(cl.email.ToString(), "Testing");
                
            }
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine("Emailed" + response.ToString());
            return response.ToString();

            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);
            //Console.WriteLine("Emailed" + response.ToString());
            //return response.ToString();


        }



        public async Task<ViewResult> CreateClassMates()
        {
            //loadAndSaveCsvFile();
            //loadFood();
            loadVacations();
            loadIdealSaturdays();
            return View();
        }

        public void loadIdealSaturdays()
        {
            using (var reader = new StreamReader(@"C:\usf\idealsaturday.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    IdealSaturday saturday = new IdealSaturday();
                    saturday.idealSaturday = values[0];
                    dbContext.IdealSaturdays.Add(saturday);
                    dbContext.SaveChanges();
                }
            }
        }

        public void loadVacations()
        {
            using (var reader = new StreamReader(@"C:\usf\vacations.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Vacation vacation = new Vacation();
                    vacation.vacation = values[0];
                    dbContext.Vacations.Add(vacation);
                    dbContext.SaveChanges();
                }
            }
        }

        public void loadFood()
        {
            using (var reader = new StreamReader(@"C:\usf\food.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Food food = new Food();
                    food.food = values[0];
                    dbContext.Foods.Add(food);
                    dbContext.SaveChanges();
                }
            }
        }




        public void loadAndSaveCsvFile()
        {
            using (var reader = new StreamReader(@"C:\usf\Contact.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    String studentName = values[0];
                    String studentemail = values[1];
                    ClassMate classMate = new ClassMate();
                    classMate.fullname = studentName;
                    classMate.email = studentemail;
                    classMate.loginhash = studentemail.GetHashCode().ToString();
                    dbContext.ClassMates.Add(classMate);
                    dbContext.SaveChanges();

                }
            }
        }



    }




}



