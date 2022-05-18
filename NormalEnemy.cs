using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoXUnit
{
    public class NormalEnemy : Enemy
    {
     
        public override double TotalSpecialPower { get => 500; set => throw new NotImplementedException(); }
        public override double SpecialPowerUses { get => 3; set => throw new NotImplementedException(); }

        public NormalEnemy(string name)
        {
           Name = name;
        }
    }
}
