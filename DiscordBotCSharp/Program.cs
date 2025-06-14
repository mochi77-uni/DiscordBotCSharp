
using Discord;
using Discord.WebSocket;    

namespace DiscordBotCSharp;

internal static class Program
{
    private static DiscordSocketClient? _client;
    
    public static async Task Main()
    {
        var token = "";
        try
        {
            const string tokenPath = "token.txt";
            token = await File.ReadAllTextAsync(tokenPath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to read token.txt");
            Console.WriteLine(e);
            throw;
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