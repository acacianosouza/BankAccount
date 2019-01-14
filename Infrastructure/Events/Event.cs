namespace Infrastructure.Events
{
    public struct Event
    {
        public int Code { get; }
        public string Name { get; }
        public string Message { get; }

        public Event(int errorCode, string name, string Message)
        {
            this.Code = errorCode;
            this.Name = name;
            this.Message = Message;
        }
    }
}
