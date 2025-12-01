using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    internal class Player
    {
        //vars
        public Int32 MapX;
        public Int32 MapY;
        public Int32 PrevMapX;
        public Int32 PrevMapY;
        public Int32 Health;
        //shotgun, machinegun
        public Int32[] WeaponInv;
        //12g shells, 5.56x45
        public Int32[] Ammo;

        //main player code used to navigate the map + some more functions
        public void MapNav(ConsoleKey MapInput, Int32[,] WallsXY, List<Int32> EnemyNavX, List<Int32> EnemyNavY, List<Int32> Corpses, ref Int32[] Loot)
        {
            //vars setup
            Int32 Counter;
            Int32 Collisions;

            //saves the current map coords
            PrevMapX = MapX;
            PrevMapY = MapY;

            //moves the player if WASD is pressed, kills the player if Esc is pressed
            switch (MapInput)
            {
                case ConsoleKey.W:
                    MapY = MapY - 1;
                    break;
                case ConsoleKey.S:
                    MapY = MapY + 1;
                    break;
                case ConsoleKey.D:
                    MapX = MapX + 1;
                    break;
                case ConsoleKey.A:
                    MapX = MapX - 1;
                    break;
                case ConsoleKey.Escape:
                    Health = 0;
                    break;
            }

            //collision test
            Collisions = 0;
            //wall collision check
            if (WallBumpCheck(MapX, MapY, WallsXY) == true)
            {
                Collisions = Collisions + 1;
            }

            //enemy collision check
            Counter = 0;
            while (Counter < EnemyNavX.Count)
            {
                if (ObjectBumpCheck(MapX, MapY, EnemyNavX[Counter], EnemyNavY[Counter]) == true)
                {
                    if (!(Corpses.Contains(Counter)))
                    {
                        Collisions = Collisions + 1;
                    }
                    else
                    {
                        //collect loo on contact with corpse and reset loot on corpse
                        switch (Loot[Counter])
                        {
                            case 1:
                                Health = Health + 10;
                                break;
                            case 2:
                                WeaponInv[0] = 1;
                                Ammo[0] = Ammo[0] + 10;
                                break;
                            case 3:
                                WeaponInv[1] = 1;
                                Ammo[1] = Ammo[1] + 50;
                                break;
                        }
                        Loot[Counter] = 0;
                    }
                }
                Counter = Counter + 1;
            }

            //if a collision happens, return to previous position
            if (Collisions > 0)
            {
                MapX = PrevMapX;
                MapY = PrevMapY;
            }
        }
        //generic wall collision check
        public Boolean WallBumpCheck(Int32 ObjectX, Int32 ObjectY, Int32[,] WallsXY)
        {
            Int32 Counter = 0;
            Boolean Bump = false;

            while (Counter < WallsXY.GetLength(0))
            {
                if ((ObjectX == WallsXY[Counter, 0]) && (ObjectY == WallsXY[Counter, 1]))
                {
                    Bump = true;
                }
                Counter = Counter + 1;
            }

            return Bump;
        }
        //generic object collision check
        public Boolean ObjectBumpCheck(Int32 Object1X, Int32 Object1Y, Int32 Object2X, Int32 Object2Y)
        {
            Boolean Bump = false;

            if ((Object1X == Object2X) && (Object1Y == Object2Y))
            {
                Bump = true;
            }

            return Bump;
        }
    }
}
