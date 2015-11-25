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