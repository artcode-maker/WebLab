using System;
using System.Collections.Generic;
using System.Text;

namespace WebLab.DAL.Entities
{
    public class LegalService
    {
        public int LegalServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }

        public int LegalServiceGroupId { get; set; }
    }

    public class LegalServiceGroup
    {
        public int LegalServiceGroupId { get; set; }
        public string GroupName { get; set; }
        public List<LegalService> LegalServices { get; set; }
    }
}
