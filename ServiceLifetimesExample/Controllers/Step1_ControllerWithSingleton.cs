namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step1_ControllerWithSingleton : ControllerBase
{
    private readonly ICustomSingletonService customSingletonService;

    public Step1_ControllerWithSingleton(ICustomSingletonService customSingletonService)
    {
        this.customSingletonService = customSingletonService;
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
        customSingletonService.PrintInstanceInfo($"The {this.GetType().Name}'s customSingletonService property");

        ConsoleHelper.PrintExplanation("The instance one line above was the same instance shown when the singleton service was first instantiated. If you're following instructions, the singleton service was instantiated for this request, and that log appears three lines above.");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 2 takes one parameter of ICustomScopedService. Call that controller's POST endpoint when you're ready to move forward.");
    }
}
