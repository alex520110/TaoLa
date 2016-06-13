namespace TaoLa.Core
{
    public class CacheRegisterException : TaoLaException
    {
        public CacheRegisterException()
        {
        }

        public CacheRegisterException(string message) : base(message)
        {
        }

        public CacheRegisterException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
