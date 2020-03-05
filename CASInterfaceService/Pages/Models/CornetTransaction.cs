using System;

namespace CASInterfaceService.Pages.Models
{
    public class CornetTransaction
    {
        String csNumber;
        public String CSNumber
        {
            get { return csNumber; }
            set { csNumber = value; }
        }

        DateTime eventDateTimestamp;
        public DateTime EventDateTimestamp
        {
            get { return eventDateTimestamp; }
            set { eventDateTimestamp = value; }
        }

        String operationCode;
        public String OperationCode
        {
            get { return operationCode; }
            set { operationCode = value; }
        }

        String eventType;
        public String EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        String eventData;
        public String EventData
        {
            get { return eventData; }
            set { eventData = value; }
        }
    }
}
