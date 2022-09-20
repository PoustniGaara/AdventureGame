using AdventureGameClassLibrary;
using System.Text;
using System.Threading;

namespace AdventureGameTUI
{
    class ConsoleApp
    {
        private static GameController gameController = new GameController();
        static void Main(string[] args)
        {
            gameController.CreateGame();
            WriteWelcomeMessage();
            RunGameLoop();
        }

        private static void RunGameLoop()
        {
            while (!gameController.GameIsFinished())
            {
                Console.WriteLine("Press space to fight a new monster / Press ESC to end");
                ConsoleKeyInfo info = Console.ReadKey();
                if(info.Key == ConsoleKey.Spacebar)
                {
                    gameController.StartNewGameOrJustGetNewMonster();
                    IntroduceMonster();
                    RunFightLoop(); 
                }
                if(info.Key == ConsoleKey.Escape) { break;  }
                //else { continue; }
            }
            EndGame();
        }

        private static void RunFightLoop()
        {
            while (!gameController.FightIsFinished())
            {
                Console.WriteLine("\nPress space key to play a round");
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Spacebar)
                {
                    gameController.PlayRound();
                    Console.WriteLine(gameController.GetRoundStatus());
                }
                else { continue; }  
            }

            PrintFightSummary();
        }

        static void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine("Game Over!");
            Console.WriteLine();
            Console.WriteLine($"You reached {gameController.GetPlayer().ExperiencePoints}XP and required {gameController.GetPlayer().Gold} golds");

        }

        static void PrintFightSummary()
        {
            Console.WriteLine();
            Console.WriteLine(gameController.GetFightSummary());
            Console.WriteLine();
        }

        static void IntroduceMonster()
        {
            Console.WriteLine();
            Console.WriteLine($"The following monster steps forward and introduces itself:");
            Console.WriteLine($"{gameController.GetMonster()}");
        }

        static void WriteWelcomeMessage()
        {
            Console.WriteLine("WELCOME TO THE ADVENTURE GAME! \nSee if you can beat the highscore");
            Console.WriteLine();
            Console.WriteLine($"Your character introduces itself: {gameController.GetPlayer()}");


        }
    }
     
}
