using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoXUnit
{
    public abstract class Enemy
    {
        public  string Name { get; set; }

        public  abstract double TotalSpecialPower { get; set; }

        public abstract double  SpecialPowerUses { get; set; }

        public  double SpecialAtackPower => TotalSpecialPower / SpecialPowerUses;
    }
}
