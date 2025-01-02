namespace oEconomy;

//All command modules are created with a scoped lifetime
[CommandGroup("eco")]
public class MyGroupCommand : CommandModuleBase
{
    [Inject] public ILogger<MyGroupCommand> Logger { get; set; }
    [Inject] public VaultApi VaultApi { get; set; }
    
    [Command("give")]
    [CommandInfo("Gives a player money out of thin air.")]
    public async Task Give(string playerName, int a)
    {
        VaultApi.AddBalance(playerName, a);
        Logger.LogInformation("Added {a} to {playerName}", a, playerName);
    }
    
    [Command("take")]
    [CommandInfo("Takes a players money.")]
    public async Task Take(string playerName, int a)
    {
        VaultApi.DeductBalance(playerName, a);
        Logger.LogInformation("Took {a} from {playerName}", a, playerName);
    }
    
    [Command("set")]
    [CommandInfo("Sets players money to a value.")]
    public async Task Set(string playerName, int a)
    {
        var initialBalance = VaultApi.GetBalance(playerName);
        VaultApi.DeductBalance(playerName, initialBalance);
        VaultApi.AddBalance(playerName, a);
        Logger.LogInformation("Set {playerName} balance to {a}", playerName, a);
    }

}