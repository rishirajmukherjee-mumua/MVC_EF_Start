using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> GetSpotifyData()
        {
            SpotifyDataAccess spotifyDataAccess = new SpotifyDataAccess("078c7392711e4b978d6a3bd21984c93c", "8b7f7c3b96454fcd8b42193a179ca19b");
            Token token = await spotifyDataAccess.GetToken();
            ViewData["token"] = token;
            Object objectData = await spotifyDataAccess.SearchArtistAndTrack(token.AccessToken, "Linkin");
            return View();
        }


        public async Task<ViewResult> DatabaseOperations()
        {
            // CREATE operation
            Company MyCompany = new Company();
            MyCompany.symbol = "MCOB";
            MyCompany.name = "ISM";
            MyCompany.date = "ISM";
            MyCompany.isEnabled = true;
            MyCompany.type = "ISM";
            MyCompany.iexId = "ISM";

            Equity MyCompanyQuote1 = new Equity();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote1.date = "11-23-2018";
            MyCompanyQuote1.open = 46.13F;
            MyCompanyQuote1.high = 47.18F;
            MyCompanyQuote1.low = 44.67F;
            MyCompanyQuote1.close = 47.01F;
            MyCompanyQuote1.volume = 37654000;
            MyCompanyQuote1.unadjustedVolume = 37654000;
            MyCompanyQuote1.change = 1.43F;
            MyCompanyQuote1.changePercent = 0.03F;
            MyCompanyQuote1.vwap = 9.76F;
            MyCompanyQuote1.label = "Nov 23";
            MyCompanyQuote1.changeOverTime = 0.56F;
            MyCompanyQuote1.symbol = "MCOB";

            Equity MyCompanyQuote2 = new Equity();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote2.date = "11-23-2018";
            MyCompanyQuote2.open = 46.13F;
            MyCompanyQuote2.high = 47.18F;
            MyCompanyQuote2.low = 44.67F;
            MyCompanyQuote2.close = 47.01F;
            MyCompanyQuote2.volume = 37654000;
            MyCompanyQuote2.unadjustedVolume = 37654000;
            MyCompanyQuote2.change = 1.43F;
            MyCompanyQuote2.changePercent = 0.03F;
            MyCompanyQuote2.vwap = 9.76F;
            MyCompanyQuote2.label = "Nov 23";
            MyCompanyQuote2.changeOverTime = 0.56F;
            MyCompanyQuote2.symbol = "MCOB";


            UpperManagement upperManagement = new UpperManagement();
            upperManagement.Salary = "10000000";
            upperManagement.JobTitle = "CEO";
            upperManagement.JoinDate = "2018-01-01";
            upperManagement.Symbol = "MCOB";
            upperManagement.Name = "Elon Musk";

            dbContext.Companies.Add(MyCompany);
            dbContext.Equities.Add(MyCompanyQuote1);
            dbContext.Equities.Add(MyCompanyQuote2);
            dbContext.UpperManagements.Add(upperManagement);

            dbContext.SaveChanges();

            // READ operation
            Company CompanyRead1 = dbContext.Companies
                                    .Where(c => c.symbol == "MCOB")
                                    .First();

            Company CompanyRead2 = dbContext.Companies
                                    .Include(c => c.Equities)
                                    .Where(c => c.symbol == "MCOB")
                                    .First();

            // UPDATE operation
            CompanyRead1.iexId = "MCOB";
            dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            dbContext.Companies.Remove(CompanyRead1);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}