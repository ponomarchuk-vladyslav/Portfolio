using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//NOTE
//a lot of this code is probably nonsense. I was learning as I went along, so I'm not utilising classes and objects to their full potential
//also I often rewrote parts of my code

namespace Prog_1_Final_Project___Game
{
    internal class Game_Main
    {
        //highscore
        static Int32 Highscore = 0;
        //MAPS GO HERE
        static readonly Int32[,] WallsXY = { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 0 }, { 12, 0 }, { 13, 0 }, { 14, 0 }, { 15, 0 }, { 16, 0 }, { 17, 0 }, { 18, 0 }, { 19, 0 }, { 20, 0 }, { 21, 0 }, { 22, 0 }, { 23, 0 }, { 24, 0 }, { 25, 0 }, { 26, 0 }, { 27, 0 }, { 28, 0 }, { 29, 0 }, { 30, 0 }, { 31, 0 }, { 32, 0 }, { 33, 0 }, { 34, 0 },
                                             { 34, 1 }, { 34, 2 }, { 34, 3 }, { 34, 4 }, { 34, 5 }, { 34, 6 }, { 34, 7 }, { 34, 8 }, { 34, 9 }, { 34, 10 }, { 34, 11 }, { 34, 12 }, { 34, 13 }, { 34, 14 }, { 34, 15 }, { 34, 16 }, { 34, 17 }, { 34, 18 }, { 34, 19 }, { 34, 20 }, { 34, 21 }, { 34, 22 }, { 34, 23 }, { 34, 24 },
                                             { 33, 24 }, { 32, 24 }, { 31, 24 }, { 30, 24 }, { 29, 24 }, { 28, 24 }, { 27, 24 }, { 26, 24 }, { 25, 24 }, { 24, 24 }, { 23, 24 }, { 22, 24 }, { 21, 24 }, { 20, 24 }, { 19, 24 }, { 18, 24 }, { 17, 24 }, { 16, 24 }, { 15, 24 }, { 14, 24 }, { 13, 24 }, { 12, 24 }, { 11, 24 }, { 10, 24 }, { 9, 24 }, { 8, 24 }, { 7, 24 }, { 6, 24 }, { 5, 24 }, { 4, 24 }, { 3, 24 }, { 2, 24 }, { 1, 24 }, { 0, 24 },
                                             { 0, 23 }, { 0, 22 }, { 0, 21 }, { 0, 20 }, { 0, 19 }, { 0, 18 }, { 0, 17 }, { 0, 16 }, { 0, 15 }, { 0, 14 }, { 0, 13 }, { 0, 12 }, { 0, 11 }, { 0, 10 }, { 0, 9 }, { 0, 8 }, { 0, 7 }, { 0, 6 }, { 0, 5 }, { 0, 4 }, { 0, 3 }, { 0, 2 }, { 0, 1 },
                                             { 16, 1 }, { 16, 2 }, { 16, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 }, { 7, 7 }, { 7, 8 }, { 7, 9 }, { 7, 11 }, { 7, 12 }, { 7, 13 }, { 7, 14 }, { 7, 15 }, { 7, 17 }, { 7, 18 }, { 14, 19 }, { 14, 20 }, { 14, 21 }, 
                                             { 28, 11 }, { 28, 12 }, { 28, 13 }, { 29, 3 }, { 29, 4 }, { 29, 5 }, { 29, 6 }, { 28, 6 }, { 27, 6 }, { 26, 6 }, { 25, 6 }, { 24, 6 }, { 23, 6 }, { 25, 20 }, { 26, 20 }, { 27, 20 }, { 28, 20 }, { 29, 20 }, { 30, 20 }, { 30, 19 }, { 30, 18 }, { 30,17 },
                                             { 20, 9 }, { 21, 9 }, { 21, 10 }, { 21, 11 }, { 21, 12 }, { 21, 13 }, { 21, 14 }, { 21, 15 }, { 20, 15 }, { 19, 15 }, { 18, 15 }, { 17, 15 }, { 16, 15 }, { 15, 15 }, { 14, 15 }, { 14, 14 }, { 14, 13 }, { 14, 12 }, { 14, 11 }, { 14, 10 }, { 14, 9 }, { 15, 9 }, { 16, 9 }, { 17, 9 }, { 18, 9 },
                                             };
        //enemy spawns locations
        static readonly Int32[,] EnemySpawnXY = { { 1, 1 }, { 33, 23 }, { 1, 23 }, { 33, 1 } };
        //player spawn location
        static readonly Int32[] PlayerSpawnXY = { 17, 12 };

