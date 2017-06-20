﻿using System;

namespace Game
{
    class MarioItemCollisionHandler : ICollisionResponse
    {
        private Game myGame;

        public MarioItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollison(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
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
                myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
            }
            else if (item.type.Equals("FireFlowerItem"))
            {
                myGame.mario = new FireMario(myGame.marioState, myGame.marioSprites);
            }
        }
    }
}
