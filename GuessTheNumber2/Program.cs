namespace GuessTheNumber2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Gissa Numret!");
            int[] gameSetup = ChooseDifficulty();
            Console.WriteLine(gameSetup[0]);
            Console.WriteLine(gameSetup[1]);
        }

        static int[] ChooseDifficulty()
        {
            int[] setUp = new int[2];
            int span = 1;
            int numberOfGuesses = 2;
            Console.WriteLine("Välj svårighetsgrad");
            Console.WriteLine("1. Lätt (1-20, 5 gissningar)");
            Console.WriteLine("2. Mellan (1-25, 4 gissningar)");
            Console.WriteLine("3. Svår (1-30, 3 gissningar)");
            Console.WriteLine("4. Custom");
            setUp[0] = span;
            setUp[1] = numberOfGuesses;

            //int choice = int.Parse(Console.ReadLine());

            //switch (choice)
            //{
            //    case 1:

            //}

            return setUp;
        }
    }
}