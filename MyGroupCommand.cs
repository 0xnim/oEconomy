using System;
using System.Linq;
using System.Text;

namespace oEconomy;

//All command modules are created with a scoped lifetime
// setting the permission for a commandgroup does not work
[CommandGroup("eco")]
public class EconomyCommand : CommandModuleBase
{
    [Inject] public ILogger<EconomyCommand> Logger { get; set; }
    [Inject] public VaultApi VaultApi { get; set; }
    
    [RequirePermission(PermissionCheckType.Any, true, "eco.admin")]
    [Command("give")]
    [CommandInfo("Gives a player money out of thin air.")]
    public async Task Give(IPlayer player, int amount)
    {
        VaultApi.AddBalance(player.Uuid.ToString(), amount);
        this.Player.SendMessageAsync($"Gave {amount} to {player.Username}");
    }
    
    [RequirePermission(PermissionCheckType.Any, true, "eco.admin")]
    [Command("take")]
    [CommandInfo("Takes a players money.")]
    public async Task Take(IPlayer player, int amount)
    {
        VaultApi.DeductBalance(player.Uuid.ToString(), amount);
        this.Player.SendMessageAsync($"Took {amount} from {player.Username}");
    }

    [RequirePermission(PermissionCheckType.Any, true, "eco.admin")]
    [Command("set")]
    [CommandInfo("Sets players money to a value.")]
    public async Task Set(IPlayer player, int amount)
    {
        if (amount < 0)
        {
            this.Player.SendMessageAsync($"You cannot set a negative amount.");
            return;
        }
        var initialBalance = VaultApi.GetBalance(player.Uuid.ToString());
        VaultApi.DeductBalance(player.Uuid.ToString(), initialBalance);
        VaultApi.AddBalance(player.Uuid.ToString(), amount);
        this.Player.SendMessageAsync($"{player.Username}'s balance has been set to {amount}");
    }
}
public class OtherCommands : CommandModuleBase
{
    [Inject] public ILogger<OtherCommands> Logger { get; set; }
    [Inject] public VaultApi VaultApi { get; set; }

    [Command("balance", "bal")]
    [CommandInfo("Gets the balance of a player.")]
    public async Task Balance()
    {
        var player = this.Player;
        var balance = VaultApi.GetBalance(player.Uuid.ToString());
        await this.Player.SendMessageAsync($"You have a balance of {balance}");
    }
    
    [Command("balance", "bal")]
    [CommandOverload]
    public async Task Balance(IPlayer player)
    {
        var balance = VaultApi.GetBalance(player.Uuid.ToString());
        await this.Player.SendMessageAsync($"{player.Username} has a balance of {balance}");
    }
    
    [Command("pay")]
    [CommandInfo("Pay a player money.")]
    public async Task Pay(IPlayer otherPlayer, int amount)
    {
        var player = this.Player;
        if (amount < 0)
        {
            player.SendMessageAsync($"You cannot pay a negative amount.");
            return;
        }
        var initialBalance = VaultApi.GetBalance(player.Uuid.ToString());
        if (initialBalance < amount)
        {
            player.SendMessageAsync($"You do not have enough money.");
            return;
        }
        VaultApi.DeductBalance(player.Uuid.ToString(), amount);
        VaultApi.AddBalance(otherPlayer.Uuid.ToString(), amount);
        player.SendMessageAsync($"You have paid {amount} to {otherPlayer.Username}");
        otherPlayer.SendMessageAsync($"You have been paid {amount} by {player.Username}");
    }
    
    [Command("baltop")]
    [CommandInfo("Gets the players with the highest balance.")]
    public async Task Baltop()
    {
        var baltop = VaultApi.GetTopBalances(10);

        var player = this.Player;

        if (!baltop.Any())
        {
            await player.SendMessageAsync("There are no players with a balance.");
            return;
        }

        var resultMessage = new StringBuilder("The players with the highest balance are:\n");
        foreach (var entry in baltop)
        {
            var serverPlayer = this.Server.GetPlayer(Guid.Parse(entry.Key));
            if (serverPlayer != null)
            {
                resultMessage.AppendLine($"{serverPlayer.Username} - {entry.Value:F2}");
            }
            else
            {
                resultMessage.AppendLine($"Unknown Player ({entry.Key}) - {entry.Value:F2}");
            }
        }

        await player.SendMessageAsync(resultMessage.ToString());
    }

}   