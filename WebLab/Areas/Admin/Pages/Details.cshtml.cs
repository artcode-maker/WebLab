using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebLab.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebLab.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public LegalService LegalService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalService = await _context.LegalServices.FirstOrDefaultAsync(m => m.LegalServiceId == id);

            if (LegalService == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
