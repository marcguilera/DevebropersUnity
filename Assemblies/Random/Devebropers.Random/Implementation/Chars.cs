namespace Devebropers.Random
{
    public static class Chars
    {
        public static readonly string Numbers = "0123456789";
        public static readonly string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string Uppercase = Lowercase.ToUpper();
        public static readonly string Letters = Lowercase + Uppercase;
    }
}