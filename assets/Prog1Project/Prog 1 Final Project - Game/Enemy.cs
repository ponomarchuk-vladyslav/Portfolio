using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    //note: very basic, prectically placeholder "AI"
    internal class Enemy
    {
        //vars
        public Int32 MapX;
        public Int32 MapY;
        public Int32 PrevMapX;
        public Int32 PrevMapY;
        public Int32 Health;
        public Int32 EnemyStatus;
        public String EnemyClass;
        public Int32 EnemyAICounter;
        public Int32 StaggerCounter;
        public Int32 StaggerCounterDisplay;
        public Int32 RespawnCounter;
        public Int32 DeathCounter;
        public Boolean Hit;
        public Boolean ToSpawn = false;
        public Int32 EnemyID;


        public void MapAI(Int32 PlayerX, Int32 PlayerY, Int32[,] WallsXY, List<Int32> EnemyNavX, List<Int32> EnemyNavY, List<Int32> Corpses, Int32[] BulletX, Int32[] BulletY, Int32 Damage, ref Int32 PlayerHealth, ref Int32 Loot, ref List<Int32> EnemyX, ref List<Int32> EnemyY, Int32 EnemyID)
        {
            //vars setup
            Int32 XDifference = 0;
            Int32 YDifference = 0;
            Decimal EnemyDistPlayer;
            Int32 Collisions = 0;
            Int32 Counter;
            Int32 Direction = 0;
            Random LootPicker = new Random();
            Random PickDirection = new Random();

            //check for collisions with bullets
            Counter = 0;
            while (Counter < BulletX.Length)
            {
                if (ObjectBumpCheck(MapX, MapY, BulletX[Counter], BulletY[Counter]) == true && EnemyStatus != 0)
                {
                    //deduce health, stagger the enemy and record a hit
                    Health = Health - Damage;
                    StaggerCounter = 25;
                    StaggerCounterDisplay = 5;
                    EnemyStatus = 2;
                    Hit = true;
                }
                Counter = Counter + 1;
            }
            //if dead
            if (Health <= 0)
            {
                //mark the enemy as dead
                EnemyStatus = 0;
                //if hit
                if (Hit == true)
                {
                    //begin respawn, increment the death counter and generate loot
                    RespawnCounter = 1000;
                    DeathCounter = DeathCounter + 1;
                    Loot = LootPicker.Next(1, 4);
                    Hit = false;
                }
                //increment the respawn counter
                RespawnCounter = RespawnCounter - 1;
                //if the respawn counter is done
                if (RespawnCounter == 0)
                {
                    //respawn the enemy and reset the loot
                    ToSpawn = true;
                    Loot = 0;
                }
                return;
            }
            //decrement the stagger display counter if possible
            if (StaggerCounterDisplay > 0)
            {
                StaggerCounterDisplay = StaggerCounterDisplay - 1;
            }
            //if not, stop the stagger display status
            else
            {
                EnemyStatus = 1;
            }

            //decrement the stagger counter if possible, and stagger the enemy (skip all "AI")
            if (StaggerCounter > 0)
            {
                StaggerCounter = StaggerCounter - 1;
                return;
            }

            //records the current position of the enemy
            PrevMapX = MapX;
            PrevMapY = MapY;

            //calculates the x and y distance from the player
            XDifference = Math.Abs(PlayerX - MapX);
            YDifference = Math.Abs(PlayerY - MapY);

            //calculate the average distance from the player
            EnemyDistPlayer = ((XDifference + YDifference) / 2);
            //this counter prevent the enemy from acting too fast
            if (EnemyAICounter == 25)
            {
                //pick a random direction
                Direction = PickDirection.Next(0, 4);
                //if the player is within detection range
                if (EnemyDistPlayer <= 12)
                {
                    //move the enemy depending on the distances from player
                    if (YDifference > XDifference)
                    {
                        if (PlayerY > MapY)
                        {
                            MapY = MapY + 1;
                        }
                        if (PlayerY < MapY)
                        {
                            MapY = MapY - 1;
                        }
                    }
                    else
                    {
                        if (PlayerX > MapX)
                        {
                            MapX = MapX + 1;
                        }
                        if (PlayerX < MapX)
                        {
                            MapX = MapX - 1;
                        }
                    }
                }
                //if not within detection range
                else
                {
                    //move in the chosen random direction
                    switch (Direction) 
                    {
                        case 0:
                            MapY = MapY + 1;
                            break;
                        case 1:
                            MapY = MapY - 1;
                            break;
                        case 2:
                            MapX = MapX + 1;
                            break;
                        case 3:
                            MapX = MapX - 1;
                            break;
                    }
                }
                EnemyAICounter = 0;
            }
            //increments the "AI" counter
            else
            {
                EnemyAICounter = EnemyAICounter + 1;
            }

            //collision checks
            Collisions = 0;
            //wall collision check
            if (WallBumpCheck(MapX, MapY, WallsXY) == true && EnemyStatus == 1)
            {
                Collisions = Collisions + 1;
            }

            //general enemy collision
            Counter = 0;
            while (Counter < EnemyNavX.Count)
            {
                if (ObjectBumpCheck(MapX, MapY, EnemyNavX[Counter], EnemyNavY[Counter]) == true)
                {
                    if (!(Corpses.Contains(Counter)))
                    {
                        Collisions = Collisions + 1;
                    }
                }
                Counter = Counter + 1;
            }

            //player collision
            if (ObjectBumpCheck(MapX, MapY, PlayerX, PlayerY) == true)
            {
                Collisions = Collisions + 1;
                PlayerHealth = PlayerHealth - 5;
            }

            //if collision happens
            if (Collisions > 0)
            {
                //returns the enemy to the previous position
                MapX = PrevMapX;
                MapY = PrevMapY;
            }

            //update the enemy position in the lists
            EnemyX[EnemyID] = MapX;
            EnemyY[EnemyID] = MapY;
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
