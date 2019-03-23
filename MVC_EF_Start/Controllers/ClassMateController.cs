using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class ClassMateController : Controller
    {

        public ApplicationDbContext dbContext;

        public ClassMateController(ApplicationDbContext context)
        {
            dbContext = context;
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



