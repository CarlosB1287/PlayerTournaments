using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlayerTournaments.Models;
using Microsoft.Extensions.Logging;

namespace PlayerTournaments.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly PlayerTournaments.Models.Context _context;
        private readonly ILogger _logger;

        public EditModel(PlayerTournaments.Models.Context context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Player Player { get; set; } // This is the specific Player you are editing
        public List<Tournament> Tournaments {get; set;} // This is a list of all Tournaments

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data using Include and ThenInclude
            Player = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).FirstOrDefaultAsync(m => m.PlayerID == id);
            // Get a list of all Tournaments. This list is used to make the checkboxes
            Tournaments = _context.Tournament.ToList();

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedTournaments)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Player).State = EntityState.Modified;
            // Find the Player you want to update and update all their "normal properties" (FirstName and LastName)
            var PlayerToUpdate = await _context.Player.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).FirstOrDefaultAsync(m => m.PlayerID == Player.PlayerID);
            PlayerToUpdate.FirstName = Player.FirstName;
            PlayerToUpdate.LastName = Player.LastName;

            // Separate method to update the Tournaments because it can get complex
            UpdatePlayerTournaments(selectedTournaments, PlayerToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerID))
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

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerID == id);
        }

        private void UpdatePlayerTournaments(int[] selectedTournaments, Player PlayerToUpdate)
        {
            if (selectedTournaments == null)
            {
                PlayerToUpdate.PlayerTournaments = new List<PlayerTournament>();
                return;
            }

            List<int> currentTournaments = PlayerToUpdate.PlayerTournaments.Select(c => c.TournamentID).ToList();
            List<int> selectedTournamentsList = selectedTournaments.ToList();

            foreach (var Tournament in _context.Tournament)
            {
                if (selectedTournamentsList.Contains(Tournament.TournamentID))
                {
                    if (!currentTournaments.Contains(Tournament.TournamentID))
                    {
                        // Add Tournament here
                        PlayerToUpdate.PlayerTournaments.Add(
                            new PlayerTournament { PlayerID = PlayerToUpdate.PlayerID, TournamentID = Tournament.TournamentID }
                        );
                        _logger.LogWarning($"Player {PlayerToUpdate.FirstName} {PlayerToUpdate.LastName} ({PlayerToUpdate.PlayerID}) - ADD {Tournament.TournamentID} {Tournament.Description}");
                    }
                }
                else
                {
                    if (currentTournaments.Contains(Tournament.TournamentID))
                    {
                        // Remove Tournament here
                        PlayerTournament TournamentToRemove = PlayerToUpdate.PlayerTournaments.SingleOrDefault(s => s.TournamentID == Tournament.TournamentID);
                        _context.Remove(TournamentToRemove);
                        _logger.LogWarning($"Player {PlayerToUpdate.FirstName} {PlayerToUpdate.LastName} ({PlayerToUpdate.PlayerID}) - DROP {Tournament.TournamentID} {Tournament.Description}");
                    }
                }
            }
        }
    }
}