using IniciandoXUnit;
using Xunit;

namespace GameEngine.Tests
{
    public class GameStateShoud
    {
        [Fact]
        public void DamageAllPlayerWhenEarthquake()
        {
            var sut = new GameState();

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            sut.Players.Add(player1);
            sut.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Helth - GameState.EarthquakeDamage;

            sut.Earthquake();
           
            Assert.Equal(expectedHealthAfterEarthquake, player1.Helth);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Helth);


        }

        [Fact]
        public void Reset()
        {

            var sut = new GameState();

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            sut.Players.Add(player1);
            sut.Players.Add(player2);

            sut.Reset();

            Assert.Empty(sut.Players);  


        }
    }
}
