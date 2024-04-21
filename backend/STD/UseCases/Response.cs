namespace STD.UseCases;

public record Response<T>(string Message, T? Value);