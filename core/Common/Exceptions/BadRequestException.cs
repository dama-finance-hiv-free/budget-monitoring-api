using System;

namespace Dama.Core.Common.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {

    }
}