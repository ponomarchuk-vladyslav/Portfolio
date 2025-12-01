using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_1_Final_Project___Game
{
    internal class Weapon
    {
        //vars
        public Int32 EquippedWeapon;
        //current weapon stats
        public Int32 WeaponDamage;
        public Int32 WeaponRefireDelay;
        public Int32 WeaponSpread;
        public Int32 WeaponShotCount;
        //weapon stats for different weapons
        //pistol, shotgun, machinegun
        public static Int32[] DamageStats = new Int32[] { 20, 5, 10 };
        public static Int32[] RefireDelayStats = new Int32[] { 20, 25, 1 };
        public static Int32[] SpreadStats = new Int32[] { 1, 6, 3 };
        public static Int32[] ShotCountStats = new Int32[] { 1, 100, 1 };

        //set the stats of the current weapon to the chosen weapon
        public void SwitchWeapon()
        {
            WeaponDamage = DamageStats[EquippedWeapon];
            WeaponRefireDelay = RefireDelayStats[EquippedWeapon];
            WeaponSpread = SpreadStats[EquippedWeapon];
            WeaponShotCount = ShotCountStats[EquippedWeapon];
        }
    }
}
