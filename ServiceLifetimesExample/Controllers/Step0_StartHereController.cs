namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step0_StartHereController : ControllerBase
{
    public Step0_StartHereController()
    {
    }

    [HttpPost]
    public void Post()
    {
        ConsoleHelper.PrintInstructions("This app aims to explain service lifetimes in .net. If you do not understand the concept of dependency injection, please read up on that first (see https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).");
        ConsoleHelper.PrintInstructions(@"Lines 9-11 in the Program class (see immediately below) show how services can be declared as Singleton, Scoped, or Transient Services.
builder.Services.AddSingleton<ICustomSingletonService, CustomSingletonService>();
builder.Services.AddScoped<ICustomScopedService, CustomScopedService>();
builder.Services.AddTransient<ICustomTransientService, CustomTransientService>();");
        ConsoleHelper.PrintInstructions("The instructions at the end of each step will prepare you for the next step. You can also read the next step's constructor, noting the parameters it takes.");
        ConsoleHelper.PrintInstructions("For example, the Step1_SingletonController class's constructor takes one parameter of type 'ICustomSingletonService', which the program class declares as a Singleton (see line 9 in the Program class).");
        ConsoleHelper.PrintInstructions("When you call each endpoint, it will write to the console and highlight each type of service in a color. Singletons will be highlighted in green, scoped services in yellow, and transients in blue. This isn't the prettiest, but the goal of highlighting is to help you quickly refer back to the most important information. Explanations appear in plain old white text, because that's the easiest to read.");
        ConsoleHelper.PrintInstructions("Now that you know what step 1's constructor looks like (feel free to read the constructor for Step1_ControllerWithSingleton), call it, and read the console for an explanation of what is happening. Once you are comfortable with the concepts mentioned, look for more instructions on the next endpoint in red text.");

        ConsoleHelper.WriteRequestBreak();
    }
}