namespace SimpleServiceLifetimesExampleApi.Services.Contracts;

public interface ICustomSingletonService
{
    void PrintInstanceInfo(string fieldName);

    int GetInstanceNo();
}