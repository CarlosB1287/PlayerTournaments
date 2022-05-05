using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerTournaments.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Player.Any())
                {
                    return;
                }

                List<Player> players = new List<Player> {
                    new Player {FirstName="TIGER", LastName="WOODS"},
                    new Player {FirstName="RORY", LastName="MCLLROY"},
                    new Player {FirstName="JON", LastName="RAHM"},
                    new Player {FirstName="JUSTIN", LastName="THOMAS"},
                    new Player {FirstName="COLLIN", LastName="MORIKAWA"},
                    new Player {FirstName="DUSTIN", LastName="JOHNSON"},
                    new Player {FirstName="HIDEKI", LastName="MATSUYAMA"},
                    new Player {FirstName="JORDAN", LastName="SPIETH"},
                    new Player {FirstName="PATRICK", LastName="CANTLAY"},
                    new Player {FirstName="TOMMY", LastName="FLEETWOOD"},
                    new Player {FirstName="CAMERON", LastName="SMITH"},
                    new Player {FirstName="SCOTTIE", LastName="SCHEFFLER"},
                    new Player {FirstName="DANIEL", LastName="BERGER"},
                    new Player {FirstName="ADAM", LastName="SCOTT"},
                    new Player {FirstName="WEBB", LastName="SIMPSON"},
                    new Player {FirstName="SAM", LastName="BURNS"},
                    new Player {FirstName="BROOKS", LastName="KOEPKA"},
                    new Player {FirstName="MATT", LastName="FITZPATRICK"},
                    new Player {FirstName="PHIL", LastName="MICKELSON"},
                    new Player {FirstName="JUSTIN", LastName="ROSE"},
                    new Player {FirstName="SHANE", LastName="LOWRY"},
                    new Player {FirstName="BILLY", LastName="HORSCHEL"},
                    new Player {FirstName="SERGIO", LastName="GARCIA"},
                    new Player {FirstName="TONY", LastName="FINAU"},
                    new Player {FirstName="MATT", LastName="KUCHAR"},
                    new Player {FirstName="ABRAHAM", LastName="ANCER"},
                    new Player {FirstName="LOUIS", LastName="OOSTHIZEN"},
                    new Player {FirstName="TYRREL", LastName="HATTON"},
                    new Player {FirstName="HAROLLD", LastName="VARNER III"},
                    new Player {FirstName="JASON", LastName="DAY"},
                    new Player {FirstName="RICKIE", LastName="FOWLER"},
                };
                context.AddRange(players);
                context.SaveChanges();
    
                List<Tournament> tournaments = new List<Tournament> {
                    new Tournament {Description = "TOUR CHAMPIONSHIP"},
                    new Tournament {Description = "THE OPEN"},
                    new Tournament {Description = "U.S. OPEN"},
                    new Tournament {Description = "PGA CHAMPIONSHIP"},
                    new Tournament {Description = "PHOENIX OPEN"},
                    new Tournament {Description = "THE PLAYERS"},
                    new Tournament {Description = "MASTERS"},
                };
                context.AddRange(tournaments);
                context.SaveChanges();

                List<PlayerTournament> participation = new List<PlayerTournament> {
                    new PlayerTournament {TournamentID = 1, PlayerID = 4,Score=68},
                    new PlayerTournament {TournamentID = 1, PlayerID = 6,Score=69},
                    new PlayerTournament {TournamentID = 1, PlayerID = 3,Score=71},
                    new PlayerTournament {TournamentID = 1, PlayerID = 17,Score=67},
                    new PlayerTournament {TournamentID = 1, PlayerID = 8,Score=69},
                    new PlayerTournament {TournamentID = 1, PlayerID = 18,Score=72},
                    new PlayerTournament {TournamentID = 1, PlayerID = 5,Score=75},
                    new PlayerTournament {TournamentID = 1, PlayerID = 16,Score=70},
                    new PlayerTournament {TournamentID = 1, PlayerID = 2,Score=68},

                    new PlayerTournament {TournamentID = 2, PlayerID = 3,Score=63},
                    new PlayerTournament {TournamentID = 2, PlayerID = 9,Score=65},
                    new PlayerTournament {TournamentID = 2, PlayerID = 19,Score=76},
                    new PlayerTournament {TournamentID = 2, PlayerID = 5,Score=71},
                    new PlayerTournament {TournamentID = 2, PlayerID = 7,Score=70},
                    new PlayerTournament {TournamentID = 2, PlayerID = 2,Score=67},
                    new PlayerTournament {TournamentID = 2, PlayerID = 11,Score=67},
                    new PlayerTournament {TournamentID = 2, PlayerID = 18,Score=68},
                    new PlayerTournament {TournamentID = 2, PlayerID = 13,Score=69},  

                    new PlayerTournament {TournamentID = 3, PlayerID = 29,Score=70},
                    new PlayerTournament {TournamentID = 3, PlayerID = 26,Score=66},
                    new PlayerTournament {TournamentID = 3, PlayerID = 23,Score=67},
                    new PlayerTournament {TournamentID = 3, PlayerID = 27,Score=69},
                    new PlayerTournament {TournamentID = 3, PlayerID = 28,Score=71},
                    new PlayerTournament {TournamentID = 3, PlayerID = 18,Score=75},
                    new PlayerTournament {TournamentID = 3, PlayerID = 25,Score=77},
                    new PlayerTournament {TournamentID = 3, PlayerID = 6,Score=67},
                    new PlayerTournament {TournamentID = 3, PlayerID = 22,Score=66},

                    new PlayerTournament {TournamentID = 4, PlayerID = 9,Score=68},
                    new PlayerTournament {TournamentID = 4, PlayerID = 12,Score=66},
                    new PlayerTournament {TournamentID = 4, PlayerID = 18,Score=67},
                    new PlayerTournament {TournamentID = 4, PlayerID = 25,Score=69},
                    new PlayerTournament {TournamentID = 4, PlayerID = 27,Score=73},
                    new PlayerTournament {TournamentID = 4, PlayerID = 24,Score=71},
                    new PlayerTournament {TournamentID = 4, PlayerID = 11,Score=74},
                    new PlayerTournament {TournamentID = 4, PlayerID = 28,Score=70},
                    new PlayerTournament {TournamentID = 4, PlayerID = 13,Score=66},   

                    new PlayerTournament {TournamentID = 5, PlayerID = 7,Score=65},
                    new PlayerTournament {TournamentID = 5, PlayerID = 6,Score=68},
                    new PlayerTournament {TournamentID = 5, PlayerID = 23,Score=67},
                    new PlayerTournament {TournamentID = 5, PlayerID = 17,Score=67},
                    new PlayerTournament {TournamentID = 5, PlayerID = 28,Score=74},
                    new PlayerTournament {TournamentID = 5, PlayerID = 19,Score=72},
                    new PlayerTournament {TournamentID = 5, PlayerID = 15,Score=71},
                    new PlayerTournament {TournamentID = 5, PlayerID = 26,Score=69},
                    new PlayerTournament {TournamentID = 5, PlayerID = 29,Score=64},

                    new PlayerTournament {TournamentID = 6, PlayerID = 23,Score=72},
                    new PlayerTournament {TournamentID = 6, PlayerID = 29,Score=69},
                    new PlayerTournament {TournamentID = 6, PlayerID = 1,Score=68},
                    new PlayerTournament {TournamentID = 6, PlayerID = 25,Score=69},
                    new PlayerTournament {TournamentID = 6, PlayerID = 17,Score=70},
                    new PlayerTournament {TournamentID = 6, PlayerID = 21,Score=73},
                    new PlayerTournament {TournamentID = 6, PlayerID = 19,Score=73},
                    new PlayerTournament {TournamentID = 6, PlayerID = 18,Score=74},
                    new PlayerTournament {TournamentID = 6, PlayerID = 26,Score=71}, 

                    new PlayerTournament {TournamentID = 7, PlayerID = 7,Score=66},
                    new PlayerTournament {TournamentID = 7, PlayerID = 29,Score=65},
                    new PlayerTournament {TournamentID = 7, PlayerID = 24,Score=68},
                    new PlayerTournament {TournamentID = 7, PlayerID = 6,Score=64},
                    new PlayerTournament {TournamentID = 7, PlayerID = 17,Score=70},
                    new PlayerTournament {TournamentID = 7, PlayerID = 23,Score=74},
                    new PlayerTournament {TournamentID = 7, PlayerID = 28,Score=73},
                    new PlayerTournament {TournamentID = 7, PlayerID = 18,Score=68},
                    new PlayerTournament {TournamentID = 7, PlayerID = 13,Score=72}, 
                };
                context.AddRange(participation);

                context.SaveChanges();
            }
        }
    }
}