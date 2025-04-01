using System.Reflection;

namespace ProximaEnergia.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message, string trace) : base(message)
        {
        }
    }
}
