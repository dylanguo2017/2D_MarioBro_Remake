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
                    MarioCollidesFrom();
                    Type(gameObject);

                    ISprite sprite = gameObject as ISprite;
                    if (!sprite.type.Contains("BgElement"))
                    {
                        marioCollisionHandler.HandleCollision(myGame.mario, gameObject, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);

                        if (!sprite.type.Contains("Item") && sprite.visible == true)
                        {
                            DisableMarioMovement();
                        }
                    }
                }
            }
        }

        private void MarioCollidesFrom()
        {
            marioCollidesFromHorizontalSide = "none";
            if (marioRec.Left > objectRec.Left && marioRec.Left > objectRec.Right - 2)
            {
                marioCollidesFromHorizontalSide = "right";
            }

            if (marioRec.Right < objectRec.Right && marioRec.Right < objectRec.Left + 2)
            {
                marioCollidesFromHorizontalSide = "left";
            }

            marioCollidesFromVerticalSide = "none";
            if (marioRec.Bottom > objectRec.Bottom && marioRec.Top > objectRec.Bottom - 2)
            {
                marioCollidesFromVerticalSide = "bottom";
            }

            if (marioRec.Top < objectRec.Top && marioRec.Bottom < objectRec.Top + 2)
            {
                marioCollidesFromVerticalSide = "top";
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

        private void DisableMarioMovement()
        {
            if (marioCollidesFromHorizontalSide.Equals("none"))
            {
                if (marioRec.Right > objectRec.Right)
                {
                    myGame.marioState.left = false;
                }
                if (marioRec.Left < objectRec.Left)
                {
                    myGame.marioState.right = false;
                }
            }

            if (marioCollidesFromVerticalSide.Equals("none"))
            {
                if (marioRec.Bottom > objectRec.Bottom)
                {
                    myGame.marioState.up = false;
                }
                if (marioRec.Top < objectRec.Top)
                {
                    myGame.marioState.down = false;
                }
            }
        }

    }
}
