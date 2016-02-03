using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDice
{
    /// <summary>
    /// Usage: Dice D6 = new Dice(6);
    ///     D6.Flop(5) for flopping 5 dice.
    ///         foreach (Die d in D6.Flops) { ... }
    ///     D6.Roll(3,6); //To get the top 3 of 6 tries
    /// </summary>
    public class Dice
    {
        Random r = new Random();
        public int Sides { get; set; }
        public IQueryable<Die> Flops { get; set; }

        public Dice(int numberOfSides) { Sides = numberOfSides; }
        public int Flop(int number)
        {
            List<Die> flops = new List<Die>();
            if (Sides < 3) throw new NullReferenceException("Dice must have at least 3 sides.");
            for (int i = 0; i < number; i++)
                flops.Add(new Die(i, r.Next(1, Sides + 1)));
            Flops = flops.AsQueryable();
            return Flops.Sum(s => s.Value);
        }
    }

    public class Die
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public Die(int index, int value)
        {
            Index = index;
            Value = value;
        }
    }

    public static class helper
    {
        public static int Roll(this Dice dice, int top = 1, int flops = 1)
        {
            dice.Flop(flops);
            return dice.Flops
                .OrderByDescending(d => d.Value)
                .Take(top)
                .Sum(s => s.Value);
        }
    }
}
