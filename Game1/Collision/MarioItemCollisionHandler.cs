using System;

namespace Game
{
    public class MarioItemCollisionHandler
    {
        private Game myGame;

        public MarioItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IItem item)
        {
            item.visible = false;

            if (item is StarItem)
            {
                if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
                {
                    myGame.mario = new SmallStarMario(myGame.marioState, myGame.marioSprites);
                }
                else
                {
                    myGame.mario = new LargeStarMario(myGame.marioState, myGame.marioSprites);
                }
            }
            else if (item is RedMushroomItem)
            {
                if (myGame.marioState.star)
                {
                    myGame.mario = new LargeStarMario(myGame.marioState, myGame.marioSprites);
                }
                else
                {
                    myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
                }
            }
            else if (item is FlowerItem)
            {
                if (myGame.marioState.star)
                {
                    myGame.mario = new LargeStarMario(myGame.marioState, myGame.marioSprites);
                    myGame.marioState.curStat = MarioStateClass.marioStatus.fire;
                }
                else
                {
                    myGame.mario = new FireMario(myGame.marioState, myGame.marioSprites);
                }
            }
        }
    }
}
