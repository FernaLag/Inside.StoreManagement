namespace Inside.StoreManagement.Application.Exceptions
{
    public class BadRequestException(string message) : ApplicationException(message)
    {
    }
}