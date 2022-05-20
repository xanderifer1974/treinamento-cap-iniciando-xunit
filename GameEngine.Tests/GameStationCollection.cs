using GameEngine.Tests;
using Xunit;

namespace GameEngine
{
    [CollectionDefinition("GameState collection")]
    public class GameStationCollection: ICollectionFixture<GameStateFixture>
    {

    }
}
