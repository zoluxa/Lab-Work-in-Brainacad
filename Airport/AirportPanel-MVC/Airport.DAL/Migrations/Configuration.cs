namespace Airport.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Airport.DAL.DataContext.AirlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Airport.DAL.DataContext.AirlineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Airlines
            context.Airlines.AddOrUpdate(p => p.Id,
                new Airline
                {
                    Id = 1,
                    Name = "Air Ukraine"
                },
                new Airline
                {
                    Id = 2,
                    Name = "KLM"
                },
                new Airline
                {
                    Id = 3,
                    Name = "Delta Airlines"
                },
                new Airline
                {
                    Id = 4,
                    Name = "Egypt Air"
                }
                );

            // Ports
            context.Ports.AddOrUpdate(p => p.Id,
                new Port
                {
                    Id = 1,
                    Name = "Kyiv Boryspil"
                },
                new Port
                {
                    Id = 2,
                    Name = "New York JFK"
                },
                new Port
                 {
                     Id = 3,
                     Name = "Tokyo"
                 },
                new Port
                {
                    Id = 4,
                    Name = "Paris"
                },
                new Port
                {
                    Id = 5,
                    Name = "London"
                }
               );
            
            // Flights
            context.Flights.AddOrUpdate(
                p => p.Id,
                new Flight
                {
                    Id = 1,
                    FlightNumber = "FN 20212",
                    AirlineId = 1,
                    ArrivalDate = DateTime.Parse("2015/12/11 05:25"),
                    ArrivalPortId = 1,
                    DepartureDate = DateTime.Parse("2015/12/10 18:30"),
                    DeparturePortId = 2,
                    Gate = "5",
                    Terminal = "D",
                    Status = Model.Enums.FlightStatus.ChekIn,
                    PlaceQty = 250,
                    Places = new System.Collections.Generic.List<FlightPlace>
                    {
                        new FlightPlace
                        {
                            Id = 1,
                            FlightId = 1,
                            PlaceClass = Model.Enums.PlaceClass.Business,
                            Quantity = 50,
                            Price = 230.50M
                        },
                        new FlightPlace
                        {
                            Id = 2,
                            FlightId = 1,
                            PlaceClass = Model.Enums.PlaceClass.Economy,
                            Quantity = 200,
                            Price = 160.75M
                        }
                    }
                },
                new Flight
                {
                    Id = 2,
                    FlightNumber = "AS 32212",
                    AirlineId = 3,
                    ArrivalDate = DateTime.Parse("2015/12/10 15:25"),
                    ArrivalPortId = 3,
                    DepartureDate = DateTime.Parse("2015/12/10 10:30"),
                    DeparturePortId = 4,
                    Gate = "5",
                    Terminal = "D",
                    Status = Model.Enums.FlightStatus.ChekIn,
                    PlaceQty = 250,
                    Places = new System.Collections.Generic.List<FlightPlace>
                    {
                        new FlightPlace
                        {
                            Id = 1,
                            FlightId = 1,
                            PlaceClass = Model.Enums.PlaceClass.Business,
                            Quantity = 50,
                            Price = 230.50M
                        },
                        new FlightPlace
                        {
                            Id = 2,
                            FlightId = 1,
                            PlaceClass = Model.Enums.PlaceClass.Economy,
                            Quantity = 200,
                            Price = 160.75M
                        }
                    }
                }
                );

        }
    }
}
