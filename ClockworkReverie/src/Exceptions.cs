namespace ClockworkReverie;

[Serializable]
internal class InvalidLengthException : Exception
{
    public InvalidLengthException()
    {
    }

    public InvalidLengthException(string? message) : base(message)
    {
    }

    public InvalidLengthException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
