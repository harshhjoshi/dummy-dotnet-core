using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("time")]
        public IActionResult Time()
        {
            string nextStatus = "alla fine";
            DateTime mo = DateTime.Now;
            DateTime leDiciotto = DateTime.Parse("18:00");
            TimeSpan quantoManca = leDiciotto.Subtract(mo);
            if( mo.Hour > 18 ){
                DateTime leNove = DateTime.Parse("09:00").AddDays(1);
                quantoManca = leNove.Subtract(mo);
                nextStatus = "all'inizio";
            }
            int hours = quantoManca.Hours;
            int minutes = quantoManca.Minutes;
            int seconds = quantoManca.Seconds;
            string hoursDescription = hours == 1 ? "ora" : "ore";
            string minutesDescription = minutes == 1 ? "minuto" : "minuti";
            string secondsDescription = seconds == 1 ? "secondo" : "secondi";
            string risultato = String.Format( "Mancano {0} {1}, {2} {3}, {4} {5} {6}!",
                hours, hoursDescription,
                minutes, minutesDescription,
                seconds, secondsDescription,
                nextStatus );
            return Json( new { result = risultato });
        }

        [HttpGet]
        [ActionName("content")]
        public IActionResult GetFileContent()
        {
            string content = System.IO.File.ReadAllText("/Users/Simone/Projects/EdilportaleNotes/Module D/07032017.md");
            return Json( new { content = content } );
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
