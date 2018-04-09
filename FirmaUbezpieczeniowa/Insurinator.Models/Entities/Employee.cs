namespace Insurinator.Models.Entities
{
    public class Employee 
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Login { get; set; }
        public string HashedPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
