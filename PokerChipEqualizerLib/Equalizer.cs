namespace PokerChipEqualizerLib
{
    public class Equalizer
    {
        private static bool IsEqualized(IList<int> chipCounts)
        {
            int targetChips = chipCounts.Sum() / chipCounts.Count;
            foreach (int chip in chipCounts)
            {
                if (chip < targetChips)
                {
                    return false;
                }
            }
            return true;
        }

        public static int EqualizeSteps(IList<int> chipCounts)
        {
            List<int> output = new List<int>(chipCounts);
            int targetChips = output.Sum() / output.Count;
            int minIndex = 0;
            int minValue = output[minIndex];
            int stepCount = 0;
            
            for (int i = 0; i < output.Count; i++)
            {
                if (output[i] < targetChips && output[i] < minValue)
                {
                    minIndex = i;
                    minValue = output[minIndex];
                }
            }

            if (minValue >= targetChips)
            {
                return stepCount;
            }

            while (output[minIndex] < targetChips)
            {
                foreach (var el in output)
                {
                    Console.Write($"{el} ");
                }
                Console.WriteLine();
                int indexSteps = output.Count / 2;
                for (int i = 1; i <= indexSteps; i++)
                {
                    int left = output.MyIndexValue(minIndex - i);
                    int right = output.MyIndexValue(minIndex + i);
                    if (left <= targetChips && right <= targetChips)
                    {
                        continue;
                    }

                    if (left >= right)
                    {
                        output[output.MyIndex(minIndex - i)]--;
                        output[output.MyIndex(minIndex - i + 1)]++;
                        break;
                    }
                    output[output.MyIndex(minIndex + i)]--;
                    output[output.MyIndex(minIndex + i - 1)]++;
                    break;
                }

                stepCount++;

                if (!IsEqualized(output))
                {
                    for (int i = 0; i < output.Count; i++)
                    {
                        if (output[i] < targetChips && output[i] < minValue)
                        {
                            minIndex = i;
                            minValue = output[minIndex];
                        }
                    }
                }
            }

            foreach (var el in output)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();

            return stepCount;
        }
    }
}
