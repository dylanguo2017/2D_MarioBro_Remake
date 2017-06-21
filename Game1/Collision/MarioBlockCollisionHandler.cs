using Game.Sprites;
using System;

namespace Game
{
    public class MarioBlockCollisionHandler : ICollisionResponse
    {
        private Game myGame;

        public MarioBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite block = gameObject as ISprite;
            if (marioCollidesFromVerticalSide.Equals("bottom"))
            {
                if (block.type.Equals("QuestionMarkBlock"))
                {
                    block.ToggleSpriteSheet(myGame.usedBlockSprite, 1, 1);
                }
                else if (block.type.Equals("BrickBlock"))
                {
                    if (!(myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
                    {
                        block.visible = false;
                    }
                }
                else if (block.type.Equals("InvisibleBlock"))
                {
                    block.texture = myGame.usedBlockSprite;
                }
            }
        }
    }
}
