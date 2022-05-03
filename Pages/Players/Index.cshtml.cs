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
    public class IndexModel : PageModel
    {
        private readonly PlayerTournaments.Models.Context _context;

        public IndexModel(PlayerTournaments.Models.Context context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; }

        public async Task OnGetAsync()
        {
            Player = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).ToListAsync();
        }
    }
}
