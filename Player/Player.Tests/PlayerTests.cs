using Xunit;

namespace DontPanic.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void ShouldHaveTrueWhenCloneNeedBlock()
        {
            // Arrange
            var currentElevator = new Elevator
            {
                Floor = 0,
                Pos = 3
            };
            var clonePosition = 4;
            var directionClone = "RIGHT";

            // Act
            var needBlock = Player.NeedBlock(currentElevator, clonePosition, directionClone);

            // Assert
            Assert.True(needBlock);
        }
    }
}
