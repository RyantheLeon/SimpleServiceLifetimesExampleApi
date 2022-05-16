namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step3_ControllerWithTransient : ControllerBase
{
    private readonly ICustomTransientService customTransientService;

    public Step3_ControllerWithTransient(ICustomTransientService customTransientService)
    {
        this.customTransientService = customTransientService;
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
        customTransientService.PrintInstanceInfo($"The {this.GetType().Name}'s customTransientService property");

        ConsoleHelper.PrintExplanation("The instance one line above is the same instance shown when the transient service was instantiated milliseconds ago (see three lines above). It will not be reused in another request, nor would it have been reused in this one if this request had required an instance of ICustomTransientService somewhere else.");
        ConsoleHelper.PrintExplanation("At this point the app has explained the basic differences between singleton, scoped, and transient services, but hasn't shown those differences. To illustrate them, let's see what happens when we call an endpoint with a constructor that takes multiple parameters of the same service.");
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("The constructor for Step 4 takes two parameters, and each are a type of ICustomSingletonService. Call that controller's POST endpoint when you're ready to move forward.");
    }
}