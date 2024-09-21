using System;

public class AlredyExistException : ApplicationException
{
    public AlredyExistException(string message) : base(message)
    {
    }
}

