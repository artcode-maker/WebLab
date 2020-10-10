using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab.DAL.Entities;

namespace WebLab.Controllers
{
    public class LegalServiceController : Controller
    {
        List<LegalService> _legalServices;
        List<LegalServiceGroup> _serviceGroups;

        public LegalServiceController()
        {
            SetupData();
        }

        public IActionResult Index()
        {
            return View(_legalServices);
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
                }
            };
        }
    }
}
