using System;

namespace Baudi.Client.ViewModels.Validation.Exceptions
{
    public class WrongDataException : Exception
    {
        public WrongDataException()
        {
        }

        public WrongDataException(string message)
            : base(message)
        {
        }
    }
}