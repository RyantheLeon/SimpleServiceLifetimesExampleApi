namespace SimpleServiceLifetimesExampleApi.Services;

public class CustomScopedService : CustomServiceBase, ICustomScopedService
{
    private static int instances = 0;

    public CustomScopedService()
    {
        instances++;
        instanceNo = instances;

        highlighter = ConsoleColor.Yellow;

        ExplainScopedServiceLifetime();
    }

    private void ExplainScopedServiceLifetime()
    {
        ConsoleHelper.WriteAndHighlight($"Instatiated instance number {instanceNo} of {this.GetType().Name}.", highlighter);

        if (instances == 1)
            Console.WriteLine($"As a scoped service, this service will be reused until the scope/request is complete. As this is an API, 'request' means an http request.");
    }
}