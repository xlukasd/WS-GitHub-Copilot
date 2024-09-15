namespace Bank.Domain
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string message) : base(message)
        {
        }
    }
}
