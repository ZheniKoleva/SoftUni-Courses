namespace _05.DateModifier
{
    using System;
    using System.Linq;

    public static class DateModifier
    {
        public static int DateDifference(string dateOne, string dateTwo)
        {
            int[] firstArgs = ExtractData(dateOne);
            int[] secondArgs = ExtractData(dateTwo);

            DateTime firstDate = new DateTime(firstArgs[0], firstArgs[1], firstArgs[2]);
            DateTime secondDate = new DateTime(secondArgs[0], secondArgs[1], secondArgs[2]);

            return (int)Math.Abs((firstDate - secondDate).TotalDays);
        }

        private static int[] ExtractData(string input)
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
