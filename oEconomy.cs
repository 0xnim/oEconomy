namespace oEconomy;

public sealed class oEconomy : PluginBase
{
    // Dependencies will be injected automatically, if dependency class and field/property names match
    // Plugins won't load until all their required dependencies are added
    // Optional dependencies may be injected at any time, if at all
    [Inject] public ILogger<oEconomy> Logger { get; set; }

    //You can register commands, events and soon to be items, blocks and entities
    public override void ConfigureRegistry(IPluginRegistry registry)
    {
        //Will scan for command classes and register them for you
        registry.MapCommands();
    }

    //Called when the plugin has fully loaded
    public override ValueTask OnLoadedAsync(IServer server)
    {
        Logger.LogInformation("§a{pluginName} §floaded! Hello §aEveryone§f!", Info.Name);

        return ValueTask.CompletedTask;
    }

    //Called when the world has loaded and the server is ready for connections
    public override ValueTask OnServerReadyAsync(IServer server)
    {
        Logger.LogInformation("Wow you can join the server!!");
        return ValueTask.CompletedTask;
    }

    //This is self explanatory (called when the plugin is being unloaded)
    public override ValueTask OnUnloadingAsync()
    {
        Logger.LogInformation("I'm unloading now :(");
        return ValueTask.CompletedTask;
    }
}