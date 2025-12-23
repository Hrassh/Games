using FinalProject.Core;
using FinalProject.Persistence;


Console.WriteLine("Type 'help' to see commands.");

var game = new Game();
var storage = new JsonStorage("save.json");

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) continue;

    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var cmd = parts[0].ToLower();

    switch (cmd)
    {
        case "help":
            Console.WriteLine("Commands:");
            Console.WriteLine(" list            - list characters");
            Console.WriteLine(" create          - create character");
            Console.WriteLine(" start           - start battle simulation");
            Console.WriteLine(" save            - save game");
            Console.WriteLine(" load            - load game");
            Console.WriteLine(" exit            - exit");
            break;

        case "list":
            game.ListCharacters();
            break;

        case "create":
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "Hero";
            game.CreateCharacter(name);
            break;

        case "start":
            game.StartBattle();
            break;

        case "save":
            storage.Save(game);
            Console.WriteLine("Game saved.");
            break;

        case "load":
            var loaded = storage.Load();
            if (loaded != null)
            {
                game = loaded;
                Console.WriteLine("Game loaded.");
            }
            break;

        case "exit":
            return;

        default:
            Console.WriteLine("Unknown command.");
            break;
    }
}
