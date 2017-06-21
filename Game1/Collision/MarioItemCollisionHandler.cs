using System;

namespace Game
{
    public class MarioItemCollisionHandler : ICollisionResponse
    {
        private Game myGame;

        public MarioItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite item = gameObject as ISprite;
            if (item.type.Contains("Item"))
            {
                item.visible = false;
            }

            if (item.type.Equals("StarItem"))
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
            else if (item.type.Equals("RedMushroomItem"))
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
            else if (item.type.Equals("FireFlowerItem"))
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
