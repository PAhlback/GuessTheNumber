namespace GuessTheNumber2
{

    //Pontus Ahlbäck, NET23

    internal class Program
    {
        static void Main(string[] args)
        {
            //Här startar programmet med att skicka användaren till funktionen för att välja svårighetsgrad. Den returnerar både
            //den högsta siffran för spannet, och antalet gissningar spelaren väljer. Det går att även att göra en "custom" svårighetsgrad.
            Console.WriteLine("Välkommen till Gissa Numret!");
            Console.WriteLine();
            int[] gameSetup = ChooseDifficulty(); //0 = span, 1 = numberOfGuesses

            //Genererar talet datorn tänker på.
            Random random = new Random();
            int computersNumber = random.Next(1, gameSetup[0]);

            //Här startar spelet. Det körs i en for-loop som kollar svaren i en funktion som heter CheckGuess.
            //CheckGuess skriver därefter ut om svaret var rätt eller fel. Den säger även om det var högt, lågt, eller nära.
            //I slutet körs funktionen PLayAgain, som kollar om spelaren vill spela igen.
            Console.WriteLine($"Jag tänker på en siffra mellan 1 - {gameSetup[0]}.");
            Console.WriteLine($"Du har totalt {gameSetup[1]} gissningar på dig.");
            Console.WriteLine("Nu kör vi!");

            for(int i = 1; i <= gameSetup[1]; i++)
            {
                Console.WriteLine();
                Console.Write($"Gissning {i}: ");
                int guess = int.Parse(Console.ReadLine());

                bool check = CheckGuess(guess, computersNumber, gameSetup[1], i);

                if (check == true)
                {
                    Console.WriteLine();
                    break;
                }
            }

            PlayAgain();

        }

        //Här väljer spelaren svårighetsgrad.
        static int[] ChooseDifficulty()
        {
            int span = 1;
            int numberOfGuesses = 2;
            
            Console.WriteLine("Välj svårighetsgrad");
            Console.WriteLine("1. Lätt (1-20, 5 gissningar)");
            Console.WriteLine("2. Mellan (1-25, 4 gissningar)");
            Console.WriteLine("3. Svår (1-30, 3 gissningar)");
            Console.WriteLine("4. Custom");
            int number = int.Parse(Console.ReadLine());

            do
            {
                switch (number)
                {
                    case 1:
                        span = 20;
                        numberOfGuesses = 5;
                        break;
                    case 2:
                        span = 25;
                        numberOfGuesses = 4;
                        break;
                    case 3:
                        span = 30;
                        numberOfGuesses = 3;
                        break;
                    case 4:
                        Console.Write("Ange högsta möjliga tal: ");
                        span = int.Parse(Console.ReadLine());
                        Console.Write("Ange antal gissningar: ");
                        numberOfGuesses = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.Write("Du kan bara skriva 1-4. Ange svårighetsgrad: ");
                        number = int.Parse(Console.ReadLine());
                        break;
                }
            } while (number < 1 || number > 4);

            Console.Clear();

            int[] setUp = { span, numberOfGuesses };

            return setUp;
        }

        //Här kollar datorn om gissningen är rätt. Det finns även tre funktioner inuti CheckGuess som används för att "lagra"
        //fraser som datorn kan ge. Jag gjorde så för att jag ville testa leka lite mer med funktioner. Datorn kollar om talet är rätt,
        //för och hur lågt eller högt, samt om gissningen är +-1 från rätt svar.
        static bool CheckGuess(int guess, int computersNumber, int numberOfGuesses, int i)
        {
            bool test = false;

            if (guess == computersNumber)
            {
                Console.WriteLine("DU VANN! Bra jobbat!");
                test = true;
            }
            else if (i == numberOfGuesses)
            {
                Console.WriteLine();
                Console.WriteLine("Du fick slut på försök. Bättre lycka nästa gång!");
                Console.WriteLine($"Rätt nummer var {computersNumber}.");
            }
            else if (Math.Abs(guess - computersNumber) <= 1)
            {
                CloseGuessStringArray(guess, computersNumber);
            }
            else if (guess < computersNumber)
            {
                LowGuessStringArray(guess, computersNumber);
            }
            else if (guess > computersNumber)
            {
                HighGuessStringArray(guess, computersNumber);
            }

            return test;

            static void LowGuessStringArray(int guess, int computersNumber)
            {
                Random random = new Random();
                int r = random.Next(0, 2);
                string[] answerFurtherThanFive = { "Vääääldigt låg gissning.", "Nu gissade du superlågt.", "Du måste gissa mycket högre." };
                string[] answer = { "Det var lite lågt.", "Nu gissade du lågt.", "Gissa högre." };

                if (Math.Abs(guess - computersNumber) > 5)
                {
                    Console.WriteLine(answerFurtherThanFive[r]);
                }
                else
                {
                    Console.WriteLine(answer[r]);
                }
            }

            static void HighGuessStringArray(int guess, int computersNumber)
            {
                Random random = new Random();
                int r = random.Next(0, 2);
                string[] answerFurtherThanFive = { "Vääääldigt hög gissning.", "Nu gissade du superhögt.", "Du måste gissa mycket lägre." };
                string[] answer = { "Det var lite högt.", "Nu gissade du högt.", "Gissa lägre." };

                if (Math.Abs(guess - computersNumber) > 5)
                {
                    Console.WriteLine(answerFurtherThanFive[r]);
                }
                else
                {
                    Console.WriteLine(answer[r]);
                }
            }

            static void CloseGuessStringArray(int guess, int computersNumber)
            {
                Random random = new Random();
                int r = random.Next(1, 3);
                string[] answer = { "Nu var du riktigt nära!", "Nu bränns det!", "Ojoj, närmare kan man inte komma!" };

                Console.WriteLine(answer[r]);
            }
        }

        //Funktion för att spela spelet igen.
        static void PlayAgain()
        {
            Console.WriteLine("Vill du spela igen? (y/n)");
            char yesNo = char.Parse(Console.ReadLine());
            if (yesNo == 'y')
            {
                Console.Clear();
                string[] s = new string[0];
                Main(s);
            } else if (yesNo == 'n')
            {
                Environment.Exit(0);
            } else
            {
                Console.WriteLine("Skriv endast y/n.");
                PlayAgain();
            }
        }
    }
}