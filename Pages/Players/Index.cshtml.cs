using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlayerTournaments.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        // Paging support
        // PageNum is the current page number we are on
        // PageSize is how many records will be displayed per page. 
        // PageNum needs BindProperty because the user decides which page we are on.
        // The user selects the page number
        // SupportsGet = true allows us to pass the PageNum through the URL with an HTTP Get Parameter 
        // This is necessary, because page numbers are not passed through normal forms
        [BindProperty(SupportsGet = true)]

        public int PageNum {get; set;} = 1;

        public int PageSize {get; set;} = 10;

         // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        // Second sorting technique with a SelectList
        public SelectList SortList {get; set;}

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            var query = _context.Player.Select(p => p);
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "FirstName Ascending", Value = "first_asc" },
                new SelectListItem { Text = "FirstName Descending", Value = "first_desc"}
            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                // If user selected "first_asc", modify query to sort by first name ascending order
                case "first_asc": 
                    query = query.OrderBy(p => p.FirstName);
                    break;
                // If user selected "first_desc", modify query to sort by first name descending
                case "first_desc":
                    query = query.OrderByDescending(p => p.FirstName);
                    break;
                // Add more sorting cases as needed
            }

        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        
        CurrentFilter = searchString;
        
        IQueryable<Player> PlayersName = from s in query
                                        select s;
        if (!String.IsNullOrEmpty(searchString))
        {
            PlayersName = PlayersName.Where(s => s.LastName.Contains(searchString)
                                   || s.FirstName.Contains(searchString));
        }

        switch (sortOrder)
        {
            case "name_desc":
                PlayersName = PlayersName.OrderByDescending(s => s.LastName);
                break;
            default:
                PlayersName = PlayersName.OrderBy(s => s.LastName);
                break;
        }

            Player = await PlayersName.Skip((PageNum-1)*PageSize).Take(PageSize).Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Tournament).ToListAsync();
        }
    }
}
