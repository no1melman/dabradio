namespace DabRadio
{
    using System;

    public class ControlNotFoundException : Exception
    {
        public ControlNotFoundException(string message)
            : base(message)
        {
        }
    }
}