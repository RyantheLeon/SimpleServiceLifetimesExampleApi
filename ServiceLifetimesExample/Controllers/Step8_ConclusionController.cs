
namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step8_ConclusionController : ControllerBase
{
    public Step8_ConclusionController()
    {
    }

    [HttpPost]
    public void Post()
    {
        // TODO: Add another controller (starting with the letter H) that shows how passing services with different lifetimes into the same controller doesn't change any of the principles mentioned.
        ConsoleHelper.PrintInstructions("The previous examples were hopefully clear, but what happens when a service's constructor relies on other services? The effects might not be immediately obvious. If you're ready to learn more, visit the <<TODO: Next Repository Link Here>>. Please make sure you have a solid understanding of what has been covered here before continuing.");

        ConsoleHelper.WriteRequestBreak();
    }
}