namespace Awesomely.Extensions
{
    public static class IntegerExtensions
    {
        public static bool Between(this int a, int b, int c)
        {
            return (a >= b) && (a <= c);
        }
    }
}