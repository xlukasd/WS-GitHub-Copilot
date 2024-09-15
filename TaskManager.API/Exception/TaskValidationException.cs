namespace TaskManager.API.Exception
{
    public class TaskValidationException : System.Exception
    {
        public TaskValidationException(string message) : base(message)
        {
        }
    }
}
