using System.Text;

namespace SimpleServiceLifetimesExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Step7_ControllerWithOneOfEach : ControllerBase
{
    private readonly ICustomSingletonService customSingletonService;
    private readonly ICustomScopedService customScopedService;
    private readonly ICustomTransientService customTransientService;

    public Step7_ControllerWithOneOfEach(ICustomSingletonService customSingletonService, ICustomScopedService customScopedService, ICustomTransientService customTransientService)
    {
        this.customSingletonService = customSingletonService;
        this.customScopedService = customScopedService;
        this.customTransientService = customTransientService;
    }

    [HttpPost]
    public IActionResult Post(int howManySingetonsAfterThisRequest, int howManyScopedAfterThisRequest, int howManyTransientsAfterThisRequest)
    {
        var sb = new StringBuilder();

        var areAllAnswersCorrect = CheckAndExplainAnswers(howManySingetonsAfterThisRequest, howManyScopedAfterThisRequest, howManyTransientsAfterThisRequest, sb);

        PrintNextInstructions();

        ConsoleHelper.WriteRequestBreak();

        if (areAllAnswersCorrect)
            return Ok(sb.ToString());
        else
            return BadRequest(sb.ToString());
    }

    private bool CheckAndExplainAnswers(int singletonAnswer, int scopedAnswer, int transientAnswer, StringBuilder sb)
    {
        var isSingletonAnswerCorrect = CheckandExplainSingletonAnswer(singletonAnswer, sb);

        var isScopedAnswerCorrect = CheckandExplainScopedAnswer(scopedAnswer, sb);

        var isTransientAnswerCorrect = CheckandExplainTransientAnswer(transientAnswer, sb);

        return (isSingletonAnswerCorrect && isScopedAnswerCorrect && isTransientAnswerCorrect);
    }

    private bool CheckandExplainSingletonAnswer(int singletonAnswer, StringBuilder sb)
    {
        var correctAnswer = customSingletonService.GetInstanceNo();
        var answerText = $"answered that there {GetPresentTenseNumber(singletonAnswer)} of the CustomSingletonService class";
        var correctAnswerText = "The correct answer will always be 1";

        if (singletonAnswer == correctAnswer)
        {
            ConsoleHelper.PrintExplanation($"You correctly {answerText}. {correctAnswerText}. If you've already called another endpoint that requires a singleton, then the app has already created a CustomSingletonService object, has held that object in memory, and will reuse that object here. If you have not called another endpoint that requires a singleton, the app created a CustomSingletonService object for this request. In either case, there is currently 1 and only 1 instance of the CustomSingletonService.");
            return true;
        }
        else if (singletonAnswer < correctAnswer)
        {
            ConsoleHelper.PrintExplanation($"You incorrectly {answerText}. {correctAnswerText}. There will be 1 instance of the CustomSingletonService when this endpoint is called because this controller needs an instance, so the app will create it.");
            return false;
        }
        else
        {
            ConsoleHelper.PrintExplanation($"You incorrectly {answerText}. {correctAnswerText}. There will never be more than 1 instance of the SingletonService because an app will reuse that lone instance until the app stops.");
            return false;
        }
    }
    private bool CheckandExplainScopedAnswer(int scopedAnswer, StringBuilder sb)
    {
        var correctAnswer = customScopedService.GetInstanceNo();
        var answerText = $"answered that there {GetPerfectTenseNumber(scopedAnswer)} of the CustomScopedService class";
        var explanationText = $"because you've made {correctAnswer} requests to endpoints that needed a CustomScopedService object since you started running the app (this request included), and one was created for each new request (including this request).";

        if (scopedAnswer == correctAnswer)
        {
            ConsoleHelper.PrintExplanation($"You correctly {answerText}. This is {explanationText}.");
            return true;
        }
        else
        {
            ConsoleHelper.PrintExplanation($"You incorrectly {answerText}. There {GetPerfectTenseNumber(correctAnswer)} of the CustomScopedService class {explanationText}.");
            return false;
        }
    }
    private bool CheckandExplainTransientAnswer(int transientAnswer, StringBuilder sb)
    {
        var correctAnswer = customTransientService.GetInstanceNo();
        var answerText = $"answered that there {GetPerfectTenseNumber(transientAnswer)} of the CustomTransientService class";
        var explanationText = $"because the constructors for the endpoints you have called (this request included) have taken a total of {(correctAnswer == 1 ? "1 ICustomTransientService parameter" : $"{correctAnswer} ICustomTransientService parameters")}, so the app created an instance of the CustomTransientService class for each parameter each time the constructor was instantiated";

        if (transientAnswer == correctAnswer)
        {
            ConsoleHelper.PrintExplanation($"You correctly {answerText}. This is {explanationText}.");
            return true;
        }
        else
        {
            ConsoleHelper.PrintExplanation($"You incorrectly {answerText}. There {GetPerfectTenseNumber(correctAnswer)} of the CustomTransientService class {explanationText}.");
            return false;
        }
    }
    private string GetPresentTenseNumber(int instances)
    {
        return instances == 1 ? "is 1 instance" : $"are {instances} instances";
    }

    private string GetPerfectTenseNumber(int instances)
    {
        return instances == 1 ? "has been 1 instance" : $"have been {instances} instances";
    }

    private void PrintNextInstructions()
    {
        ConsoleHelper.PrintInstructions("Feel free to call this endpoint again to help you understand the concepts. Once you grasp them, please call the last endpoint (Step 8).");
    }
}