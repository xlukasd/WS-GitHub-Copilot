namespace Exercise_Security.Model
{
    public class Talk
    {
        public Guid Id { get; set; }
        public Guid SpeakerId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
    }
}
