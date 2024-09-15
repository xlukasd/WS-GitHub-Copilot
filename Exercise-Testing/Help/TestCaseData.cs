namespace Exercise_Testing.Help
{
    public class TestCaseScenarioData(int target, int[] elements, bool expected)
    {
        public bool Expected { get; } = expected;

        public int[] Elements { get; } = elements;

        public int Target { get; } = target;
    }
}
