using System;
using System.Threading;

namespace Inlupp2Skelett
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Loop() // Initialisera spelet
        {
            List<GameObject> lista = new List<GameObject>(); //Ny
            
            const int frameRate = 5;
            GameWorld world = new GameWorld(lista);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            
            Player spelare = new Player("up"); // startar med masken uppåt
            lista.Add(spelare);
            /////////////////////////
            Random random = new Random();
            int posX = random.Next(0, 50);
            int posY = random.Next(0, 20);

            Food mat = new Food(posX,posY);
            lista.Add(mat);
            /////////////////////////

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        Console.WriteLine("Vill du verkligen avsluta? 1 = JA, 2 = NEJ ");
                        int menyVal = int.Parse(Console.ReadLine());
                        if (menyVal == 1)
                        {
                            Environment.Exit(0);
                        }
                        else if (menyVal == 2)
                        {
                            Console.Clear();
                            running = true;
                            spelare.direction = "down";
                        }
                        else Console.WriteLine("Välj 1 eller 2");
                        //Avsluta program etc.
                        break;
                    case ConsoleKey.W:
                        running = true;
                        spelare.direction = "up";
                        break;
                    case ConsoleKey.A:
                        running = true;
                        spelare.direction = "left";
                        break;
                    case ConsoleKey.S:
                        running = true;
                        spelare.direction = "down";
                        break;
                    case ConsoleKey.D:
                        running = true;
                        spelare.direction = "right";
                        break;


                        // TODO Lägg till logik för andra knapptryckningar
                        // ...
                }

                // Uppdatera världen och rendera om
                world.Update();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            // Switch meny med while-loop, medans Running == true, spela, när spelare trycker Q,
            // Fråga = vill du avsluta? ifall ja, avsluta med environment.exit(1); annars vid nej
            // Running = true;
            Loop();
        }
    }
}
