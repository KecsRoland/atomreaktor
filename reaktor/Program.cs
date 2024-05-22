using System;
using System.Threading;

namespace reaktor
{
    class Atomreaktor
    {
        private int aktualisHofok;
        private int aktualisVizHofok;
        private double aktualisEnergia;
        private bool mukodes;

        public Atomreaktor()
        {
            aktualisHofok = 0;
            aktualisEnergia = 0;
            mukodes = false;
        }

        public void Beinditas()
        {
            Console.WriteLine("A reaktor be lett indítva.");
            mukodes = true;
            Thread.Sleep(2000); 
            Console.Clear();
            Random rnd = new Random();
            aktualisHofok = rnd.Next(40, 101);

        }

        public void Leallitas()
        {
            if (!mukodes)
            {
                Console.WriteLine("A reaktor jelenleg nincs bekapcsolva, nincsenek elérhető adatok.");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }

            if (aktualisHofok >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Figyelem: A reaktor hőmérséklete magas! Biztosan le akarja állítani?");
                Console.WriteLine("1. Igen");
                Console.WriteLine("2. Nem");
                Console.Write("Válasz: ");
                string valasz = Console.ReadLine();
                if (valasz == "1")
                {
                    Console.WriteLine("A reaktor visszafordíthatatlan leolvadása elindult!!!!!!! A reaktor fel fog robbanni!");
                    Thread.Sleep(2000);
                    Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM!");
                    Environment.Exit(0);
                }
                else if (valasz == "2")
                {
                    Console.WriteLine("A reaktor leállítása megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.WriteLine("Érvénytelen válasz, a leállítás megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            else
            {
                Console.WriteLine("A reaktor le lett állítva.");
                Console.WriteLine($"Összesen generált áram: {aktualisEnergia:F2} GW");
                mukodes = false;
                Thread.Sleep(2000);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GeneraltAdatok()
        {
            if (!mukodes)
            {
                Console.WriteLine("A reaktor jelenleg nincs bekapcsolva, nincsenek elérhető adatok.");
                Thread.Sleep(2000);
                Console.Clear();
                return;
            }

            Random rnd = new Random();
            aktualisEnergia += rnd.NextDouble() * (1.0 - 0.1) + 0.1; // Véletlenszerű energia generálás

           
            aktualisHofok += rnd.Next(1, 13);

            if (aktualisHofok >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Biztosan akar adatokat generálni? A REAKTOR HŐMÉRSÉKELETE MAGAS!!!!");
                Console.WriteLine("1. Igen");
                Console.WriteLine("2. Nem");
                Console.Write("Válasz: ");
                string valasz = Console.ReadLine();
                if (valasz == "1")
                {
                    Console.WriteLine("A reaktor visszafordíthatatlan leolvadása elindult!!!!!!! A reaktor fel fog robbanni!");
                    Thread.Sleep(2000);
                    Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM!");
                    Environment.Exit(0);
                }
                else if (valasz == "2")
                {
                    Console.WriteLine("Az adatok generálása megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.WriteLine("Érvénytelen válasz, az adatok generálása megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }

            Console.WriteLine($"Hőfok: {aktualisHofok} Celsius fok, Generált energia: {aktualisEnergia:F2} GW");

            if (aktualisHofok >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Figyelem: A reaktor hőmérséklete magas! Biztosan új adatot akar generálni?");
                Console.WriteLine("1. Igen");
                Console.WriteLine("2. Nem");
                Console.Write("Válasz: ");
                string valasz = Console.ReadLine();
                if (valasz == "1")
                {
                    Console.WriteLine("A reaktor visszafordíthatatlan leolvadása elindult!!!!!!! A reaktor fel fog robbanni!");
                    Thread.Sleep(2000);
                    Console.WriteLine("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM!");
                    Environment.Exit(0);
                }
                else if (valasz == "2")
                {
                    Console.WriteLine("Az adatok generálása megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.WriteLine("Érvénytelen válasz, az adatok generálása megszakítva.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            else
            {
                Console.WriteLine("Nyomjon meg egy gombot a folytatáshoz...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void HutovizBeengedese()
        {
            Console.WriteLine("Hűtővíz be lett engedve, a reaktor lehűl 40 fokra.");
            aktualisHofok = 40;
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atomreaktor reaktor = new Atomreaktor();

            while (true)
            {
                Console.WriteLine("Menü:");
                Console.WriteLine("1. Beindítás");
                Console.WriteLine("2. Leállítás");
                Console.WriteLine("3. Generált adatok megjelenítése");
                Console.WriteLine("4. Hűtővíz beengedése");
                Console.WriteLine("5. Kilépés");

                Console.Write("Válasszon menüpontot: ");
                string input = Console.ReadLine();

                int valasztas;
                if (!int.TryParse(input, out valasztas))
                {
                    Console.WriteLine("Érvénytelen választás. Kérjük, válasszon egy számot a menüpontok közül.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                switch (valasztas)
                {
                    case 1:
                        reaktor.Beinditas();
                        break;
                    case 2:
                        reaktor.Leallitas();
                        break;
                    case 3:
                        reaktor.GeneraltAdatok();
                        break;
                    case 4:
                        reaktor.HutovizBeengedese();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A program leáll");
                        Console.WriteLine("3");
                        Thread.Sleep(500);
                        Console.WriteLine("2");
                        Thread.Sleep(500);
                        Console.WriteLine("1");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Érvénytelen választás.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
