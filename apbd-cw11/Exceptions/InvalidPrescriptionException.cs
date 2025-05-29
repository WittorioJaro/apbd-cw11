namespace apbd_cw11.Exceptions;

public class InvalidPrescriptionException : Exception
{
    public InvalidPrescriptionException()
    {
    }

    public InvalidPrescriptionException(string? message) : base(message)
    {
    }

    public InvalidPrescriptionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}