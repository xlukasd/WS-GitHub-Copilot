namespace Exercise_Security.Model
{
    public class Speaker
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public string Bio { get; set; }
    }
}
