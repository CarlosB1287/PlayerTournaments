using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlayerTournaments.Models;

namespace PlayerTournaments.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly PlayerTournaments.Models.Context _context;

        public DetailsModel(PlayerTournaments.Models.Context context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.FirstOrDefaultAsync(m => m.PlayerID == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
