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
            loadAndSaveCsvFile();
            return View();
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



