using System;

namespace MV.Common.Cqrs.Core.Bus
{
    public abstract class Message : IMessage
    {
        protected Message()
        {
            MessageId = Guid.NewGuid();
            MessageType = GetType().Name;
            MessageCreatedDate = DateTime.Now;
        }

        public Guid MessageId { get; protected set; }
        public string AuditUserName { get; set; }
        public string MessageType { get; protected set; }
        public DateTime MessageCreatedDate { get; protected set; }

        public override string ToString()
        {
            return $"MessageId:{MessageId} - MessageType:{MessageType} - TimeStamp:{MessageCreatedDate}";
        }
    }
}