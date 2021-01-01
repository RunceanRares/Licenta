using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplicatie.Model;
using Aplicatie.Models;

namespace Aplicatie.Pages.Shared
{
    public class CreateModel : PageModel
    {
        private readonly Aplicatie.Models.AplicatieContext _context;

        public CreateModel(Aplicatie.Models.AplicatieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Incercare Incercare { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Incercare.Add(Incercare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}