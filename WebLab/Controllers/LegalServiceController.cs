using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab.DAL.Entities;
using WebLab.DAL.Data;
using WebLab.Models;
using Microsoft.AspNetCore.Http;
using WebLab.Extensions;


namespace WebLab.Controllers
{
    public class LegalServiceController : Controller
    {
        public List<LegalService> _legalServices;
        public List<LegalServiceGroup> _serviceGroups;
        public int _pageSize;
        private ApplicationDbContext _context;

        public LegalServiceController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var services = _context.LegalServices.Where(s => !group.HasValue || s.LegalServiceGroupId == group.Value);
            ViewData["Groups"] = _context.LegalServiceGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<LegalService>.GetModel(services, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
