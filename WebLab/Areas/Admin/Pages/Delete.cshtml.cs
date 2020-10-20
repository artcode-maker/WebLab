using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebLab.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(WebLab.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LegalService LegalService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalService = await _context.LegalServices.FirstOrDefaultAsync(m => m.LegalServiceId == id);
            ViewData["LegalServiceGroupId"] = new SelectList(_context.LegalServiceGroups, "LegalServiceGroupId", "GroupName");

            if (LegalService == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LegalService = await _context.LegalServices.FindAsync(id);

            if (LegalService != null)
            {
                _context.LegalServices.Remove(LegalService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
