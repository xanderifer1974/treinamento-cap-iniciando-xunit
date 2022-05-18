using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoXUnit
{
    public class EnemyCreationException: Exception
    {
        private string RequestedEnemyName;

        public EnemyCreationException (string requestedEnemyName)
        {
            this.RequestedEnemyName = requestedEnemyName;
        }
    }
}
