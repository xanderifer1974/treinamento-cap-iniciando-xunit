using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [CollectionDefinition("GameState collection")]
    public class TestClassOne: IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixure;
        private readonly ITestOutputHelper _output;

        public TestClassOne(GameStateFixture gameStateFixure, ITestOutputHelper output)
        {
            _gameStateFixure = gameStateFixure;
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixure.State.Id}");
        }

        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixure.State.Id}");
        }
    }
}
