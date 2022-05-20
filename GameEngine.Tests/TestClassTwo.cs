using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [CollectionDefinition("GameState collection")]
    public class TestClassTwo: IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixure;
        private readonly ITestOutputHelper _output;

        public TestClassTwo(GameStateFixture gameStateFixure, ITestOutputHelper output)
        {
            _gameStateFixure = gameStateFixure;
            _output = output;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixure.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID = {_gameStateFixure.State.Id}");
        }
    }
}
