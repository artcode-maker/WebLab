using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace WebLab.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 2"},
            new MenuItem{ Controller="LegalService", Action="Index", Text="Каталог"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var area = ViewContext.RouteData.Values["area"];
            var page = ViewContext.RouteData.Values["page"];
            foreach (var item in _menuItems)
            {
                bool _matchController = controller?.Equals(item.Controller) ?? false;
                var _matchArea = area?.Equals(item.Area) ?? false;
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }    
}
