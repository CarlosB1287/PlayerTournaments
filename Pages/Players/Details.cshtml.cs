using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlayerTournaments.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlayerTournaments.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly PlayerTournaments.Models.Context _context;

        public DetailsModel(PlayerTournaments.Models.Context context, ILogger<DetailsModel> logger)
        {
            
            _logger = logger;
            _context = context;
        }

        public Player Player { get; set; }
        [BindProperty]
        public int TournamentIdToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Tournament")]
        public int TournamentIdToAdd {get; set;}
        public List<Tournament> AllTournaments {get; set;}
        public SelectList TournamentsDropDown {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data with .Include and .ThenInclude
            Player = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).FirstOrDefaultAsync(m => m.PlayerID == id);
            AllTournaments = await _context.Tournament.ToListAsync();
            TournamentsDropDown = new SelectList(AllTournaments, "TournamentID", "Description");

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteTournamentAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PlayerId {id}, DROP Tournament {TournamentIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).FirstOrDefaultAsync(m => m.PlayerID == id);
            //AllTournaments = await _context.Tournament.ToListAsync();
            //TournamentsDropDown = new SelectList(AllTournaments, "TournamentID", "Description");
            
            if (Player == null)
            {
                return NotFound();
            }

            PlayerTournament tournamentToDrop = _context.PlayerTournament.Find(TournamentIdToDelete, id.Value);

            if (tournamentToDrop != null)
            {
                _context.Remove(tournamentToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Player NOT participating in this Tournament");
            }

            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PlayerId {id}, ADD Tournament {TournamentIdToAdd}");
            if (TournamentIdToAdd == 0)
            {
                ModelState.AddModelError("TournamentIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).FirstOrDefaultAsync(m => m.PlayerID == id);            
            AllTournaments = await _context.Tournament.ToListAsync();
            TournamentsDropDown = new SelectList(AllTournaments, "TournamentID", "Description");

            if (Player == null)
            {
                return NotFound();
            }

            if (!_context.PlayerTournament.Any(sc => sc.TournamentID == TournamentIdToAdd && sc.PlayerID == id.Value))
            {
                PlayerTournament TournamentToAdd = new PlayerTournament { PlayerID = id.Value, TournamentID = TournamentIdToAdd};
                _context.Add(TournamentToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Player already participating in the Tournament");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    }
}
