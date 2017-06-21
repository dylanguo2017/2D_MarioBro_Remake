using Game.Sprites;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    class CCommand : ICommand
    {
        private Game myGame;

        public CCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            List<ISprite> modifiedList = new List<ISprite>();
            foreach (ISprite sprite in myGame.list)
            {
                if (sprite.type.Equals("InvisibleBlock"))
                {
                    ISprite invisibleBlock = sprite;
                    invisibleBlock.texture = myGame.usedBlockSprite;
                    modifiedList.Add(invisibleBlock);
                }
                else
                {
                    modifiedList.Add(sprite);
                }
            }
            myGame.list = new List<ISprite>(modifiedList);
        }
    }
}
