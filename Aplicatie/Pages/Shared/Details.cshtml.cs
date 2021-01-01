using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatie.Model;
using Aplicatie.Models;

namespace Aplicatie.Pages.Shared
{
    public class DetailsModel : PageModel
    {
        private readonly Aplicatie.Models.AplicatieContext _context;

        public DetailsModel(Aplicatie.Models.AplicatieContext context)
        {
            _context = context;
        }

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
    }
}
