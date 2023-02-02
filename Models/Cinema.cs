namespace CinemaApp.Models
{
    internal class Cinema : Entity
    {
        public string Name { get; set; }
        public List<Hall> Halls { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\tName: {Name}";
        }
    }
}
