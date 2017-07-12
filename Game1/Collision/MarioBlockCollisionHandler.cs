namespace Game
{
    public class MarioBlockCollisionHandler
    {
        private Game myGame;
        public Game.sides hColFrom { get; set; }
        public Game.sides vColFrom { get; set; }

        public MarioBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IBlock block)
        {
            if (block.visible)
            {
                DisableMarioMovement();
                if (vColFrom.Equals(Game.sides.bottom))
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
                else if (vColFrom.Equals(Game.sides.top))
                {
                    myGame.marioState.marioPhys.DontFall();
                    myGame.marioState.jmpCtr = 100;
                    myGame.marioState.jump = false;
                    myGame.marioState.wPress = false;
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

        private void DisableMarioMovement()
        {
            if(hColFrom.Equals(Game.sides.right))
            {
                myGame.marioState.left = false;
            }
            else if (hColFrom.Equals(Game.sides.left))
            {
                myGame.marioState.right = false;
            }

            if (vColFrom.Equals(Game.sides.bottom))
            {
                myGame.marioState.up = false;
            }
            else if (vColFrom.Equals(Game.sides.top))
            {
                myGame.marioState.down = false;
            }
        }
       
    }
}
