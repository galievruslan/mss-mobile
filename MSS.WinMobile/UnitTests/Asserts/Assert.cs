using System;
using System.Runtime.Serialization;

namespace UnitTests.Asserts
{
    public static class Assert
    {
        public static void AreEquals(object expected, object actual)
        {
            if (expected != actual)
                throw new NotEqualsException(expected, actual);
        }

        public static void NotEquals(object expected, object actual)
        {
            if (expected == actual)
                throw new EqualsException(expected, actual);
        }

        public static void NotNull(object actual)
        {
            if (actual == null)
                throw new NotEqualsException();
        }
    }

    [Serializable]
    public class NotEqualsException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NotEqualsException()
        {
        }

        public NotEqualsException(object expected, object actual)
            :base(string.Format("Expected {0} not equal actual {1}", expected, actual))
        {
        }

        public NotEqualsException(string message) : base(message)
        {
        }

        public NotEqualsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NotEqualsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class EqualsException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public EqualsException()
        {
        }

        public EqualsException(object expected, object actual)
            : base(string.Format("Expected {0} are equal actual {1}", expected, actual))
        {
        }

        public EqualsException(string message)
            : base(message)
        {
        }

        public EqualsException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EqualsException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }

    [Serializable]
    public class EqualsNullException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public EqualsNullException()
        {
        }

        public EqualsNullException(string message)
            : base(message)
        {
        }

        public EqualsNullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EqualsNullException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