        //creates a new enemy object
        static void EnemyInit(ref Enemy[] Zombie, Int32 EnemyCounter, Int32 SpawnCounter, ref List<Int32> EnemyNavX, ref List<Int32> EnemyNavY)
        {
            Zombie[EnemyCounter] = new Enemy()
            {
                //parameters for the new object
                MapX = EnemySpawnXY[SpawnCounter, 0],
                MapY = EnemySpawnXY[SpawnCounter, 1],
                EnemyStatus = 1,
                EnemyClass = "Zombie",
                Health = 50,
                EnemyID = EnemyCounter
            };
            //adds the coordinates of the enemy to my navigation lists
            EnemyNavX.Add(Zombie[EnemyCounter].MapX);
            EnemyNavY.Add(Zombie[EnemyCounter].MapY);
        }
        //give parameters for respawned enemy
        static void EnemyRespawn(ref Enemy[] Zombie, Int32 Counter, Int32 SpawnCounter)
        {
            Zombie[Counter].MapX = EnemySpawnXY[SpawnCounter, 0];
            Zombie[Counter].MapY = EnemySpawnXY[SpawnCounter, 1];
            Zombie[Counter].EnemyStatus = 1;
            Zombie[Counter].Health = 50;
            Zombie[Counter].ToSpawn = false;
        }
        //I like to keep my Main clean. It was a horrible mess before
        static void Main(String[] args)
        {
            //hides the cursor
            Console.CursorVisible = false;

            //launches the main menu
            MainScreen();
        }
        //this is the main code of my game
        static void MainGame()
        {
            //variables
            List<Int32> EnemyNavX = new List<Int32> { };
            List<Int32> EnemyNavY = new List<Int32> { };
            List<Int32> CorpsesID = new List<Int32> { };
            Int32 Counter = 0;
            Int32 EnemyCounter = 0;
            Int32 SpawnCounter = 0;
            Int32 MaxEnemiesCounter = 0;
            Int32[] BulletX = new Int32[100];
            Int32[] BulletY = new Int32[100];
            Int32[] LootTable = new Int32[100];
            Int32 RefireDelay = 0;
            Int32 Score = 0;
            Int32 MaxEnemies = 0;
            Int32 RandomHit = 0;
            Random chance = new Random();
            ConsoleKey PlayerInput;

            //weapons prep
            Weapon Guns = new Weapon()
            {
                EquippedWeapon = 0,
            };

            //map prep
            Map Map = new Map();
            while (Counter < 25)
            {
                Map.MapMain[Counter] = new String[35];
                Counter = Counter + 1;
            }
            Map.WallXY = WallsXY;

            //display prep
            Display DisplayMain = new Display();

            //player prep
            Player Player = new Player()
            {
                MapX = PlayerSpawnXY[0],
                MapY = PlayerSpawnXY[1],
                Health = 100,
                WeaponInv = new Int32[] { 0, 0 },
                Ammo = new Int32[] { 0, 0 },
            };

            Map.PlayerX = Player.MapX;
            Map.PlayerY = Player.MapY;

            //enemy prep
            Enemy[] Zombie = new Enemy[100];

            //resets all my display lists to 0
            Map.EnemyReset();

            //bullets prep
            //I named the bullet objects "Tracers" because they play a similar role to actual, real-life tracer munitions, it shows where the bullet goes.
            Bullet[] Tracer = new Bullet[100];
            Counter = 0;
            //create a 100 bullet objects
            while (Counter < 100)
            {
                Tracer[Counter] = new Bullet()
                {
                    BulletX = Player.MapX,
                    BulletY = Player.MapY,
                    MapBulletX = Player.MapX,
                    MapBulletY = Player.MapY,
                };
                Counter = Counter + 1;
            }

            //adds the bullet coords to my lists (Used for display and calculations)
            Counter = 0;
            while (Counter < 100)
            {
                BulletX[Counter] = Tracer[Counter].MapBulletX;
                BulletY[Counter] = Tracer[Counter].MapBulletY;
                Counter = Counter + 1;
            }

            //updates the map display array
            Map.MapUpdate(BulletX, BulletY);
            //draws the map
            DisplayMain.DrawMap(Map.MapMain, Player.Health, Guns.EquippedWeapon, Score, Player.Ammo[0], Player.Ammo[1]);

            //main loop
            while (Player.Health > 0)
            {
                //set the input to a dummy value (just in case)
                PlayerInput = ConsoleKey.NoName;
                //check if the user pressed a key
                if (Console.KeyAvailable == true)
                {
                    //gets the input
                    //true prevents the symbols entered from showing up on the console
                    PlayerInput = Console.ReadKey(true).Key;
                }
                //prevents the whole game from freezing due to input buffer
                while (Console.KeyAvailable == true) //I took it from https://stackoverflow.com/questions/3769770/clear-console-buffer
                {
                    Console.ReadKey(false);
                }

                //reset the corpses list
                CorpsesID = new List<Int32> { };
                Counter = 0;
                while (Counter < EnemyCounter)
                {
                    if (Zombie[Counter].Health <= 0)
                    {
                        //if the zombie is dead, add it to the corpse list
                        CorpsesID.Add(Counter);
                    }
                    Counter = Counter + 1;
                }

                //move the player if possible (if correct key pressed)
                Player.MapNav(PlayerInput, WallsXY, EnemyNavX, EnemyNavY, CorpsesID, ref LootTable);

                //weapon selection
                switch (PlayerInput)
                {
                    case ConsoleKey.D1:
                        Guns.EquippedWeapon = 0;
                        break;
                    case ConsoleKey.D2:
                        //select only if you have a shotgun
                        if (Player.WeaponInv[0] == 1)
                        {
                            Guns.EquippedWeapon = 1;
                        }
                        break;
                    case ConsoleKey.D3:
                        //select only if you have the machinegun
                        if (Player.WeaponInv[1] == 1)
                        {
                            Guns.EquippedWeapon = 2;
                        }
                        break;
                }

                //changes weapon stats depending on the selected weapon
                Guns.SwitchWeapon();

                //moves all the bullets to the player
                Counter = 0;
                while (Counter < 100)
                {
                    Tracer[Counter].BulletX = Player.MapX;
                    Tracer[Counter].BulletY = Player.MapY;
                    Tracer[Counter].MapBulletX = Player.MapX;
                    Tracer[Counter].MapBulletY = Player.MapY;
                    Counter = Counter + 1;
                }

                //fires if the user pressed an arrow key and the weapon is ready to fire
                if ((RefireDelay > Guns.WeaponRefireDelay) && ((PlayerInput == ConsoleKey.UpArrow) || (PlayerInput == ConsoleKey.DownArrow) || (PlayerInput == ConsoleKey.LeftArrow) || (PlayerInput == ConsoleKey.RightArrow)))
                {
                    Counter = 0;
                    //runs for the number of bullets/shot
                    while (Counter < Guns.WeaponShotCount)
                    {
                        //check if the gun has ammo (does not apply to the pistol). If it doesn't, then don't fire
                        if (Guns.EquippedWeapon == 1 && Player.Ammo[0] < 1)
                        {
                            break;
                        }
                        if (Guns.EquippedWeapon == 2 && Player.Ammo[1] < 1)
                        {
                            break;
                        }

                        //gives the shot "spread", makes it go slightly sideways, depending on weapon stats
                        RandomHit = chance.Next(0, Guns.WeaponSpread);
                        RandomHit = RandomHit / 10;
                        RandomHit = RandomHit * (chance.Next(0, 2) * 2 - 1);

                        //fires in a particular direction depending on key pressed
                        //see, i DID have a 100 in math, I still remember what vectors are and how to work with them!
                        switch (PlayerInput)
                        {
                            case ConsoleKey.UpArrow:
                                Tracer[Counter].BulletCalc(RandomHit, -1, WallsXY, CorpsesID, EnemyNavX, EnemyNavY);
                                break;
                            case ConsoleKey.DownArrow:
                                Tracer[Counter].BulletCalc(RandomHit, 1, WallsXY, CorpsesID, EnemyNavX, EnemyNavY);
                                break;
                            case ConsoleKey.LeftArrow:
                                Tracer[Counter].BulletCalc(-1, RandomHit, WallsXY, CorpsesID, EnemyNavX, EnemyNavY);
                                break;
                            case ConsoleKey.RightArrow:
                                Tracer[Counter].BulletCalc(1, RandomHit, WallsXY, CorpsesID, EnemyNavX, EnemyNavY);
                                break;
                        }
                        Counter = Counter + 1;
                    }
                    //deduce some amunition for every shot
                    if (Guns.EquippedWeapon == 1 && Player.Ammo[0] > 0)
                    {
                        Player.Ammo[0] = Player.Ammo[0] - 1;
                    }
                    if (Guns.EquippedWeapon == 2 && Player.Ammo[1] > 0)
                    {
                        Player.Ammo[1] = Player.Ammo[1] - 1;
                    }
                    //reset the timer
                    RefireDelay = 0;
                }

                //add the bullet coords to the list
                Counter = 0;
                while (Counter < 100)
                {
                    BulletX[Counter] = Tracer[Counter].MapBulletX;
                    BulletY[Counter] = Tracer[Counter].MapBulletY;
                    Counter = Counter + 1;
                }

                //move the player on the map
                Map.PlayerX = Player.MapX;
                Map.PlayerY = Player.MapY;

                //resets the counter for spawn locations
                if (SpawnCounter > 3)
                {
                    SpawnCounter = 0;
                }
                //if alowed to create more enemies, create a new enemy object
                if (EnemyCounter < MaxEnemies)
                {
                    EnemyInit(ref Zombie, EnemyCounter, SpawnCounter, ref EnemyNavX, ref EnemyNavY);
                    SpawnCounter = SpawnCounter + 1;
                    EnemyCounter = EnemyCounter + 1;
                }
                //if not, start ressurecting dead ones, if possible
                else
                {
                    Counter = 0;
                    while (Counter < EnemyCounter)
                    {
                        if (SpawnCounter > 3)
                        {
                            SpawnCounter = 0;
                        }
                        if (Zombie[Counter].ToSpawn == true)
                        {
                            EnemyRespawn(ref Zombie, Counter, SpawnCounter);
                        }
                        SpawnCounter = SpawnCounter + 1;
                        Counter = Counter + 1;
                    }
                }

                //resets enemy display list
                Map.EnemyReset();

                //runs the enemy "AI" (not very good at navigating, I know) and update it's position in the display lists
                Counter = 0;
                while (Counter < EnemyCounter)
                {
                    Zombie[Counter].MapAI(Player.MapX, Player.MapY, WallsXY, EnemyNavX, EnemyNavY, CorpsesID, BulletX, BulletY, Guns.WeaponDamage, ref Player.Health, ref LootTable[Counter], ref EnemyNavX, ref EnemyNavY, Counter);
                    Map.EnemyUpdate(EnemyNavX[Counter], EnemyNavY[Counter], Zombie[Counter].EnemyStatus, Zombie[Counter].EnemyClass);
                    Counter = Counter + 1;
                }

                //updates the sore depending on number of enemies killed
                Counter = 0;
                Score = 0;
                while (Counter < EnemyCounter)
                {
                    Score = Score + (Zombie[Counter].DeathCounter * 5);
                    Counter = Counter + 1;
                }

                //raises the limit of enemies
                if (MaxEnemiesCounter == 100)
                {
                    MaxEnemies = MaxEnemies + 1;
                    MaxEnemiesCounter = 0;
                }
                //prevents the limit of enemies being higher that the max amount of objects possible
                MaxEnemiesCounter = MaxEnemiesCounter + 1;
                if (MaxEnemies == 100)
                {
                    MaxEnemies = 99;
                }

                //increments the timer for weapon delay
                RefireDelay = RefireDelay + 1;

                //updates the map display array
                Map.MapUpdate(BulletX, BulletY);
                //draws the map
                DisplayMain.DrawMap(Map.MapMain, Player.Health, Guns.EquippedWeapon, Score, Player.Ammo[0], Player.Ammo[1]);
                //waits a little bit. Limits the number if cycles/ticks per second
                System.Threading.Thread.Sleep(10);
            }

            //diplays the game over screen
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("YOU DIED");

            //updates the highscore
            System.Threading.Thread.Sleep(500);
            if (Score > Highscore)
            {
                Highscore = Score;
            }
        }

