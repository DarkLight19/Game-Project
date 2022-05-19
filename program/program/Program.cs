using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{

    class Program
    {
        public class Game
        {
            public string name { get; set; }
            public List<string> tags { get; set; }

            public Game(string n, List<string> t)
            {
                this.name = n;
                this.tags = new List<string>(t);
            }

            public Game()
            {
                this.tags = new List<string>();
            }
        }

        public static List<ConsoleColor> colors = new List<ConsoleColor>() { ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Magenta };
        public static List<Game> x = new List<Game>();
        public static List<string> allTags = new List<string>();

        static void Main(string[] args)
        {
            load();
            menu();
        }

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("Üdvözöllek a menüben, az alábi opciók közül lehet választani :");
            Console.WriteLine();

            coloredText(ConsoleColor.Yellow);
            Console.WriteLine("(1) Adat felvétele");
            Console.WriteLine();

            coloredText(ConsoleColor.Green);
            Console.WriteLine("(2) Adat változtatása");
            Console.WriteLine();

            coloredText(ConsoleColor.Blue);
            Console.WriteLine("(3) Adatok lekérdezése");
            Console.WriteLine();

            coloredText(ConsoleColor.Magenta);
            Console.WriteLine("(4) Az összes adat felsorolása");
            Console.WriteLine();

            coloredText(ConsoleColor.DarkGreen);
            Console.WriteLine("(5) Az összes tag felsorolása");
            Console.WriteLine();

            coloredText(ConsoleColor.DarkYellow);
            Console.WriteLine("(6) Tag-ek felvétele");
            Console.WriteLine();

            coloredText(ConsoleColor.Red);
            Console.WriteLine("(7) Tag-ek törlése");
            Console.WriteLine();

            coloredText(ConsoleColor.DarkRed);
            Console.WriteLine("(8) Adathalmaz törlése");
            Console.WriteLine();

            coloredText(ConsoleColor.Yellow);
            Console.WriteLine("(9) Beolvasás fájlból");
            Console.WriteLine();

            coloredText(ConsoleColor.Cyan);
            Console.Write("-----> ");
            coloredText(ConsoleColor.White);

            int valasztas = int.Parse(Console.ReadLine().ToString());
            Console.SetCursorPosition(8, Console.CursorTop - 1);

            coloredText(ConsoleColor.Cyan);
            Console.WriteLine(" <-----");
            Console.WriteLine();

            if (valasztas == 1)
            {
                add();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // add
            else if (valasztas == 2)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    coloredText(colors[(int)(((double)i/colors.Count-i/colors.Count)* colors.Count)]);
                    Console.Write("(" + i + ") " + x[i].name + " ");
                    foreach (var item in x[i].tags)
                    {
                        coloredText(ConsoleColor.DarkBlue);
                        Console.Write("|");
                        coloredText(ConsoleColor.Cyan);
                        Console.Write(item);
                    }
                    coloredText(ConsoleColor.DarkBlue);
                    Console.WriteLine("|");
                }

                Console.WriteLine();
                coloredText(ConsoleColor.Cyan);
                Console.Write("-----> ");
                coloredText(ConsoleColor.White);

                int chosenIndex = int.Parse(Console.ReadLine().ToString());

                Console.WriteLine(chosenIndex);
                if (chosenIndex > 1000)
                    Console.SetCursorPosition(11, Console.CursorTop - 1);
                else if (chosenIndex > 100)
                    Console.SetCursorPosition(10, Console.CursorTop - 1);
                else if (chosenIndex > 10)
                    Console.SetCursorPosition(9, Console.CursorTop - 1);
                else
                    Console.SetCursorPosition(8, Console.CursorTop - 1);

                coloredText(ConsoleColor.Cyan);
                Console.WriteLine(" <-----");
                Console.WriteLine();
                coloredText(ConsoleColor.White);

                if (chosenIndex < 0 || chosenIndex > x.Count - 1)
                {
                    coloredText(ConsoleColor.Red);
                    Console.WriteLine("HELYTELEN ÉRTÉK");
                    coloredText(ConsoleColor.White);
                    Console.Write("Vissza a Menübe...");
                    Console.ReadLine();
                    menu();
                }
                else
                {
                    Console.Write("Kiválasztott adat : ");
                    coloredText(ConsoleColor.Red);
                    Console.Write("|");
                    coloredText(ConsoleColor.Blue);
                    Console.Write(x[chosenIndex].name);
                    coloredText(ConsoleColor.Red);
                    Console.WriteLine("|");
                    coloredText(ConsoleColor.White);
                    Console.WriteLine();

                    edit(x[chosenIndex]);

                    coloredText(ConsoleColor.White);
                    Console.WriteLine();
                    Console.Write("Vissza a Menübe...");
                    Console.ReadLine();
                    menu();
                }
            } // edit(Game)
            else if (valasztas == 3)
            {
                query();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // query()
            else if (valasztas == 4)
            {
                showAll();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // showAll()
            else if (valasztas == 5)
            {
                showAllTags();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // showAllTags()
            else if (valasztas == 6)
            {
                addTags();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // addTags()
            else if (valasztas == 7)
            {
                removeTags();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // removeTags()
            else if (valasztas == 8)
            {
                deleteDatabase();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // deleteDatabase()
            else if (valasztas == 9)
            {
                loadFromFile();

                coloredText(ConsoleColor.White);
                Console.WriteLine();
                Console.Write("Vissza a Menübe...");
                Console.ReadLine();
                menu();
            } // loadFromFile()
        }

        public static void addTags()
        {
            Console.Write("Sorolja fel (',' - vel elválasztva) a tag-eket : ");
            coloredText(ConsoleColor.Cyan);
            string tags = Console.ReadLine();
            coloredText(ConsoleColor.White);

            string[] temp = tags.Split(',');
            for (int j = 0; j < temp.Length; j++)
            {
                string item = temp[j];
                for (int i = 0; i < item.Length; i++)
                    if (item[i] != ' ')
                    {
                        string tempTag = item.Remove(0, i);
                        if (!allTags.Contains(tempTag))
                            allTags.Add(tempTag);
                        break;
                    }
            }

            save();
        }

        public static void removeTags()
        {
            for (int i = 0; i < allTags.Count; i++)
            {
                coloredText(colors[(int)(((double)i / colors.Count - i / colors.Count)* colors.Count)]);
                Console.WriteLine("(" + i + ") " + allTags[i]);
            }
            coloredText(ConsoleColor.White);
            Console.WriteLine();

            Console.Write("Sorolja fel (',' - vel elválasztva) a törlendő tag-ek sorszámát : ");
            coloredText(ConsoleColor.Cyan);
            string temp = Console.ReadLine();
            coloredText(ConsoleColor.White);

            List<int> deleteIndex = new List<int>();

            foreach (var item in temp.Split(','))
            {
                for (int i = 0; i < item.Length; i++)
                    if (item[i] != ' ')
                    {
                        deleteIndex.Add(int.Parse(item.Remove(0, i)));
                        break;
                    }
            }

            deleteIndex.Sort();
            deleteIndex.Reverse();


            foreach (var item in x)
                foreach (var i in deleteIndex)
                    if (item.tags.Contains(allTags[i]))
                        item.tags.Remove(allTags[i]);

            foreach (var item in deleteIndex)
                if (item > 0 && item < allTags.Count - 1)
                    allTags.RemoveAt(item);

            save();
        }

        public static void showAll()
        {
            Console.WriteLine();
            for (int i = 0; i < x.Count; i++)
            {
                coloredText(colors[i % colors.Count]);
                Console.Write("(" + i + ") " + x[i].name + " ");
                foreach (var item in x[i].tags)
                {
                    coloredText(ConsoleColor.DarkBlue);
                    Console.Write("|");
                    coloredText(ConsoleColor.Cyan);
                    Console.Write(item);
                }
                coloredText(ConsoleColor.DarkBlue);
                Console.WriteLine("|");
            }
            coloredText(ConsoleColor.White);
            Console.WriteLine();
        }

        public static void showAllTags()
        {
            List<string> voltmar = new List<string>();
            Console.WriteLine();
            for (int i = 0; i < allTags.Count; i++)
            {
                if (voltmar.Contains(allTags[i]))
                    continue;

                coloredText(colors[i % colors.Count]);
                Console.WriteLine(allTags[i]);

                voltmar.Add(allTags[i]);
            }
            
            coloredText(ConsoleColor.White);
            Console.WriteLine();
        }

        public static void edit(Game game)
        {
            coloredText(ConsoleColor.Yellow);
            Console.WriteLine("Név változtatása : (1)");

            coloredText(ConsoleColor.Green);
            Console.WriteLine("Tag törlése : (2)");

            coloredText(ConsoleColor.Blue);
            Console.WriteLine("Tag hozzáadása : (3)");

            coloredText(ConsoleColor.Cyan);
            Console.Write("-----> ");
            coloredText(ConsoleColor.White);

            int valasztas = int.Parse(Console.ReadLine()[0].ToString());
            Console.SetCursorPosition(8, Console.CursorTop - 1);

            coloredText(ConsoleColor.Cyan);
            Console.WriteLine(" <-----");
            coloredText(ConsoleColor.White);

            if (valasztas == 1)
            {
                Console.WriteLine();
                Console.Write("Új név megadása : ");
                coloredText(ConsoleColor.Yellow);
                string newName = Console.ReadLine();

                Console.WriteLine();
                coloredText(ConsoleColor.White);
                Console.Write("Az új név : ");
                coloredText(ConsoleColor.Red);
                Console.Write("|");
                coloredText(ConsoleColor.Blue);
                Console.Write(newName);
                coloredText(ConsoleColor.Red);
                Console.WriteLine("|");

                Console.WriteLine();
                coloredText(ConsoleColor.White);
                Console.WriteLine("Menteni akarja ?");

                coloredText(ConsoleColor.Green);
                Console.Write("    IGEN (1) ");
                coloredText(ConsoleColor.White);
                Console.Write("|");
                coloredText(ConsoleColor.Red);
                Console.Write(" NEM (2)");
                Console.WriteLine();
                Console.WriteLine();

                coloredText(ConsoleColor.Cyan);
                Console.Write("-----> ");
                coloredText(ConsoleColor.White);

                int wannasave = int.Parse(Console.ReadLine()[0].ToString());
                Console.SetCursorPosition(8, Console.CursorTop - 1);

                coloredText(ConsoleColor.Cyan);
                Console.WriteLine(" <-----");
                coloredText(ConsoleColor.White);

                if (wannasave == 1)
                {
                    game.name = newName;
                    save();
                }

                return;
            } //name change
            else if (valasztas == 2)
            {
                Console.WriteLine();
                for (int i = 0; i < game.tags.Count; i++)
                {
                    coloredText(colors[i % colors.Count]);
                    Console.WriteLine("(" + i + ") " + game.tags[i]);
                }

                Console.WriteLine();
                coloredText(ConsoleColor.Cyan);
                Console.Write("-----> ");
                coloredText(ConsoleColor.White);

                int chosenIndex = int.Parse(Console.ReadLine()[0].ToString());
                if (chosenIndex > 1000)
                    Console.SetCursorPosition(11, Console.CursorTop - 1);
                else if (chosenIndex > 100)
                    Console.SetCursorPosition(10, Console.CursorTop - 1);
                else if (chosenIndex > 10)
                    Console.SetCursorPosition(9, Console.CursorTop - 1);
                else
                    Console.SetCursorPosition(8, Console.CursorTop - 1);

                coloredText(ConsoleColor.Cyan);
                Console.WriteLine(" <-----");
                Console.WriteLine();
                coloredText(ConsoleColor.White);

                if (chosenIndex < 0 || chosenIndex > game.tags.Count - 1)
                    return;

                game.tags.RemoveAt(chosenIndex);
                save();
            } //delete tag
            else if (valasztas == 3)
            {
                Console.WriteLine();
                List<string> hozzaAdhatoTagek = allTags.Where(kk => !game.tags.Contains(kk)).ToList();
                for (int i = 0; i < hozzaAdhatoTagek.Count; i++)
                {
                    coloredText(colors[i % colors.Count]);
                    Console.WriteLine("(" + i + ") " + hozzaAdhatoTagek[i]);
                }
                coloredText(ConsoleColor.White);
                Console.WriteLine();

                Console.Write("Sorolja fel (',' - vel elválasztva) a hozáadandó tag-ek sorszámát : ");
                coloredText(ConsoleColor.Cyan);
                string temp = Console.ReadLine();
                coloredText(ConsoleColor.White);
                Console.WriteLine();
                coloredText(ConsoleColor.White);

                List<int> indexes = new List<int>();

                foreach (var item in temp.Split(','))
                    for (int i = 0; i < item.Length; i++)
                        if (item[i] != ' ')
                        {
                            int tempTagIndex = int.Parse(item.Remove(0, i));
                            if (!indexes.Contains(tempTagIndex))
                                indexes.Add(tempTagIndex);
                            break;
                        }

                foreach (var item in indexes)
                    if (!game.tags.Contains(hozzaAdhatoTagek[item]))
                        game.tags.Add(hozzaAdhatoTagek[item]);

                Console.WriteLine();
            } //add tag

            Console.WriteLine();
            save();
        }

        public static void deleteDatabase()
        {
            coloredText(ConsoleColor.White);
            Console.WriteLine("Törli az egész adatbázist ?");

            coloredText(ConsoleColor.Green);
            Console.Write("    IGEN (1) ");
            coloredText(ConsoleColor.White);
            Console.Write("|");
            coloredText(ConsoleColor.Red);
            Console.Write(" NEM (2)");
            Console.WriteLine();
            Console.WriteLine();

            coloredText(ConsoleColor.Cyan);
            Console.Write("-----> ");
            coloredText(ConsoleColor.White);

            int wannaDelete = int.Parse(Console.ReadLine()[0].ToString());
            Console.SetCursorPosition(8, Console.CursorTop - 1);

            coloredText(ConsoleColor.Cyan);
            Console.WriteLine(" <-----");
            coloredText(ConsoleColor.White);

            if (wannaDelete != 1)
                return;

            System.IO.StreamWriter f = new System.IO.StreamWriter("database.txt");
            System.IO.StreamWriter d = new System.IO.StreamWriter("tagdatabase.txt");
            x = new List<Game>();
            allTags = new List<string>();
            f.Close();
            d.Close();
        }

        public static void save()
        {
            Console.WriteLine();
            Console.Write("Mentés...");
            using (System.IO.StreamWriter f = new System.IO.StreamWriter("database.txt"))
            {
                foreach (var item in x)
                {
                    f.Write(item.name + ",");
                    for (int i = 0; i < item.tags.Count-1; i++)
                        f.Write(item.tags[i] + ",");
                    f.Write(item.tags[item.tags.Count - 1]);

                    f.WriteLine();
                }
            }
            using (System.IO.StreamWriter f = new System.IO.StreamWriter("tagdatabase.txt"))
            {
                foreach (var item in allTags)
                    f.WriteLine(item);
            }

            load();

            coloredText(ConsoleColor.Green);
            Console.WriteLine(" - Kész!");
            coloredText(ConsoleColor.White);
        }

        public static void load()
        {
            x = new List<Game>();

            string[] s = System.IO.File.ReadAllLines("database.txt");
            double step = (double)s.Length / progressBarSize;
            long currentstep = 0;

            startProgressBar();
            foreach (var item in s)
            {
                string[] temp = item.Split(',');
                List<string> tagek = new List<string>();
                for (int i = 1; i < temp.Length; i++)
                    tagek.Add(temp[i]);

                x.Add(new Game(temp[0], tagek));

                if (currentstep > step * (progressBarCurrentStep + 1))
                    progressBarStep();
            }

            allTags = new List<string>();
            s = System.IO.File.ReadAllLines("tagdatabase.txt");
            foreach (var item in s)
                allTags.Add(item);

            endProgressBar();
        }

        public static void add()
        {
            Console.Write("Játék neve : ");
            coloredText(ConsoleColor.Green);
            string gameName = Console.ReadLine();
            coloredText(ConsoleColor.White);
            Console.WriteLine("Tag-ek kiválasztása : ");
            Console.WriteLine();

            for (int i = 0; i < allTags.Count; i++)
            {
                coloredText(colors[i % colors.Count]);
                Console.WriteLine("(" + i + ") " + allTags[i] + " ");
            }
            coloredText(ConsoleColor.White);
            Console.WriteLine();

            Console.Write("Sorolja fel a válaszott tag-ek sorszámait : ");
            coloredText(ConsoleColor.Blue);
            string gameTags = Console.ReadLine();

            using (System.IO.StreamWriter f = System.IO.File.AppendText("database.txt"))
            {
                Game game = new Game();
                f.Write(gameName + ",");
                game.name = gameName;
                

                string[] temp = gameTags.Split(',');
                for (int j = 0; j < temp.Length-1; j++)
                {
                    string item = temp[j];
                    for (int i = 0; i < item.Length; i++)
                        if (item[i] != ' ')
                        {
                            game.tags.Add(allTags[int.Parse(item.Remove(0, i))]);
                            f.Write(allTags[int.Parse(item.Remove(0, i))] + ",");
                            break;
                        }
                }
                for (int i = 0; i < temp[temp.Length-1].Length; i++)
                    if (temp[temp.Length - 1][i] != ' ')
                    {
                        game.tags.Add(allTags[int.Parse(temp[temp.Length - 1].Remove(0, i))]);
                        f.Write(allTags[int.Parse(temp[temp.Length - 1].Remove(0, i))]);
                        break;
                    }

                x.Add(game);

                f.WriteLine();
            }

            return;
        }

        public static void query()
        {
            Console.WriteLine();

            coloredText(ConsoleColor.Yellow);
            Console.WriteLine("(1) Szűrés nevekre");
            Console.WriteLine();

            coloredText(ConsoleColor.Blue);
            Console.WriteLine("(2) Szűrés tag-ekre");
            Console.WriteLine();

            coloredText(ConsoleColor.Cyan);
            Console.Write("-----> ");
            coloredText(ConsoleColor.White);

            int valasztas = int.Parse(Console.ReadLine()[0].ToString());
            Console.SetCursorPosition(8, Console.CursorTop - 1);

            coloredText(ConsoleColor.Cyan);
            Console.WriteLine(" <-----");
            coloredText(ConsoleColor.White);
            Console.WriteLine();

            if(valasztas == 1)
            {
                Console.Write("Név (/Nevek ',' elválasztva) : ");
                coloredText(ConsoleColor.Yellow);
                string s = Console.ReadLine();
                List<string> temp = new List<string>();

                foreach (string item in s.Split(','))
                    for (int i = 0; i < item.Length; i++)
                        if (item[i] != ' ')
                        {
                            temp.Add(item.Remove(0, i));
                            break;
                        }

                List<Game> foundStuff = new List<Game>();

                foreach (var item in temp)
                    foreach (var i in x)
                        if(i.name == item)
                        {
                            foundStuff.Add(i);
                            break;
                        }

                for (int i = 0; i < foundStuff.Count; i++)
                {
                    coloredText(colors[i % colors.Count]);
                    Console.Write("(" + i + ") " + foundStuff[i].name + " ");
                    foreach (var item in foundStuff[i].tags)
                    {
                        coloredText(ConsoleColor.DarkBlue);
                        Console.Write("|");
                        coloredText(ConsoleColor.Cyan);
                        Console.Write(item);
                    }
                    coloredText(ConsoleColor.DarkBlue);
                    Console.WriteLine("|");
                    coloredText(ConsoleColor.White);
                }

            } //search by name
            else
            {
                for (int i = 0; i < allTags.Count; i++)
                {
                    coloredText(colors[i % colors.Count]);
                    Console.WriteLine("(" + i + ") " + allTags[i] + " ");
                }

                Console.WriteLine();
                coloredText(ConsoleColor.White);

                Console.Write("Tag-ek indexe ',' elválasztva : ");
                coloredText(ConsoleColor.Yellow);
                string s = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Hány db tag stimmeljen ");
                coloredText(ConsoleColor.DarkGray);
                Console.Write("(pl.: 4/2 akkor 2 őt írjon) ");
                coloredText(ConsoleColor.White);
                Console.Write(": " + s.Split(',').Length + " / ");
                coloredText(ConsoleColor.Yellow);
                int stimm = int.Parse(Console.ReadLine());
                Console.WriteLine();
                coloredText(ConsoleColor.White);

                List<string> temp = new List<string>();

                foreach (string item in s.Split(','))
                    for (int i = 0; i < item.Length; i++)
                        if (item[i] != ' ')
                        {
                            string tempTag = allTags[int.Parse(item.Remove(0, i))];
                            if (!temp.Contains(tempTag))
                                temp.Add(tempTag);
                            break;
                        }

                List<(Game, int)> foundStuff = new List<(Game, int)>();

                foreach (var item in x)
                {
                    int szamlalo = 0;
                    foreach (var i in temp)
                        if (item.tags.Contains(i))
                            ++szamlalo;

                    foundStuff.Add((item, szamlalo));
                }


                for (int i = 0; i < foundStuff.Count; i++)
                {
                    if (foundStuff[i].Item2 < stimm)
                        continue;

                    coloredText(colors[i % colors.Count]);
                    Console.Write("(" + i + ") " + foundStuff[i].Item1.name + " ");
                    foreach (var item in foundStuff[i].Item1.tags)
                    {
                        coloredText(ConsoleColor.DarkBlue);
                        Console.Write("|");
                        coloredText(ConsoleColor.Cyan);
                        Console.Write(item);
                    }
                    coloredText(ConsoleColor.DarkBlue);
                    Console.Write("|");

                    coloredText(ConsoleColor.DarkGreen);
                    Console.WriteLine(" - " + foundStuff[i].Item2 + "p");
                }

            } //search by Tags
        }

        public static void loadFromFile()
        {
            coloredText(ConsoleColor.White);
            Console.WriteLine();

            Console.Write("Fájl elérési útvonala : ");
            coloredText(ConsoleColor.Cyan);
            string path = Console.ReadLine();

            coloredText(ConsoleColor.White);
            Console.WriteLine();
            Console.Write("Betöltés... ");

            string[] fajlSzoveg = System.IO.File.ReadAllLines(path);
            foreach (var item in fajlSzoveg)
            {
                string[] s = item.Split(',');

                string name = "";
                for (int i = 0; i < s[0].Length; i++)
                    if (s[0][i] != ' ')
                    {
                        name = s[0].Remove(0, i);
                        break;
                    }

                if (x.Where(kk => kk.name == name).Count() == 0)
                {
                    Game a = new Game();
                    a.name = name;
                    for (int i = 1; i < s.Length; i++)
                        for (int j = 0; j < s[i].Length; j++)
                            if (s[i][j] != ' ')
                            {
                                string tempTag = s[i].Remove(0, j);
                                if (!a.tags.Contains(tempTag))
                                    a.tags.Add(tempTag);
                                if (!allTags.Contains(tempTag))
                                    allTags.Add(tempTag);
                                break;
                            }
                    x.Add(a);
                }// még nem létezik ez a game
                else
                {
                    Game a = x.Where(kk => kk.name == name).ToList()[0];
                    a.name = name;
                    for (int i = 1; i < s.Length; i++)
                        for (int j = 0; j < s[i].Length; j++)
                            if (s[i][j] != ' ')
                            {
                                string tempTag = s[i].Remove(0, j);
                                if (!a.tags.Contains(tempTag))
                                    a.tags.Add(tempTag);
                                if (!allTags.Contains(tempTag))
                                    allTags.Add(tempTag);
                                break;
                            }
                }// már létezik ez a game
            }

            coloredText(ConsoleColor.Green);
            Console.Write("- Kész!");
            coloredText(ConsoleColor.White);
            Console.WriteLine();

            save();
        }


        //Plans:

        /* Lehetőség 1: adatok beadása TICK
         * Lehetőség 2: adatok módosítása TICK
         * Lehetőség 3: adatok törlése TICK
         * 
         * Lehetőség 4: adott tag-ek alaján szűrés TICK
         * Lehetőség 4.2: adott tag-ek alaján szűrés + megadott számú megfelelés TICK
         * 
         * Lehetőség 5: eredmény fájlba írása
         * Lehetőség 6: Fájlból való beolvasás
         */

        //hasznos cuccok:

        /* using (System.IO.StreamWriter f = System.IO.File.AppendText("database.txt")) // beleírni egy már létező txtbe
         * Console.Clear(); //törli a képernyőt
         * 
         * Console.WriteLine();
                coloredText(ConsoleColor.Cyan);
                Console.Write("-----> ");
                coloredText(ConsoleColor.White);

                int chosenIndex = int.Parse(Console.ReadLine()[0].ToString());
                if (chosenIndex > 1000)
                    Console.SetCursorPosition(11, Console.CursorTop - 1);
                else if (chosenIndex > 100)
                    Console.SetCursorPosition(10, Console.CursorTop - 1);
                else if (chosenIndex > 10)
                    Console.SetCursorPosition(9, Console.CursorTop - 1);
                else
                    Console.SetCursorPosition(8, Console.CursorTop - 1);

                coloredText(ConsoleColor.Cyan);
                Console.WriteLine(" <-----");
                Console.WriteLine();
                coloredText(ConsoleColor.White);
         * 
         */

        #region quality of life

        #region progressbar

        public static int progressBarSize = 10;
        public static int progressBarCurrentStep = 0;

        public static void startProgressBar()
        {
            Console.Write("Betöltés folyamatban: ");
            Console.Write("[");
            for (int i = 0; i < progressBarSize; i++)
                Console.Write("_");
            Console.Write("]");
        }

        public static void progressBarStep()
        {
            ClearCurrentConsoleLine();
            Console.Write("Betöltés folyamatban: ");
            Console.Write("[");
            for (int i = 0; i < progressBarCurrentStep; i++)
                Console.Write("#");
            for (int i = 0; i < progressBarSize - progressBarCurrentStep; i++)
                Console.Write("_");
            Console.Write("]");
        }

        public static void endProgressBar()
        {
            ClearCurrentConsoleLine();
            Console.Write("Betöltés folyamatban: ");
            Console.Write("[");
            for (int i = 0; i < progressBarSize; i++)
                Console.Write("#");
            Console.Write("]");
            coloredText(ConsoleColor.Green);
            Console.WriteLine(" - Kész!");
            coloredText(ConsoleColor.White);
        }

        #endregion

        public static void coloredText(ConsoleColor a)
        {
            Console.ForegroundColor = a;
        }
        public static void coloredBackground(ConsoleColor a)
        {
            Console.BackgroundColor = a;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        #endregion
    }
}
