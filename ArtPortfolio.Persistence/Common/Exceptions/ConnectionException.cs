namespace ArtPortfolio.Persistence.Common.Exceptions;

public class ConnectionException(string connectionString) 
    : Exception($"{connectionString} not connected");