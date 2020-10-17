using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab.DAL.Entities;
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

        public LegalServiceController()
        {
            _pageSize = 3;
            SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var services = _legalServices.Where(s => !group.HasValue || s.LegalServiceGroupId == group.Value);
            ViewData["Groups"] = _serviceGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            //return View(ListViewModel<LegalService>.GetModel(services, pageNo, _pageSize));
            var model = ListViewModel<LegalService>.GetModel(services, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }

        private void SetupData()
        {
            _serviceGroups = new List<LegalServiceGroup>
            {
                new LegalServiceGroup
                {
                    LegalServiceGroupId = 1,
                    GroupName = "Консультации"
                },
                new LegalServiceGroup
                {
                    LegalServiceGroupId = 2,
                    GroupName = "Составление документов"
                },
                new LegalServiceGroup
                {
                    LegalServiceGroupId = 3,
                    GroupName = "Судебное представительство"
                }
            };

            _legalServices = new List<LegalService>
            {
                new LegalService
                {
                    LegalServiceId = 1,
                    Name = "Консультация по семейному праву",
                    Description = "Разъяснение по вопросам расторжения брака и раздела имущества",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 2,
                    Name = "Консультация по жилищному праву",
                    Description = "Разъяснение по вопросам выселения из квартиры или дома",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 3,
                    Name = "Составление искового заявления по семейному спору",
                    Description = "Исковые заявления по делам, возникающим из семейных правоотношений",
                    Price = 200M,
                    LegalServiceGroupId = 2,
                    Image = "document.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 4,
                    Name = "Составление искового заявления по жилищному спору",
                    Description = "Исковые заявления по делам, возникающим из жилищных правоотношений",
                    Price = 200M,
                    LegalServiceGroupId = 2,
                    Image = "document.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 5,
                    Name = "Представительство по семейным делам в суде",
                    Description = "Участие в качестве представителя по семейным делам в суде",
                    Price = 250M,
                    LegalServiceGroupId = 3,
                    Image = "court.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 6,
                    Name = "Представительство по жилищным делам в суде",
                    Description = "Участие в качестве представителя по семейным делам в суде",
                    Price = 250M,
                    LegalServiceGroupId = 3,
                    Image = "court.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 7,
                    Name = "Консультация по семейному праву",
                    Description = "Разъяснение по вопросам расторжения брака и раздела имущества",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 8,
                    Name = "Консультация по жилищному праву",
                    Description = "Разъяснение по вопросам выселения из квартиры или дома",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                }
            };
        }
    }
}
