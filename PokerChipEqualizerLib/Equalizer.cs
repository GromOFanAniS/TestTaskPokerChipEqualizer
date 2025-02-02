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

        private static List<(int index, int value)> GetListGreaterThanTarget(IList<int> chipCounts)
        {
            int targetChips = chipCounts.Sum() / chipCounts.Count;
            List<(int, int)> output = new();
            for (int i = 0; i < chipCounts.Count; i++)
            {
                if (chipCounts[i] > targetChips)
                {
                    output.Add((i, chipCounts[i]));
                }
            }
            return output;
        }

        public static int EqualizeSteps(IList<int> chipCounts)
        {
            List<int> output = new List<int>(chipCounts);
            List<(int index, int value)> greaterList = GetListGreaterThanTarget(output);
            int targetChips = output.Sum() / output.Count;
            int stepCount = 0;

            if (greaterList.Count < 1)
            {
                return stepCount;
            }

            int lookStep = 1;
            int greaterIndex = 0;

            while (!IsEqualized(output))
            {
                greaterList = GetListGreaterThanTarget(output).OrderByDescending(x => x.value).ToList();

                if (greaterIndex >= greaterList.Count)
                {
                    greaterIndex = 0;
                }

                int centerIndex = greaterList[greaterIndex].index;
                int leftIndex = output.MyIndex(centerIndex - lookStep);
                int rightIndex = output.MyIndex(centerIndex + lookStep);
                int centerLeftIndex = output.MyIndex(centerIndex - 1);
                int centerRightIndex = output.MyIndex(centerIndex + 1);
                int leftNeed = targetChips - output.MyIndexValue(leftIndex);
                int rightNeed = targetChips - output.MyIndexValue(rightIndex);

                if (leftNeed <= 0 && rightNeed <= 0)
                {
                    greaterIndex++;
                    if (greaterIndex >= greaterList.Count)
                    {
                        lookStep = (leftIndex == rightIndex || lookStep > output.Count / 2) ? 1 : lookStep + 1;
                        greaterIndex = 0;
                    }
                    continue;
                }

                if ((leftNeed <= rightNeed || rightNeed <= 0) && leftNeed > 0)
                {
                    for (int i = 0; i < leftNeed; i++)
                    {
                        if (output[centerIndex] <= targetChips)
                        {
                            break;
                        }
                        output[centerLeftIndex]++;
                        output[centerIndex]--;
                        stepCount++;
                    }
                    lookStep = 1;
                    continue;
                }

                if (rightNeed > 0)
                {
                    for (int i = 0; i < rightNeed; i++)
                    {
                        if (output[centerIndex] <= targetChips)
                        {
                            break;
                        }
                        output[centerRightIndex]++;
                        output[centerIndex]--;
                        stepCount++;
                    }
                    lookStep = 1;
                }
            }

            return stepCount;
        }
    }
}
