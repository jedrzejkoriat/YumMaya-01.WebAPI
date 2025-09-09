namespace YumMaya_01.WebAPI.Application.Base;

public sealed class ForbiddenException : Exception
{
    public ForbiddenException(string message) : base(message) { }
}

public sealed class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public sealed class OperationFailedException : Exception
{
    public OperationFailedException(string message) : base(message) { }
}