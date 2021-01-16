﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(ToDoController.GetAllTask), "ToDo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}