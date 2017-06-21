﻿using Game.Sprites;

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
            Level.ReloadList(myGame.list, myGame.usedBlockSprite, "QuestionMarkBlock", 1);
        }
    }
}
