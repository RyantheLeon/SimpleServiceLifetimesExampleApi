namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step6_ControllerWithMultipleTransient : ControllerBase
{
    private readonly ICustomTransientService customTransientServiceA;
    private readonly ICustomTransientService customTransientServiceB;

    public Step6_ControllerWithMultipleTransient(ICustomTransientService customTransientServiceA, ICustomTransientService customTransientServiceB)
    {
        this.customTransientServiceA = customTransientServiceA;
        this.customTransientServiceB = customTransientServiceB;
    }

    [HttpPost]
    public void Post()
    {
        Explain();

        PrintNextInstructions();

        ConsoleHelper.WriteRequestBreak();
    }

    private void Explain()
    {
        customTransientServiceA.PrintInstanceInfo($"The {this.GetType().Name}'s customTransientServiceA property");
        customTransientServiceB.PrintInstanceInfo($"The {this.GetType().Name}'s customTransientServiceB property");

        ConsoleHelper.PrintExplanation("The two instances above are different because a transient service is never reused. If you're following the instructions, the two instances above are also different than the instances used in step 3 because a transient is never reused.");
        ConsoleHelper.PrintExplanation("Hopefully the last three requests have illustrated how a service is (or is not) reused. How much a service is reused is referred to to as the 'Service Lifetime'.");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 7 takes three parameters. It takes one ICustomSingletonService, one ICustomScopedService, and one ICustomTransientService. Call that controller's POST endpoint when you're ready to move forward. Note that, when you call the POST endpoint, you'll be asked to pass through the number of instances of each type of service (singleton, scoped, and transient) that you think will have been created by the app after it instantiates next step's Controller.");
    }
}