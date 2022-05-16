namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step5_ControllerWithMultipleScoped : ControllerBase
{
    private readonly ICustomScopedService customScopedServiceA;
    private readonly ICustomScopedService customScopedServiceB;

    public Step5_ControllerWithMultipleScoped(ICustomScopedService customScopedServiceA, ICustomScopedService customScopedServiceB)
    {
        this.customScopedServiceA = customScopedServiceA;
        this.customScopedServiceB = customScopedServiceB;
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
        customScopedServiceA.PrintInstanceInfo($"The {this.GetType().Name}'s customScopedServiceA property");
        customScopedServiceB.PrintInstanceInfo($"The {this.GetType().Name}'s customScopedServiceB property");

        ConsoleHelper.PrintExplanation("The two lines above refer to the same instance as one another because a scoped service is reused as long until the scope/request is complete. If you're following the instructions, the instance in the two previous lines is different than the instance in step 2 because that was part of a different scope/request.");
        ConsoleHelper.PrintExplanation("(If you don't see the value in having the same instance of an object twice, you're right (again). Seems like you might be picking up the concepts.)");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 6 takes two parameters, and each are a type of ICustomTransientService. Call that controller's POST endpoint when you're ready to move forward.");
    }
}