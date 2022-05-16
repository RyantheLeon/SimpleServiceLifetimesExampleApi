namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step2_ControllerWithScoped : ControllerBase
{
    private readonly ICustomScopedService customScopedService;

    public Step2_ControllerWithScoped(ICustomScopedService customScopedService)
    {
        this.customScopedService = customScopedService;
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
        customScopedService.PrintInstanceInfo($"The {this.GetType().Name}'s customScopedService property");

        ConsoleHelper.PrintExplanation("The instance one line above was the same instance shown when the scoped service was instantiated milliseconds ago (see three lines above). It will not be reused in another request.");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 3 takes one parameter of ICustomTransientService. Call that controller's POST endpoint when you're ready to move forwardendpoint.");
    }
}