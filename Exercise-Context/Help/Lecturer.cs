namespace Exercise_Context.Help
{
    internal class Lecturer
    {
        public Lecturer(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OfficeLocation { get; set; }
    }
}
