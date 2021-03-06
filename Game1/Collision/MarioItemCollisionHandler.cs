﻿using static Game.Utility;
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
            if (item is Star)
            {
                Star star = item as Star;
                star.PowerUp();
            }
            else if (item is RedMushroom)
            {
                RedMushroom redMushroom = item as RedMushroom;
                redMushroom.PowerUp();
            }            
            else if (item is FireFlower)
            {
                FireFlower fireFlower = item as FireFlower;
                fireFlower.PowerUp();
            }
            else if (item is GreenMushroom)
            {
                GreenMushroom greenMushroom = item as GreenMushroom;
                greenMushroom.OneUp();
            }
            else if (item is Coin)
            {
                Coin coin = item as Coin;
                coin.Collect();
            }
            else if (item is BatItem)
            {
                BatItem bat = item as BatItem;
                bat.PowerUp();
            }
            else if (item is Flagpole)
            {
                myGame.marioState.flagpole = true;
                Flagpole flagPole = item as Flagpole;
                flagPole.flagDown = true;
                myGame.hud.increasePoints(fourHundred);
            }
            else if (item is SmallSpinFireBeam)
            {
                SmallSpinFireBeam beam = item as SmallSpinFireBeam;
                beam.ChangeMarioState();
            }
            else if (item is MediumSpinFireBeam)
            {
                MediumSpinFireBeam beam = item as MediumSpinFireBeam;
                beam.ChangeMarioState();
            }
            else if (item is LargeSpinFireBeam)
            {
                LargeSpinFireBeam beam = item as LargeSpinFireBeam;
                beam.ChangeMarioState();
            }

        }

    }
}
