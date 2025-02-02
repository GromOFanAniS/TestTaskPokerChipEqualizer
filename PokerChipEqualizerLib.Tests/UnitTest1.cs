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

        [Fact]
        public void Test4()
        {
            int[] chips = { 1, 1, 2, 4 };
            Assert.Equal(3, Equalizer.EqualizeSteps(chips));
        }

        [Fact]
        public void Test5()
        {
            int[] chips = { 0, 10, 0, 8, 3, 10, 7, 0, 9, 3 };
            Assert.Equal(24, Equalizer.EqualizeSteps(chips));
        }

        [Fact]
        public void MyIndexTest1()
        {
            List<int> ints = new List<int>(){ 1, 2, 3, 4, 5 };
            Assert.Equal(2, ints.MyIndexValue(1));
        }

        [Fact]
        public void MyIndexTest2()
        {
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5 };
            Assert.Equal(4, ints.MyIndexValue(-2));
        }
    }
}