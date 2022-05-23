using System;

namespace AuthorProblem
{
    [Author("Ivan")]
    public class StartUp
    {
        [Author("Dragan")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
