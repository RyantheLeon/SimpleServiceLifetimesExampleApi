namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step4_ControllerWithMultipleSingleton : ControllerBase
{
    private readonly ICustomSingletonService customSingletonServiceA;
    private readonly ICustomSingletonService customSingletonServiceB;

    public Step4_ControllerWithMultipleSingleton(ICustomSingletonService customSingletonServiceA, ICustomSingletonService customSingletonServiceB)
    {
        this.customSingletonServiceA = customSingletonServiceA;
        this.customSingletonServiceB = customSingletonServiceB;
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
        customSingletonServiceA.PrintInstanceInfo($"The {this.GetType().Name}'s customSingletonServiceA property");
        customSingletonServiceB.PrintInstanceInfo($"The {this.GetType().Name}'s customSingletonServiceB property");

        ConsoleHelper.PrintExplanation("The two lines above refer to the same instance because a singleton service is reused until the app stops running. If you're following the instructions, the instance in the two previous lines is the same as the instance in step 1, and will remain the same every time a singleton is used.");
        ConsoleHelper.PrintExplanation("(If you don't see the value in having the same instance of an object twice, you're right. There's no reason you'd need an exact duplicate of an object within another object. However, the point of this app isn't to show you what you should do, but to explain how service lifetimes work.)");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 5 takes two parameters, and each are a type of ICustomScopedService. Call that controller's POST endpoint when you're ready to move forward");
    }
}