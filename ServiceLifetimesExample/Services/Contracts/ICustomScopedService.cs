namespace SimpleServiceLifetimesExampleApi.Services.Contracts;

public interface ICustomScopedService
{
    void PrintInstanceInfo(string fieldName);

    int GetInstanceNo();
}