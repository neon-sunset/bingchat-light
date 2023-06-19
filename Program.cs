using BingChat;

Assert(args.Length > 0);
var bing = new BingChatClient(new()
{
    CookieU = Environment.GetEnvironmentVariable("BING_COOKIE"),
    Tone = BingChatTone.Creative
});

var prompt = string.Join(' ', args);
Assert(!string.IsNullOrWhiteSpace(prompt));

static void Print(string text) =>
    Console.Write(text.Replace("\n", "\n\n"));

var chat = await bing.CreateConversation();
await chat
    .StreamAsync(prompt)
    .ForEachAsync(Print);

while (true)
{
    Console.Write("\nPrompt: ");
    Console.WriteLine();
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
        break;

    await chat
        .StreamAsync(input)
        .ForEachAsync(Print);
}
