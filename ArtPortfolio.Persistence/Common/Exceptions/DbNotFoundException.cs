namespace ArtPortfolio.Persistence.Common.Exceptions;

public class DbNotFoundException(string name, object key) 
    : Exception($"{name} with key ({key}) not found in Database");