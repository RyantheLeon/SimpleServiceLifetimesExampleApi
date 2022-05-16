namespace SimpleServiceLifetimesExampleApi.Services;

public abstract class CustomServiceBase
{
    public int instanceNo;
    protected ConsoleColor highlighter;

    public CustomServiceBase()
    {
    }

    public void PrintInstanceInfo(string callerInfo)
    {
        ConsoleHelper.WriteAndHighlight($"{callerInfo} is instance number {instanceNo} of {this.GetType().Name}.", highlighter);
    }

    public int GetInstanceNo()
    {
        return instanceNo;
    }
}
