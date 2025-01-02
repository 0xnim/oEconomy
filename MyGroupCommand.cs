namespace oEconomy;

//All command modules are created with a scoped lifetime
[RequirePermission(PermissionCheckType.Any, true, "eco.admin")]
[CommandGroup("eco")]
public class EconomyCommand : CommandModuleBase
{
    [Inject] public ILogger<EconomyCommand> Logger { get; set; }
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

[CommandGroup("balance", "bal")]
public class BalanceCommands : CommandModuleBase
{
    [Inject] public ILogger<BalanceCommands> Logger { get; set; }
    [Inject] public VaultApi VaultApi { get; set; }

    [Command("")]
    [CommandInfo("Gets the balance of a player.")]
    public async Task Balance()
    {
        var playerName = this.CommandContext.Player.Username;
        var balance = VaultApi.GetBalance(playerName);
        //Logger.LogInformation("You have a balance of {balance}", balance);
        await this.Player.SendMessageAsync($"You have a balance of {balance}");
    }
    
    [Command("")]
    [CommandOverload]
    public async Task BalanceOther(string playerName)
    {
        var balance = VaultApi.GetBalance(playerName);
        Logger.LogInformation("{playerName} has a balance of {balance}", playerName, balance);
        await this.Player.SendMessageAsync($"{playerName} has a balance of {balance}");
    }
}