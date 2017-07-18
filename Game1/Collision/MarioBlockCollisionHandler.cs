using Game.Blocks;
using Microsoft.Xna.Framework;
using static Game.Game;

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

                }
                else if (vColFrom.Equals(sides.top))
                {
                    myGame.marioState.marioPhys.DontFall();
                    myGame.marioState.marioPhys.YCoor -= (intersecRec.Height - 1);
                    myGame.marioState.jmpCtr = 20;
                    myGame.marioState.jump = false;
                    myGame.marioState.wPress = false;
                    if (block is PipeTransition)
                    {
                        HandlePipeTransition(block);
                    }
                }

            }
        }


        private void HandleQuestion(IBlock block)
        {
            Question question = block as Question;

            if (!question.used && !question.hit)
            {
                question.BumpUp();
                question.ChangeToUsed();
                myGame.soundEffect.PowerupAppears();
                myGame.itemSpawn.SpawnItem(question.drawLocation);
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

        private void HandlePipeTransition(IBlock block)
        {
            PipeTransition pipe = block as PipeTransition;
            pipe.Update();

            myGame.camera.pipeTransition();
            //System.Diagnostics.Debug.WriteLine("Handle pipe");

        }
        private void DisableMarioMovement()
        {
            if(hColFrom.Equals(sides.right))
            {
                myGame.marioState.left = false;
                //myGame.marioState.marioPhys.XCoor += intersecRec.Width;
            }
            else if (hColFrom.Equals(sides.left))
            {
                myGame.marioState.right = false;
                //myGame.marioState.marioPhys.XCoor -= intersecRec.Width;
            }

            if (vColFrom.Equals(sides.bottom))
            {
                myGame.marioState.up = false;
                //myGame.marioState.marioPhys.YCoor += intersecRec.Height;
            }
            else if (vColFrom.Equals(sides.top))
            {
                myGame.marioState.down = false;
            }
        }
       
    }
}
