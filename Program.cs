using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Models.Enums;
using CinemaApp.Services;
using System;
using System.Reflection;

namespace CinemaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var venera = new Hall
            {
                Id = 1,
                Name = "Venera",
                RowCount = 10,
                ColumnCount = 12
            };

            var mercuri = new Hall
            {
                Id = 2,
                Name = "Mercuri",
                RowCount = 6,
                ColumnCount = 6
            };

            var yupiter = new Hall
            {
                Id = 3,
                Name = "Yupiter",
                RowCount = 6,
                ColumnCount = 6
            };

            var cinemaPlus = new Cinema
            {
                Id = 1,
                Name = "CinemaPlus",
                Halls = new List<Hall> { venera, mercuri }
            };

            var nizamiKino = new Cinema
            {
                Id = 2,
                Name = "Nizami kinoteatr",
                Halls = new List<Hall> { yupiter }
            };

            var filmSeven = new Film
            {
                Id = 1,
                Name = "Seven",
                Director = "Nolan",
                TimeInMinute = 95
            };

            var filmZodiac = new Film
            {
                Id = 2,
                Name = "Zodiac",
                Director = "Nolan",
                TimeInMinute = 135,
            };

            var sessionSeven = new Session
            {
                Id = 1,
                Film = filmSeven,
                Hall = venera,
                Seats = new State[venera.RowCount, venera.ColumnCount],
                Price = 15,
                CinemaId = 1,
                Cinema = cinemaPlus,
            };

            var sessionZodiac = new Session
            {
                Id = 2,
                Film = filmZodiac,
                Hall = mercuri,
                Seats = new State[mercuri.RowCount, mercuri.ColumnCount],
                Price = 10,
                CinemaId = 2,
                Cinema = nizamiKino
            };

            var cinemaManager = new CinemaManager();
            cinemaManager.Add(cinemaPlus);
            cinemaManager.Add(nizamiKino);

            var sessionManager = new SessionManager();
            sessionManager.Add(sessionZodiac);
            sessionManager.Add(sessionSeven);

            var filmManager = new FilmManager();
            filmManager.Add(filmSeven);
            filmManager.Add(filmZodiac);

            var hallManager = new HallManager();
            hallManager.Add(venera);
            hallManager.Add(mercuri);
            hallManager.Add(yupiter);

            var ticketManager = new TicketManager(sessionManager, cinemaManager);

            string command;

            do
            {
                Console.Write("Enter the command:");
                command = Console.ReadLine();

                if (command == "buy ticket")
                {
                    ticketManager.BuyTicket();
                }
                else if (command == "show tickets")
                {
                    ticketManager.Print();
                }
                else if (command == "get film")
                {
                    Console.Write("Film Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine(filmManager.Get(id));
                }
                else if (command == "delete film")
                {
                    Console.Write("Film Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());
                    filmManager.Delete(id);
                }
                else if (command == "show films")
                {
                    filmManager.Print();
                }
                else if (command == "get all films")
                {
                    Console.WriteLine(filmManager.GetAll());
                }
                else if (command == "update film")
                {
                    Console.Write("Deyismek istediyiniz filmin Id-sini daxil edin:");
                    int id = int.Parse(Console.ReadLine());

                    Film filmAvatar = new Film
                    {
                        Id = 3,
                        Name = "Avatar",
                        Director = "James Cameron",
                        TimeInMinute = 120
                    };
                    filmManager.Update(id, filmAvatar);
                }
                else if (command == "get hall")
                {
                    Console.Write("Zal Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(hallManager.Get(id));
                }
                else if (command == "show halls")
                {
                    hallManager.Print();
                }
                else if (command == "delete hall")
                {
                    Console.Write("Zal Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    hallManager.Delete(id);
                }
                else if (command == "update hall")
                {
                    Console.Write("Deyismek istediyiniz zalin Id-sini daxil edin:");
                    int id = int.Parse(Console.ReadLine());

                    var mars = new Hall
                    {
                        Id = 4,
                        Name = "Mars",
                        RowCount = 6,
                        ColumnCount = 6
                    };
                    hallManager.Update(id, mars);
                }
                else if (command == "get all halls")
                {
                    Console.WriteLine(hallManager.GetAll());
                }
                else if (command == "update cinema")
                {
                    Console.Write("Deyismek istediyiniz cinemanin Id-sini daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    var denizMallCinema = new Cinema
                    {
                        Id = 4,
                        Name = "DenizMallCinema",
                        Halls = new List<Hall> { venera, yupiter }
                    };

                    cinemaManager.Update(id, denizMallCinema);
                }
                else if (command == "delete cinema")
                {
                    Console.Write("Cinema Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    cinemaManager.Delete(id);
                }
                else if (command == "get cinema")
                {
                    Console.Write("Cinema Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine(cinemaManager.Get(id));
                }
                else if (command == "get all cinemas")
                {
                    Console.WriteLine(cinemaManager.GetAll());
                }
                else if (command == "get session")
                {
                    Console.Write("Seans Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine(sessionManager.Get(id));
                }
                else if (command == "get all sessions")
                {
                    Console.WriteLine(sessionManager.GetAll());
                }
                else if (command == "delete session")
                {
                    Console.Write("Seans Id-si daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    sessionManager.Delete(id);
                }
                else if (command == "update session")
                {
                    Console.Write("Deyismek istediyiniz seansin Id-sini daxil edin: ");
                    int id = int.Parse(Console.ReadLine());

                    var sessionZodiac2 = new Session
                    {
                        Id = 3,
                        Film = filmZodiac,
                        Hall = yupiter,
                        Seats = new State[yupiter.RowCount, yupiter.ColumnCount],
                        Price = 13,
                        CinemaId = 2,
                        Cinema = nizamiKino,
                    };
                    sessionManager.Update(id, sessionZodiac2);
                }
            } while (command != "quit");
        }
    }
}