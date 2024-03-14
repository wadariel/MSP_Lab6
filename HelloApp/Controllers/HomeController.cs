using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Emit;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CurrentTime"] = DateTime.Now;
            ViewData["Greeting"] = GetGreeting();
            return View();

        }

        public IActionResult Greet(string name, int age)
        {
            ViewData["CurrentTime"] = DateTime.Now;
            ViewData["Greeting"] = GetGreeting(name, age);
            return View("Index");
        }

        private string GetGreeting()
        {
            var hour = DateTime.Now.Hour;
            if (hour < 11)
                return "������ ����!";
            if (hour < 17)
                return "������ ����!";
            if (hour < 21)
                return "������ �����!";
            return "������ ����!";
        }

        private string GetGreeting(string name, int age)
        {
            return $"������, {name}! ���� {age} ���.";
        }

        [HttpGet]
        public async Task Form()
        {
            string content = @"<form method='post'>
                <label>Name:</label><br />
                <input name='name' /><br />
                <label> Age:</label><br />
                <input type='number' name='age' /><br />
                <input type='submit' value='Send' />
               </form>";
            Response.ContentType = "text/html; charset=utf-8";
            await Response.WriteAsync(content);
        }
        [HttpPost]
        public string Form(string name, int age)
        {
            return $"Name: {name}, Age: {age}";
        }

        public ViewResult New()
        {
            int hour = DateTime.Now.Hour;
            string viewHello = hour < 11 ? "������ ����" : "������ ����";
            return View("MyView", viewHello);
        }
    }
}
