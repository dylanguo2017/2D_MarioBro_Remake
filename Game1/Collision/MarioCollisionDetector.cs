using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class MarioCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<ISprite> marioCollisionList;
        private Rectangle marioRec;
        private Rectangle objectRec;
        private String marioCollidesFromHorizontalSide;
        private String marioCollidesFromVerticalSide;
        private ICollisionResponse marioCollisionHandler;
        private int differenceCoor = 0;
        public int dCoor
        {
            get
            {
                return differenceCoor;
            }
        }

        public MarioCollisionDetector(Game game)
        {
            myGame = game;
            marioCollisionList = new List<ISprite>();
        }

        public void Update()
        {
            marioCollisionList = myGame.list;

            marioRec = myGame.mario.DestinationRectangle();
            
            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;
            
            foreach (ISprite sprite in marioCollisionList)
            {
                objectRec = sprite.DestinationRectangle();

                if (marioRec.Intersects(objectRec))
                {
                    if (!sprite.type.Contains("BgElement"))
                    {
                        CollidesFrom();
                        Type(sprite);
                        marioCollisionHandler.HandleCollision(myGame.mario, sprite, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);
                        // move logic for disabling mario movement in its handler classes
                        if (!sprite.type.Contains("Item") && sprite.visible == true)
                        {
                            DisableMovement();
                        }
                    }
                }
            }
        }

        public void CollidesFrom()
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";
            
            if (marioRec.Left > objectRec.Right - 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "right";
            }
            else if (marioRec.Right < objectRec.Left + 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > objectRec.Bottom && marioRec.Top > objectRec.Bottom - 2 && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < objectRec.Top && marioRec.Bottom < objectRec.Top + 2  && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "top";
                
            }

        }

        private void Type(ISprite sprite)
        {
            if (sprite.type.Contains("Block"))
            {
                marioCollisionHandler = new MarioBlockCollisionHandler(myGame);
            }
            else if (sprite.type.Contains("Item"))
            {
                marioCollisionHandler = new MarioItemCollisionHandler(myGame);
            }
            else if (sprite.type.Contains("Enemy"))
            {
                marioCollisionHandler = new MarioEnemyCollisionHandler(myGame);
            }
        }

        private void DisableMovement()
        {
            if(marioCollidesFromHorizontalSide.Equals("right"))
            {
                myGame.marioState.left = false;
            }
            else if (marioCollidesFromHorizontalSide.Equals("left"))
            {
                myGame.marioState.right = false;
            }

            if (marioCollidesFromVerticalSide.Equals("bottom"))
            {
                myGame.marioState.up = false;
            }
            else if (marioCollidesFromVerticalSide.Equals("top"))
            {
                myGame.marioState.down = false;
            }
        }

    }
}
