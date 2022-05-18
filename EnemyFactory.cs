using System;

namespace IniciandoXUnit
{
    public class EnemyFactory
    {
        public Enemy Create(string name, bool isBoss = false)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (isBoss)
            {
                if (!IsValidBossName(name)) 
                {
                    throw new EnemyCreationException(
                        $"{name} is not a valid name for a Boss, cause don´t finish with King or Queen");
                }

                return new BossEnemy(name);  
            }
            
            

            return new NormalEnemy(name);

           
        }

        private bool IsValidBossName(string name) => name.EndsWith("King") || name.EndsWith("Queem");
        
    }
}
