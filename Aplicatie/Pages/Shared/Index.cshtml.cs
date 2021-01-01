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
    public class IndexModel : PageModel
    {
        private readonly Aplicatie.Models.AplicatieContext _context;

        public IndexModel(Aplicatie.Models.AplicatieContext context)
        {
            _context = context;
        }

        public IList<Incercare> Incercare { get;set; }

        public async Task OnGetAsync()
        {
            Incercare = await _context.Incercare.ToListAsync();
        }
    }
}
