using Xunit;
using Lab03;
namespace Lab03Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1 2", 0)]
        [InlineData("1 2 -3", -6)]
        [InlineData("1 2 3 4", 6)]
        [InlineData("1 2 3r", 2)]

        public void TestMultiple3NumbersReturnNumber(string input, int ecpectedOutput)
        {
            int result = Program.Multiple3Numbers(input);
            Assert.Equal(result, ecpectedOutput);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 2.5f)]
        [InlineData(new[] { 1,1}, 1f)]
        [InlineData(new[] {0,0,0},0f)]
        public void TestCalculateAvgReturnfloat(int [] input, float ecpectedOutput)
        {
            float result = Program.CalculateAvg(input);
            Assert.Equal(result, ecpectedOutput);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 1)]
        [InlineData(new[] { 1, 1 }, 1)]
        [InlineData(new[] { 1,1,1,2,2,2 }, 1)]
        public void TestFindMaxFeqReturnInt(int[] input, int ecpectedOutput)
        {
            int result = Program.FindMaxFeq(input);
            Assert.Equal(result, ecpectedOutput);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4,5 }, 5)]
        [InlineData(new[] { 1, 1,1 }, 1)]
        [InlineData(new[] { -1,-2,-3,-4 }, -1)]
        public void TestMaxReturnInt(int[] input, int ecpectedOutput)
        {
            int result = Program.Max(input);
            Assert.Equal(result, ecpectedOutput);
        }
        [Theory]
        [InlineData("This is a sentence.", new[] { "\"This: 4\"", "\"is: 2\"", "\"a: 1\"", "\"sentence.: 9\"" })]
        [InlineData("Hello world", new[] { "\"Hello: 5\"", "\"world: 5\"" })]
        [InlineData("1234567890", new[] { "\"1234567890: 10\"" })]
        public void TestGetWordAndLength(string sentence, string[] expectedOutput)
        {
            string[] result = Program.GetWordAndLength(sentence);
            Assert.Equal(expectedOutput, result);
        }
    }
}