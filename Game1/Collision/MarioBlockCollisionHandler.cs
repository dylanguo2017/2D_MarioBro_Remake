﻿using System;

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
                    Question question = block as Question;

                    if (!question.hit)
                    {
                        question.ToggleSpriteSheet(myGame.usedBlockSprite, 1, 1);
                        question.BumpBlock();
                    }

                }
                else if (block is Brick)
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
                else if (block is Invisible)
                {
                    block.texture = myGame.usedBlockSprite;
                }
            }
            else if (verticalSide.Equals("top"))
            {
                myGame.marioState.marioPhys.DontFall();
                myGame.marioState.jmpCtr = 100;
                myGame.marioState.jump = false;
            }
        }

        private void DisableMarioMovement()
        {
            if(horizontalSide.Equals("right"))
            {
                myGame.marioState.left = false;
            }
            else if (horizontalSide.Equals("left"))
            {
                myGame.marioState.right = false;
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
