namespace AuthorProblem
{
    using System;

    [Author("Peshko")]
    public class StartUp
    {
        [Author("Tisho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
