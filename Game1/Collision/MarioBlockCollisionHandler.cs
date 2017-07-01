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
                    MotionlessAnimatedSprite questionMarkBlock = block as MotionlessAnimatedSprite;

                    if (!questionMarkBlock.hit)
                    {
                        questionMarkBlock.ToggleSpriteSheet(myGame.usedBlockSprite, 1, 1);
                        questionMarkBlock.BumpBlock();
                    }

                }
                else if (block.type.Equals("BrickBlock"))
                {
                    if (!(myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
                    {
                        block.visible = false;
                    }
                    else
                    {
                        MotionlessAnimatedSprite brickBlock = block as MotionlessAnimatedSprite;
                        if (!brickBlock.hit)
                        {

                                brickBlock.BumpBlock();
                        }
                    }
                }
                else if (block.type.Equals("InvisibleBlock"))
                {
                    block.texture = myGame.usedBlockSprite;
                }
            }
            else if (marioCollidesFromVerticalSide.Equals("top"))
            {
                myGame.marioState.marioPhys.DontFall();
                myGame.marioState.jmpCtr = 100;
                myGame.marioState.jump = false;
            }
        }
    }
}
