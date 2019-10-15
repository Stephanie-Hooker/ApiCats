using System;
using System.Runtime.Serialization;

namespace cats.Controllers
{
  [Serializable]
  internal class ThisIsDog : Exception
  {
    public ThisIsDog()
    {
    }

    public ThisIsDog(string message) : base(message)
    {
    }

    public ThisIsDog(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ThisIsDog(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }
}