namespace SimpleServiceLifetimesExampleApi.Services.Contracts;

public interface ICustomTransientService
{
    void PrintInstanceInfo(string fieldName);

    int GetInstanceNo();
}