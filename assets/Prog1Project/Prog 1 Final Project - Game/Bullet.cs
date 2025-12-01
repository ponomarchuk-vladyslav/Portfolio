using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    internal class Bullet
    {
        //vars
        public Double BulletX;
        public Double BulletY;
        public Int32 MapBulletX;
        public Int32 MapBulletY;

        //the main code for the bullet, used to calculate trajectory
        public void BulletCalc(Double DeltaX, Double DeltaY, Int32[,] WallsXY, List<Int32> Corpses, List<Int32> EnemyNavX, List<Int32> EnemyNavY)
        {
            //vars setup
            Boolean Contact = false;
            Int32 Counter = 0;

            //repeat until the bullet hits something
            while (Contact != true)
            {
                //move the bullet
                BulletX = BulletX + DeltaX;
                BulletY = BulletY + DeltaY;

                //round the map position of the bullet
                MapBulletX = Convert.ToInt32(Math.Round(BulletX));
                MapBulletY = Convert.ToInt32(Math.Round(BulletY));


                //collision checks
                //wall collision check
                if (WallBumpCheck(MapBulletX, MapBulletY, WallsXY) == true)
                {
                    Contact = true;
                }

                //general enemy collision
                Counter = 0;
                while (Counter < EnemyNavX.Count)
                {
                    if (ObjectBumpCheck(MapBulletX, MapBulletY, EnemyNavX[Counter], EnemyNavY[Counter]) == true)
                    {
                        //if not a corpse
                        if (!(Corpses.Contains(Counter)))
                        {
                            Contact = true;
                            break;
                        }
                    }
                    Counter = Counter + 1;
                }
            }
        }

        //generic code to check wall collision
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

        //generic code to check object collision
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
