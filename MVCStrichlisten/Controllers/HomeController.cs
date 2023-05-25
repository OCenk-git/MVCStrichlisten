using Microsoft.AspNetCore.Mvc;
using MVCStrichlisten.Models;
using System.Diagnostics;

namespace MVCStrichlisten.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Benutzer> alleBenutzer = new List<Benutzer> { new Benutzer() 
        { 
            Id = 1, Name = "Tim" }, new Benutzer() 
            { 
                Id = 2, Name = "Lisa" 
            } 
        };

        public IActionResult Index()
        {
            return View(alleBenutzer);
        }

        public PartialViewResult ShowUsers()
        {
            return PartialView("_ShowUsers", alleBenutzer);
        }

        public IActionResult AddUser(string newUsername)
        {
            alleBenutzer.Add(new Benutzer() { Id = alleBenutzer.Count + 1, Name = newUsername });

            return PartialView("_ShowUsers", alleBenutzer);
        }
        
        public IActionResult DeleteUser(int id)
        {
            Benutzer benutzer = alleBenutzer.Find(b => b.Id == id);

            if (benutzer != null)
            {
                alleBenutzer.Remove(benutzer);
            }

            return PartialView("_ShowUsers", alleBenutzer);
        }

        public IActionResult ChangeUserName(int userId, string username)
        {
            Benutzer benutzer = alleBenutzer.Find(b => b.Id == userId);

            if (benutzer != null)
            {
                benutzer.Name = username;
            }

            return PartialView("_ShowUsers", alleBenutzer);
        }

        public IActionResult Up(string username)
        {
            Benutzer benutzer = alleBenutzer.Find(b => b.Name == username);

            if (benutzer != null)
            {
                benutzer.Anzahl++;
            }

            return PartialView("_ShowUsers", alleBenutzer);
        }

        public IActionResult Down(string username)
        {
            Benutzer benutzer = alleBenutzer.Find(b => b.Name == username);

            if (benutzer?.Anzahl > 0)
            {
                benutzer.Anzahl--;
            }

            return PartialView("_ShowUsers", alleBenutzer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}