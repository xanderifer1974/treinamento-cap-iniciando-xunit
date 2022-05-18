using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoXUnit
{
    public class BossEnemy : Enemy    {       

        public BossEnemy(string name)
        {
            Name = name;
        }

        public override double TotalSpecialPower { get => 1000; set => throw new NotImplementedException(); }
        public override double SpecialPowerUses { get => 6; set => throw new NotImplementedException(); }
    }
}
