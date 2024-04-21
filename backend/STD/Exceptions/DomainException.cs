namespace STD.Exceptions;

public class DomainException : Exception
{
	public DomainException(string message) : base(message)
	{ }

	public static void ThrowsIf(bool condition, string errorMessage)
	{
		if (condition) throw new DomainException(errorMessage);
	}
}