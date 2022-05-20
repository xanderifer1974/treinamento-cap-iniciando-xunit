using IniciandoXUnit;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Teste da Classe GameState")]
    public class GameStateShoud: IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStatueFixture; 
        private readonly ITestOutputHelper _output;

        public GameStateShoud(GameStateFixture gameStatueFixture, ITestOutputHelper output)
        {
            _gameStatueFixture = gameStatueFixture;
            _output = output;
        }



        [Fact]
        public void DamageAllPlayerWhenEarthquake()
        {
           
            _output.WriteLine($"GameState ID={_gameStatueFixture.State.Id}");


            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStatueFixture.State.Players.Add(player1);
            _gameStatueFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Helth - GameState.EarthquakeDamage;

            _gameStatueFixture.State.Earthquake();
           
            Assert.Equal(expectedHealthAfterEarthquake, player1.Helth);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Helth);


        }

        [Fact]
        public void Reset()
        {

            _output.WriteLine($"GameState ID={_gameStatueFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStatueFixture.State.Players.Add(player1);
            _gameStatueFixture.State.Players.Add(player2);

            _gameStatueFixture.State.Reset();

            Assert.Empty(_gameStatueFixture.State.Players);  


        }
    }
}
