using FinalProject.Core.Models;

namespace FinalProject.Core;

public class Game
{
    public List<Character> Characters { get; set; } = new();

    public void CreateCharacter(string name)
    {
        Characters.Add(new Character
        {
            Name = name,
            Health = 100,
            Damage = 20,
            Armor = 5,
            Resist = 0.1
        });
        Console.WriteLine($"Character '{name}' created.");
    }

    public void ListCharacters()
    {
        if (Characters.Count == 0)
        {
            Console.WriteLine("No characters.");
            return;
        }

        for (int i = 0; i < Characters.Count; i++)
        {
            var c = Characters[i];
            Console.WriteLine($"{i + 1}. {c.Name} (HP:{c.Health}, DMG:{c.Damage})");
        }
    }

    public void StartBattle()
    {
        if (Characters.Count < 2)
        {
            Console.WriteLine("Need at least 2 characters.");
            return;
        }

        var a = Characters[0];
        var b = Characters[1];

        Console.WriteLine($"Battle started: {a.Name} vs {b.Name}");

        var damage = Math.Max(0, a.Damage - b.Armor) * (1 - b.Resist);
        b.Health -= (int)damage;

        Console.WriteLine($"{a.Name} hits {b.Name} for {damage} damage.");
        Console.WriteLine($"{b.Name} HP: {b.Health}");
    }
}
