namespace oEconomy;

//All command modules are created with a scoped lifetime
public class MyCommand : CommandModuleBase
{
    [Inject] public ILogger<MyCommand> Logger { get; set; }

    [Command("mycommand")]
    [CommandInfo("woop dee doo this command is from a plugin")]
    public async Task MyCommandAsync()
    {
        Logger.LogInformation("Testing Services as injected dependency");
        await this.Player.SendMessageAsync("Hello from plugin command!");
    }
}