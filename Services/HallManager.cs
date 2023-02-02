using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;


namespace CinemaApp
{
    internal class HallManager:ICrudService<Hall>,IPrintService
    {
        public void Add(Hall hall)
        {
            DataContext.Halls.Add(hall);
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (id == -1)
            {
                Console.WriteLine("Not Found");

                return;
            }
            DataContext.Halls.RemoveAt(index);
            Console.WriteLine("Zal Silindi!");
        }

        public Hall Get(int id)
        {
            int index = FindHelper.FindHallIndex(id);

            if (id == -1)
            {
                Console.WriteLine("Not Found");

                return null;
            }
            return DataContext.Halls[index];
        }

        public List<Hall> GetAll()
        {
            return DataContext.Halls;
        }

        public void Print()
        {
            foreach (var item in DataContext.Halls)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }
        public void Update(int id, Hall newHall)
        {
            int index = FindHelper.FindHallIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Halls[index] = newHall;
            Console.WriteLine($"\nZal deyisdirildi!\n");
        }
    }
}