        //main menu screen
        static void MainScreen()
        {
            //vars setup
            Boolean Confirm = false;
            Int32 Selection = 0;
            String[] SelectDisplay = { " ", " ", " " };
            ConsoleKey Input;

            //main loop
            while (Confirm == false)
            {
                //keep the selection in bounds
                if (Selection < 0)
                {
                    Selection = 2;
                }
                if (Selection > 2)
                {
                    Selection = 0;
                }

                //update the arrow position
                SelectDisplay = new String[] { " ", " ", " ", };
                SelectDisplay[Selection] = ">";

                //display the menu
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" ▒█████   █    ██ ▄▄▄█████▓ ███▄    █  █    ██  ███▄ ▄███▓ ▄▄▄▄   ▓█████  ██▀███  ▓█████ ▓█████▄    \r\n▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒ ██ ▀█   █  ██  ▓██▒▓██▒▀█▀ ██▒▓█████▄ ▓█   ▀ ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌   \r\n▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░▓██  ▀█ ██▒▓██  ▒██░▓██    ▓██░▒██▒ ▄██▒███   ▓██ ░▄█ ▒▒███   ░██   █▌   \r\n▒██   ██░▓▓█  ░██░░ ▓██▓ ░ ▓██▒  ▐▌██▒▓▓█  ░██░▒██    ▒██ ▒██░█▀  ▒▓█  ▄ ▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌   \r\n░ ████▓▒░▒▒█████▓   ▒██▒ ░ ▒██░   ▓██░▒▒█████▓ ▒██▒   ░██▒░▓█  ▀█▓░▒████▒░██▓ ▒██▒░▒████▒░▒████▓    \r\n░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   ░ ▒░   ▒ ▒ ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░░▒▓███▀▒░░ ▒░ ░░ ▒▓ ░▒▓░░░ ▒░ ░ ▒▒▓  ▒    \r\n  ░ ▒ ▒░ ░░▒░ ░ ░     ░    ░ ░░   ░ ▒░░░▒░ ░ ░ ░  ░      ░▒░▒   ░  ░ ░  ░  ░▒ ░ ▒░ ░ ░  ░ ░ ▒  ▒    \r\n░ ░ ░ ▒   ░░░ ░ ░   ░         ░   ░ ░  ░░░ ░ ░ ░      ░    ░    ░    ░     ░░   ░    ░    ░ ░  ░    \r\n    ░ ░     ░                       ░    ░            ░    ░         ░  ░   ░        ░  ░   ░       \r\n                                                                ░                         ░         ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Highscore: " + Highscore);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(SelectDisplay[0] + " Start");
                Console.WriteLine(SelectDisplay[1] + " Instructions");
                Console.WriteLine(SelectDisplay[2] + " Exit");

                //get user input
                Input = Console.ReadKey().Key;

                //interpret input
                switch (Input)
                {
                    //change selection
                    case ConsoleKey.UpArrow:
                        Selection = Selection - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Selection = Selection + 1;
                        break;
                    //confirm selection
                    case ConsoleKey.Enter:
                        Confirm = true;
                        break;
                }

                //run code depending on selection
                if (Confirm == true)
                {
                    switch (Selection)
                    {
                        case 0:
                            //Runs the game
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            MainGame();
                            //return to the main menu after the program finishes running
                            MainScreen();
                            break;
                        case 1:
                            //Displays the instructions and all that
                            InstructionScreen();
                            //returns back to the main manu after the program is done
                            MainScreen();
                            break;
                        case 2:
                            Console.WriteLine("bye");
                            break;
                    }
                }
            }
        }
        //code for the instructions + notes
        static void InstructionScreen()
        {
            //vars setup
            Int32 PageNum = 0;
            ConsoleKey Input = ConsoleKey.NoName;

            //main loop
            while (Input != ConsoleKey.Escape)
            {
                //keep selection within bounds
                if (PageNum < 0)
                {
                    PageNum = 2;
                }
                if (PageNum > 2)
                {
                    PageNum = 0;
                }

                //diplay the page
                Console.Clear();
                switch (PageNum)
                {
                    case 0:
                        Console.WriteLine("     Controls  >  ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Arrow keys to navigate menus and shoot in a direction");
                        Console.WriteLine("WASD to move your character");
                        Console.WriteLine("Number keys to select weapons");
                        Console.WriteLine("Esc to return to main menu");
                        Console.WriteLine("The game ends when you have 0 health");
                        Console.WriteLine("Try to kill as much zombies as possible for the highest score");
                        Console.WriteLine();
                        Console.WriteLine("Big Thank You to D**MRL for inspiration, and to Microsoft, W3 Schools and Larry Fagen, my programming teacher, for");
                        Console.WriteLine("helping.");
                        break;
                    case 1:
                        Console.WriteLine("  <  Weapons  >  ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Slot 1: Pistol");
                        Console.WriteLine("A standart 9mm pistol, not anything to write home about. Mediocre fire rate and damage, but at least, it's very accurate");
                        Console.WriteLine("and comes with infinite ammo.");
                        Console.WriteLine();
                        Console.WriteLine("Slot 2: Shotgun");
                        Console.WriteLine("The good old 12 gauge boomstick, a must-have for any survivor. Very inaccurate at long ranges, it sprays a large amount");
                        Console.WriteLine("of low-damage pellets, being able to reliably kill a few zombies per shot. The only downside is that it's pump action,");
                        Console.WriteLine("so it has a low fire rate. Uses shells and must be found.");
                        Console.WriteLine();
                        Console.WriteLine("Slot 3: Machinegun");
                        Console.WriteLine("A 5.56x45 machinegun, capable of decimating any foe in front of it. Higher damage and firerate than the pistol,");
                        Console.WriteLine("but slightly inaccurate at ranges. Uses bullet and must be found.");
                        break;
                    case 2:
                        Console.WriteLine("  <  Enemies     ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Zombie (i)");
                        Console.WriteLine("Your average zombie. Not very smart, fast, strong or tough, he is however dangerous in large numbers, able to");
                        Console.WriteLine("overwhelm even the most experienced of survivors. He only attacks in melee, so keep your distance.");
                        Console.WriteLine();
                        Console.WriteLine("Corpse (X)");
                        Console.WriteLine("Dead enemy. Step on it to loot it for health or weapons with ammo.");
                        Console.WriteLine();
                        Console.WriteLine("Player (@)");
                        Console.WriteLine("It's you. It doesn't matter how you got here, who you were before or what you wanted. Now, you must survive.");
                        Console.WriteLine();
                        Console.WriteLine("No matter the odds.");
                        break;
                }

                //get user input
                Input = Console.ReadKey().Key;

                //interpret input
                switch (Input)
                {
                    //change pages
                    case ConsoleKey.RightArrow:
                        PageNum = PageNum + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        PageNum = PageNum - 1;
                        break;
                    //exit the instructions
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}
