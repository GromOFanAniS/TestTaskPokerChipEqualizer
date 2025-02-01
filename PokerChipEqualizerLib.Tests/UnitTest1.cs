using PokerChipEqualizerLib;

namespace PokerChipEqualizerLib.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] chips = { 1, 5, 9, 10, 5 };
            Assert.Equal(12, Equalizer.EqualizeSteps(chips));
        }

        [Fact]
        public void Test2()
        {
            int[] chips = { 1, 2, 3 };
            Assert.Equal(1, Equalizer.EqualizeSteps(chips));
        }

        [Fact]
        public void Test3()
        {
            int[] chips = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2 };
            Assert.Equal(1, Equalizer.EqualizeSteps(chips));
        }
    }
}