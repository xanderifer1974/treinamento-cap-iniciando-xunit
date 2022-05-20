using IniciandoXUnit;
using System;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]     
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zumbie");   
            
            Assert.IsType<NormalEnemy>(enemy);  

        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zumbie");

            Assert.IsNotType<DateTime>(enemy);

        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zumbie King",true);

            Assert.IsType<BossEnemy>(enemy);

        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Aditional assert on typed object
            Assert.Equal("Zombie King", boss.Name);
        }

        /// <summary>
        /// Testa se o objeto e derivado de uma herança
        /// </summary>
        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);        

          
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        /// <summary>
        /// Verifica se os dois objetos não são da mesma instância
        /// </summary>
        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");


            Assert.NotSame(enemy1, enemy2);
        }

        /// <summary>
        /// verificar nome nulo
        /// </summary>
        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();          


            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public void AllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex =
            Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie king", true));
            
        }
       
    }
}
