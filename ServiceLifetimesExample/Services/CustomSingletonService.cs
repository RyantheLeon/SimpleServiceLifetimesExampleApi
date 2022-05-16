namespace SimpleServiceLifetimesExampleApi.Services;

public class CustomSingletonService : CustomServiceBase, ICustomSingletonService
{
    private static int instances = 0;

    public CustomSingletonService()
    {
        instances++;
        instanceNo = instances;

        highlighter = ConsoleColor.Green;

        ExplainSingletonServiceLifetime();
    }

    private void ExplainSingletonServiceLifetime()
    {
        ConsoleHelper.WriteAndHighlight($"Instatiated instance number {instanceNo} of {this.GetType().Name}.", highlighter);

        if (instances == 1)
            Console.WriteLine("As a singleton service, this service will be reused until the app stops running (i.e., the app uses a 'single' instance of it).");
        else
            Console.WriteLine("This line of code will never run, as a singleton will never have more than one instance.");
    }

}