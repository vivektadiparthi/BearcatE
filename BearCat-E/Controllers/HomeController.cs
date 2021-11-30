using BearCat_E.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BearCat_E.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Event> listEvent = new List<Event>();
        Event e = new Event();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var connection = new MySqlConnection("server=us-cdbr-east-04.cleardb.com;user=bb19bde4ce6489;password=229d41c3;database=heroku_f1e0783941a9cd9");


            connection.Open();
            
            using var command = new MySqlCommand("SELECT eventname, eventvenue, eventdate FROM bearcatevent WHERE event_id = 5;", connection);
            //using var cmd = new MySqlCommand("SELECT eventvenue FROM bearcatevent;", connection);
            using var reader =  command.ExecuteReader();
            

            while (reader.Read())
            {
                string value = reader.GetValue(0).ToString();
                string value2 = reader.GetValue(1).ToString();
                string value3 = reader.GetValue(2).ToString();
                e.eventname = value;
                e.eventplace = value2;
                e.eventdate = value3;
                //listEvent.Add(e);

            }

            return View(e);
            //  return View(listEvent); will return the object to View
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
