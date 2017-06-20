using Game.Sprites;

namespace Game
{
    class ZCommand : ICommand
    {
        private Game myGame;

        public ZCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.questionMarkBlock.ToggleSpriteSheet(myGame.usedBlockSprite, 1, 1);
        }
    }
}
