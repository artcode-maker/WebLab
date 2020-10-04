using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebLab.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLab.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> listDemo;
        public HomeController()
        {
            listDemo = new List<ListDemo>
            {
                new ListDemo { ListItemValue = 1, ListItemText = "Item 1"},
                new ListDemo { ListItemValue = 2, ListItemText = "Item 2"},
                new ListDemo { ListItemValue = 3, ListItemText = "Item 3"}
            };
        }
        public ViewResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            ViewData["lst"] = new SelectList(listDemo, "ListItemValue", "ListItemText");
            return View();
        }
    }

    public class ListDemo
    {
        public int ListItemValue { get; set; }
        public string ListItemText { get; set; }
    }
}
