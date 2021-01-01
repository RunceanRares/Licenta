using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatie.Model;
using Aplicatie.Models;

namespace Aplicatie.Pages.Shared
{
    public class EditModel : PageModel
    {
        private readonly Aplicatie.Models.AplicatieContext _context;

        public EditModel(Aplicatie.Models.AplicatieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Incercare Incercare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Incercare = await _context.Incercare.FirstOrDefaultAsync(m => m.ID == id);

            if (Incercare == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Incercare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncercareExists(Incercare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IncercareExists(int id)
        {
            return _context.Incercare.Any(e => e.ID == id);
        }
    }
}
