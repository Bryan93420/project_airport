using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JC.MyAirport.EF;

namespace JC.MyAirport.Razor
{
    public class CreateModelBagage : PageModel
    {
        private readonly JC.MyAirport.EF.MyAirportContext _context;

        public CreateModelBagage(JC.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            var vols =
            _context.Vols.Select(v => new
               {
                   v.VolId,
                   Description = $"{v.Cie} {v.Lig} : {v.Dhc.ToShortDateString()}"
               })
               .ToList();
            /*vols.Insert(0, new { VolId = null, Description = "N/A" });*/
            /*            ViewData["VolId"] = new SelectList(_context.Vols, "VolId", "Cie");
            */
            ViewData["VolId"] = new SelectList(vols, "VolId", "Description");

          
            
            return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
