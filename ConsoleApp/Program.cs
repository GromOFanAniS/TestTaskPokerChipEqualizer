using PokerChipEqualizerLib;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> chips = new();

            string input = Console.ReadLine();

            foreach (var chip in input.Split(' '))
            {
                chips.Add(int.Parse(chip));
            }

            Console.WriteLine(Equalizer.EqualizeSteps(chips));
        }
    }
}
