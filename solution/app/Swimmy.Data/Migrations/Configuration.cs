namespace Swimmy.Data.Migrations
{
    using global::System;
    using global::System.Data.Entity.Migrations;

    using Swimmy.Entities.Business;
    using Swimmy.Entities.Membership;

    internal sealed class Configuration : DbMigrationsConfiguration<Swimmy.Data.SwimmingResultsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(
            Swimmy.Data.SwimmingResultsContext context)
        {
            context.ClubSet.AddOrUpdate(g => g.Name,
                                        new Club
                                            {
                                                Id = 1,
                                                Name = "Charmey Natation"
                                            },
                                        new Club
                                            {
                                                Id = 2,
                                                Name = "Romont"
                                            });

            context.SwimmerSet.AddOrUpdate(s => s.Name,
                                           new Swimmer
                                               {
                                                   Name = "Brulhart",
                                                   FirstName = "Nolan",
                                                   Birth = new DateTime(2007, 2, 8),
                                                   ClubId = 1
                                               },
                                           new Swimmer
                                               {
                                                   Name = "Lucciola",
                                                   FirstName = "Naima",
                                                   Birth = new DateTime(2011, 12, 27),
                                                   ClubId = 1
                                               },
                                           new Swimmer
                                               {
                                                   Name = "Mauron",
                                                   FirstName = "Luc",
                                                   Birth = new DateTime(2006, 4, 30),
                                                   ClubId = 2
                                               });

            context.MeetingsSet.AddOrUpdate(
                                            new Meeting
                                                {
                                                    Id = 1,
                                                    Name = "Meeting de Charmey 2015",
                                                    Date = new DateTime(2015, 11, 21)
                                                },
                                            new Meeting
                                                {
                                                    Id = 2,
                                                    Name = "Meeting de Charmey 2014",
                                                    Date = new DateTime(2014, 11, 22)
                                                });

            context.DisciplineSet.AddOrUpdate(new Discipline
                                                  {
                                                      Id = 1,
                                                      Name = "50m Libre"
                                                  },
                                              new Discipline
                                                  {
                                                      Id = 2,
                                                      Name = "50m Brasse"
                                                  },
                                              new Discipline
                                                  {
                                                      Id = 3,
                                                      Name = "50m Dos"
                                                  },
                                              new Discipline
                                                  {
                                                      Id = 4,
                                                      Name = "50m Dauphin"
                                                  },
                                              new Discipline
                                                  {
                                                      Id = 5,
                                                      Name = "100m 4 nages"
                                                  });

            context.ResultSet.AddOrUpdate(new Result
                                              {
                                                  DisciplineId = 1,
                                                  SwimmerId = 1,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 45, 0),
                                                  ResultTime = new TimeSpan(0, 0, 46, 12)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 2,
                                                  SwimmerId = 1,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 49, 0),
                                                  ResultTime = new TimeSpan(0, 0, 50, 21)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 3,
                                                  SwimmerId = 1,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 42, 0),
                                                  ResultTime = new TimeSpan(0, 0, 41, 45)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 1,
                                                  SwimmerId = 2,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 48, 0),
                                                  ResultTime = new TimeSpan(0, 0, 45, 35)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 2,
                                                  SwimmerId = 2,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 55, 0),
                                                  ResultTime = new TimeSpan(0, 0, 43, 12)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 3,
                                                  SwimmerId = 2,
                                                  MeetingId = 1,
                                                  EntryTime = new TimeSpan(0, 0, 51, 0),
                                                  ResultTime = new TimeSpan(0, 0, 40, 63)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 1,
                                                  SwimmerId = 1,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 42, 0)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 2,
                                                  SwimmerId = 1,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 49, 0)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 3,
                                                  SwimmerId = 1,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 46, 0)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 1,
                                                  SwimmerId = 2,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 48, 0)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 2,
                                                  SwimmerId = 2,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 55, 0)
                                              },
                                          new Result
                                              {
                                                  DisciplineId = 3,
                                                  SwimmerId = 2,
                                                  MeetingId = 2,
                                                  EntryTime = new TimeSpan(0, 0, 51, 0)
                                              })
                ;

            ////  create genres 
            //context.GenreSet.AddOrUpdate(g => g.Name, GenerateGenres());

            //// create movies 
            //context.MovieSet.AddOrUpdate(m => m.Title, GenerateMovies());

            ////// create stocks 
            //context.StockSet.AddOrUpdate(GenerateStocks());

            //// create customers 
            //context.CustomerSet.AddOrUpdate(GenerateCustomers());

            // create roles 
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: chsakell, password: homecinema 
            context.UserSet.AddOrUpdate(u => u.Email, new User
                                                          {
                                                              Id = 1,
                                                              Email = "yann@bubusissi.ch",
                                                              UserName = "yann",
                                                              HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                                                              Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                                                              IsLocked = false,
                                                              DateCreated = DateTime.Now
                                                          });

            // // create user-admin for chsakell 
            context.UserRoleSet.AddOrUpdate(new UserRole
                                                {
                                                    RoleId = 1, // admin 
                                                    UserId = 1 // chsakell 
                                                });
        }

        private Role[] GenerateRoles()
        {
            Role[] roles =
                {
                    new Role
                        {
                            Id = 1,
                            Name = "Admin"
                        }
                };

            return roles;
        }
    }
}