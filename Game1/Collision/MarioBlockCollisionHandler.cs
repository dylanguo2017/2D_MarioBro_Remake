﻿using Game.Blocks;
using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game
{
    public class MarioBlockCollisionHandler
    {
        private Game myGame;
        public sides hColFrom { get; set; }
        public sides vColFrom { get; set; }
        public Rectangle intersecRec;

        public MarioBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IBlock block)
        {
            if (block.visible)
            {
                DisableMarioMovement();

                if (myGame.marioState.flagpole)
                {
                    HandleLvlComp(block);
                }

                if (vColFrom.Equals(sides.bottom))
                {
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
                    else if (block is BlueBrick)
                    {
                        HandleBlueBrick(block);
                    }

                }
                else if (vColFrom.Equals(sides.top))
                {
                    myGame.marioState.marioPhys.DontFall();
                    myGame.marioState.marioPhys.YCoor -= (intersecRec.Height - one);
                    myGame.marioState.jmpCtr = 20;
                    myGame.marioState.jump = false;
                    myGame.marioState.wPress = false;
                    if (block is PipeTransition && myGame.marioState.crouch)
                    {
                        HandlePipeTransition(block);
                    }
                }
                else if (hColFrom.Equals(sides.left))
                {
                    if (block is SidePipe)
                    {
                        HandleSidePipe(block);
                    }
                }

            }
        }

        private void HandleSidePipe(IBlock block)
        {
            Transition.EndTransition();
            myGame.sound.state = soundStates.mainTheme;
        }

        private void HandleQuestion(IBlock block)
        {
            Question question = block as Question;

            if (!question.used && !question.hit)
            {
                question.BumpUp();
                question.ChangeToUsed();
                
                myGame.itemSpawn.SpawnItem(question.drawLoc, question);
                if (question.contain.Equals(Utility.items.coin))
                {
                    myGame.soundEffect.Coin();
                    myGame.hud.addCoin();
                }
                else if (!question.contain.Equals(Utility.items.none))
                {
                    myGame.soundEffect.PowerupAppears();
                }
            }
        }

        private void HandleInvisible(IBlock block)
        {
            Invisible invisible = block as Invisible;

            if (!invisible.used && !invisible.hit)
            {
                invisible.BumpUp();
                invisible.ChangeToUsed();
            }
        }

        private void HandleBrick(IBlock block)
        {
            Brick brick = block as Brick;
            if (!(myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                brick.Break();
            }
            else
            {
                if (!brick.hit)
                {
                    brick.BumpUp();
                }
            }
        }

        private void HandleBlueBrick(IBlock block)
        {
            BlueBrick brick = block as BlueBrick;
            if (!(myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                brick.Break();
            }
            else
            {
                if (!brick.hit)
                {
                    brick.BumpUp();
                }
            }
        }

        private void HandlePipeTransition(IBlock block)
        {
            myGame.soundEffect.IntoTheTunnel();
            Transition.StartTransition();
        }

        private void HandleLvlComp(IBlock block)
        {
            myGame.marioState.lvlComp = true;
            if (block is Castle)
            {
                myGame.mario.visible = false;
                myGame.marioState.flagpole = false;
            }
            else if (block is Diamond)
            {
                myGame.marioState.MoveR();
            }
            else
            {
                myGame.marioState.MoveR();
            }
        }

        private void DisableMarioMovement()
        {
            if(hColFrom.Equals(sides.right))
            {
                myGame.marioState.left = false;
            }
            else if (hColFrom.Equals(sides.left))
            {
                myGame.marioState.right = false;
            }

            if (vColFrom.Equals(sides.bottom))
            {
                myGame.marioState.up = false;
            }
            else if (vColFrom.Equals(sides.top))
            {
                myGame.marioState.down = false;
            }
        }
       
    }
}
