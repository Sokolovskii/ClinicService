using System;

namespace SokolovskiyClinicService.Exceptions
{
    public class WarningException : Exception
    {
        public WarningException(string message) : base(message)
        {}
    }
}