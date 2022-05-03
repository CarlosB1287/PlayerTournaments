using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayerTournaments.Models
{
    public class Player
    {
        public int PlayerID {get; set;}
        [Display(Name = "First Name")]
        [Required]
        public string FirstName {get; set;}
        [Display(Name = "Last Name")]
        [Required]
        public string LastName {get; set;}
        public List<PlayerTournament> PlayerTournaments{get; set;} // Navigation Property. Player can have MANY PlayerTournaments
    }
}