namespace SimpleServiceLifetimesExampleApi.Services;

public class CustomTransientService : CustomServiceBase, ICustomTransientService
{
    private static int instances = 0;

    public CustomTransientService()
    {
        instances++; 
        instanceNo = instances;
        
        highlighter = ConsoleColor.Blue;

        ExplainTransientServiceLifetime();
    }

    private void ExplainTransientServiceLifetime()
    {
        ConsoleHelper.WriteAndHighlight($"Instatiated instance number {instanceNo} of {this.GetType().Name}.", highlighter);

        if (instances == 1)
            Console.WriteLine($"As a transient service, this service will not be reused. When the app needs an instance of the {this.GetType().Name} class, a new instance will be created.");
    }
}