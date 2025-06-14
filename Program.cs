
using Discord;
using Discord.WebSocket;    

namespace DiscordBotCSharp;

internal static class Program
{
    private static DiscordSocketClient? _client;
    
    public static async Task Main()
    {
        const string tokenPath = "token.txt";
        var token = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
        if (token == null)
        {
            Console.WriteLine("Cannot get discord bot token.");
            return;
        }
        
        _client = new DiscordSocketClient();

        _client.Log += message =>
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        };
        
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();
        
        await Task.Delay(-1);
    } 
}