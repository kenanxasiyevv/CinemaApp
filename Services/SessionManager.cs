using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;

namespace CinemaApp.Services
{
    internal class SessionManager : ICrudService<Session>,IPrintService
    {
        public void Add(Session session)
        {
            DataContext.Sessions.Add(session);
            Console.WriteLine("Added");
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindSessionIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }
           
            DataContext.Sessions.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Session Get(int id)
        {
            int index = FindHelper.FindSessionIndex(id);
            if (index == -1)
            {
                Console.WriteLine("Not found");

                return null;
            }

            return DataContext.Sessions[index];
        }

        public List<Session> GetAll()
        {
            return DataContext.Sessions;
        }

        public void Print()
        {
            foreach (var item in DataContext.Sessions)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Session newSession)
        {
            int index = FindHelper.FindSessionIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Sessions[index] = newSession;
            Console.WriteLine($"\nSeans deyisdirildi!\n");
        }

        public void PrintSessionSeats(Session session)
        {
            Console.Write("   ");

            for (int i = 0; i < session.Seats.GetLength(1); i++)
                Console.Write($"{i + 1,-3}");

            Console.WriteLine();

            for (int i = 0; i < session.Seats.GetLength(0); i++)
            {
                Console.Write($"{i + 1,-3}");

                for (int j = 0; j < session.Seats.GetLength(1); j++)
                {
                    Console.Write($"{(int)session.Seats[i, j],-3}");
                }

                Console.WriteLine();
            }
        }

        public void PrintSessionByCinema(int cinemaId)
        {
            foreach (var item in DataContext.Sessions)
            {
                if (item.CinemaId == cinemaId)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("-".PadRight(20, '-'));
                }
            }
        }
    }
}
