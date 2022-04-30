using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayerTournaments.Models
{
    public class Tournament
    {
        public int TournamentID {get; set;} // Primary Key
        [Required]
        public string Description {get; set;}
        public List<PlayerTournament> PlayerTournaments {get; set;} // Navigation Property. Tournament can have MANY PlayerTournaments
    }
    public class PlayerTournament
    {
        public int TournamentID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int PlayerID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Player Player {get; set;}  // Navigation Property. One Student per PlayerTournaments
        public Tournament Tournament {get; set;}    // Navigation Property. One Tournamnet per PlayerTournaments
    }
}