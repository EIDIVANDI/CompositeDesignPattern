using System;
using System.Runtime.Serialization;

namespace CompositeDesignPattern.Domain.Exceptions
{
    [Serializable]
    internal class TaskManagerRightsException : Exception
    {
        public TaskManagerRightsException()
        {
        }

        public TaskManagerRightsException(string message) : base(message)
        {
        }

        public TaskManagerRightsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskManagerRightsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}