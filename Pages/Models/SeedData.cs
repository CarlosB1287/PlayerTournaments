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

                List<Player> Players = new List<Player> {
                    new Player {FirstName="Tiger", LastName="Woods"},
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
                    new Player {FirstName="ADAM", LastName="RSCOTT"},
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
                    new Player {FirstName="LOIUS", LastName="OOSTHIZEN"},
                    new Player {FirstName="TYRREL", LastName="HATTON"},
                    new Player {FirstName="HAROLLD", LastName="VARNER III"},
                    new Player {FirstName="JASON", LastName="DAY"},
                    new Player {FirstName="RICKIE", LastName="FOWLER"},
                };
                context.AddRange(Players);

                List<Tournament> Tournaments = new List<Tournament> {
                    new Tournament {Description = "TOUR CHAMPIONSHIP"},
                    new Tournament {Description = "THE OPEN"},
                    new Tournament {Description = "U.S. OPEN"},
                    new Tournament {Description = "PGA CHAMPIONSHIP"},
                    new Tournament {Description = "PHOENIX OPEN"},
                    new Tournament {Description = "THE PLAYERS"},
                    new Tournament {Description = "MASTERS"},
                };
                context.AddRange(Tournaments);

                List<PlayerTournament> Participation = new List<PlayerTournament> {
                    new PlayerTournament {TournamentID = 1, PlayerID = 10},
                    new PlayerTournament {TournamentID = 1, PlayerID = 6},
                    new PlayerTournament {TournamentID = 1, PlayerID = 3},
                    new PlayerTournament {TournamentID = 1, PlayerID = 17},
                    new PlayerTournament {TournamentID = 1, PlayerID = 8},
                    new PlayerTournament {TournamentID = 1, PlayerID = 28},
                    new PlayerTournament {TournamentID = 1, PlayerID = 5},
                    new PlayerTournament {TournamentID = 1, PlayerID = 16},
                    new PlayerTournament {TournamentID = 1, PlayerID = 2},

                    new PlayerTournament {TournamentID = 2, PlayerID = 3},
                    new PlayerTournament {TournamentID = 2, PlayerID = 9},
                    new PlayerTournament {TournamentID = 2, PlayerID = 19},
                    new PlayerTournament {TournamentID = 2, PlayerID = 15},
                    new PlayerTournament {TournamentID = 2, PlayerID = 7},
                    new PlayerTournament {TournamentID = 2, PlayerID = 1},
                    new PlayerTournament {TournamentID = 2, PlayerID = 21},
                    new PlayerTournament {TournamentID = 2, PlayerID = 18},
                    new PlayerTournament {TournamentID = 2, PlayerID = 23},
                };
                context.AddRange(Participation);

                context.SaveChanges();
            }
        }
    }
}