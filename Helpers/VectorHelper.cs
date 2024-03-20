namespace Arm64.DesktopApp.WPF.Helpers
{
    public static class VectorHelper
    {
        private static readonly Random random = new();

        private static double[] GenerateRandomVector(int size, double minValue = 0, double maxValue = 1)
        {
            return Enumerable.Range(0, size)
                             .Select(_ => random.NextDouble() * (maxValue - minValue) + minValue)
                             .ToArray();
        }

        public static double[] AdditionOfProduct(int size, double minValue = 0, double maxValue = 1)
        {
            var a = GenerateRandomVector(size, minValue, maxValue);
            var b = GenerateRandomVector(size, minValue, maxValue);
            var c = GenerateRandomVector(size, minValue, maxValue);

            var result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = a[i] * b[i] + c[i];
            }

            return result;
        }
    }
}
