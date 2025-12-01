using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    internal class Map
    {
        //vars
        public Int32[,] WallXY;
        public Int32 PlayerX;
        public Int32 PlayerY;
        public List<Int32> ZombieX = new List<Int32> { };
        public List<Int32> ZombieY = new List<Int32> { };
        public List<Int32> RangedZombieX = new List<Int32> { };
        public List<Int32> RangedZombieY = new List<Int32> { };
        public List<Int32> CorpseX = new List<Int32> { };
        public List<Int32> CorpseY = new List<Int32> { };
        public List<Int32> StaggerX = new List<Int32> { };
        public List<Int32> StaggerY = new List<Int32> { };
        public String[][] MapMain = new String[25][];

        //updates the map display array
        public void MapUpdate(Int32[] BulletX, Int32[] BulletY)
        {
            //vars setup
            Int32 Counter = 0;
            Int32 XCounter = 0;
            Int32 YCounter = 0;

            //array setup
            while (YCounter < 25)
            {
                XCounter = 0;
                while (XCounter < 35)
                {
                    MapMain[YCounter][XCounter] = " .";
                    XCounter = XCounter + 1;
                }
                YCounter = YCounter + 1;
            }

            //adds corpses
            Counter = 0;
            while (Counter < CorpseX.Count)
            {
                MapMain[CorpseY[Counter]][CorpseX[Counter]] = " X";
                Counter = Counter + 1;
            }

            //adds zombies
            Counter = 0;
            while (Counter < ZombieX.Count)
            {
                MapMain[ZombieY[Counter]][ZombieX[Counter]] = " i";
                Counter = Counter + 1;
            }

            //adds bullets (for hit display)
            Counter = 0;
            while (Counter < StaggerX.Count)
            {
                MapMain[StaggerY[Counter]][StaggerX[Counter]] = "  ";
                Counter = Counter + 1;
            }

            //adds walls
            Counter = 0;
            while (Counter < WallXY.GetLength(0))
            {
                MapMain[WallXY[Counter, 1]][WallXY[Counter, 0]] = " #";
                Counter = Counter + 1;
            }

            //adds the player
            MapMain[PlayerY][PlayerX] = " @";
        }
        //updates the enemy lists
        public void EnemyUpdate(Int32 EnemyX, Int32 EnemyY, Int32 EnemyStatus, String EnemyClass)
        {
            //if the enemy is alive and active
            if (EnemyStatus == 1)
            {
                //if the enemy is a zombie
                if (EnemyClass == "Zombie")
                {
                    //adds the zombie coords to the zombie diplay lists
                    ZombieX.Add(EnemyX);
                    ZombieY.Add(EnemyY);
                }
                //Note: The whole EnemyClass this is a holdover from when I wanted to add ranged zombies. I cut this due to time constraints and unexpected bugs
            }
            else
            {
                //if the enemy is dead
                if (EnemyStatus == 0)
                {
                    CorpseX.Add(EnemyX);
                    CorpseY.Add(EnemyY);
                }
                //if the enemy is staggered
                else
                {
                    StaggerX.Add(EnemyX);
                    StaggerY.Add(EnemyY);
                }
            }
        }
        //resets all enemy display lists (just wipies them all clean)
        public void EnemyReset()
        {
            ZombieX = new List<Int32>();
            ZombieY = new List<Int32>();
            RangedZombieX = new List<Int32>();
            RangedZombieY = new List<Int32>();
            CorpseX = new List<Int32>();
            CorpseY = new List<Int32>();
            StaggerX = new List<Int32>();
            StaggerY = new List<Int32>();
        }
    }
}
