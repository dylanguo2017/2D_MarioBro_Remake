using System;

namespace Game
{
    public class MarioBlockCollisionHandler
    {
        private Game myGame;
        private String horizontalSide;
        private String verticalSide;

        public MarioBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IBlock block, String marioColFromHorizontalSide, String marioColFromVerticalSide)
        {
            horizontalSide = marioColFromHorizontalSide;
            verticalSide = marioColFromVerticalSide;

            DisableMarioMovement();
            if (verticalSide.Equals("bottom"))
            {
                myGame.marioState.up = false;
                myGame.marioState.marioPhys.yVel = 0;
                if (block is Question)
                {
                    HandleQuestion(block);
                }
                else if (block is Brick)
                {
                    HandleBrick(block);
                }
                else if (block is Invisible)
                {
                    HandleInvisible(block);
                }
            }
            else if (verticalSide.Equals("top"))
            {
                myGame.marioState.marioPhys.DontFall();
                myGame.marioState.jmpCtr = 100;
                myGame.marioState.jump = false;
            }
        }


        private void HandleQuestion(IBlock block)
        {
            Question question = block as Question;

            if (!question.used && !question.hit)
            {
                question.BumpBlock();
                question.ChangeToUsed();
            }
        }
        private void HandleInvisible(IBlock block)
        {
            Invisible invisible = block as Invisible;

            if (!invisible.used && !invisible.hit)
            {
                invisible.BumpBlock();
                invisible.ChangeToUsed();
            }
        }

        private void HandleBrick(IBlock block)
        {
            if (!(myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                block.visible = false;
            }
            else
            {
                Brick brickBlock = block as Brick;
                if (!brickBlock.hit)
                {
                    brickBlock.BumpBlock();
                }
            }
        }

        private void DisableMarioMovement()
        {
            if(horizontalSide.Equals("right"))
            {
                myGame.marioState.right = false;
            }
            else if (horizontalSide.Equals("left"))
            {
                myGame.marioState.left = false;
            }

            if (verticalSide.Equals("bottom"))
            {
                myGame.marioState.up = false;
            }
            else if (verticalSide.Equals("top"))
            {
                myGame.marioState.down = false;
            }
        }
       
    }
}
