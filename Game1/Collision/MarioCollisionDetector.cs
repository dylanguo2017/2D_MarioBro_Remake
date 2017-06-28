﻿using Microsoft.Xna.Framework;
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
            
            foreach (IObject gameObject in marioCollisionList)
            {
                objectRec = gameObject.DestinationRectangle();

                if (marioRec.Intersects(objectRec))
                {

                    ISprite sprite = gameObject as ISprite;
                    if (!sprite.type.Contains("BgElement"))
                    {
                        if (!sprite.type.Contains("Item") && sprite.visible == true)
                        {
                            MarioMovement();
                            Type(gameObject);
                            marioCollisionHandler.HandleCollision(myGame.mario, gameObject, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);

                        }
                    }
                }
            }
        }

        private void MarioMovement()
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";
            
            if (marioRec.Left > objectRec.Right - 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "right";
                myGame.marioState.left = false;
            }
            else if (marioRec.Right < objectRec.Left + 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "left";
                myGame.marioState.right = false;
            }

            if (marioRec.Bottom > objectRec.Bottom && marioRec.Top > objectRec.Bottom - 2 && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "bottom";
                myGame.marioState.up = false;
            }
            else if (marioRec.Top < objectRec.Top && marioRec.Bottom < objectRec.Top + 2 && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "top";
                myGame.marioState.down = false;
            }

        }
        
        private void Type(IObject gameObject)
        {
            ISprite sprite = gameObject as ISprite;
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
        
    }
}
