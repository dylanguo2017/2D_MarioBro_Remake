using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class EnemyCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<ISprite> enemyList;
        private List<ISprite> enemyCollisionList;
        private Rectangle enemyRec;
        private Rectangle objectRec;
        private String enemyCollidesFrom;
        private /*ICollisionResponse*/ EnemyCollisionHandler enemyCollisionHandler;

        public EnemyCollisionDetector(Game game)
        {
            myGame = game;
            enemyList = new List<ISprite>();
            enemyCollisionList = new List<ISprite>();
        }

        public void Update()
        {
            enemyCollisionList = myGame.list;

            foreach (ISprite sprite in enemyCollisionList)
            {
                if (sprite.type.Contains("Enemy"))
                {
                    enemyList.Add(sprite);
                }
            }

            foreach (ISprite enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                //foreach (ISprite sprite in enemyCollisionList)
                //{
                //    objectRec = sprite.DestinationRectangle();

                    //if (enemyRec.Intersects(objectRec))
                    //{
                    //    if (!sprite.type.Contains("BgElement"))
                    //    {
                    //        //CollidesFrom();
                    //        //enemyCollisionHandler = new EnemyCollisionHandler(myGame);
                    //        //enemyCollisionHandler.HandleCollision(enemy, enemyCollidesFrom);
                    //    }
                    //}
                //}
            }
        }

        public void CollidesFrom()
        {
            enemyCollidesFrom = "none";

            if (enemyRec.Left > objectRec.Right - 2 && ((enemyRec.Top <= objectRec.Top && enemyRec.Bottom >= objectRec.Top + 2) || (enemyRec.Top > objectRec.Top && objectRec.Bottom >= enemyRec.Top - 2)))
            {
                enemyCollidesFrom = "right";
            }
            else if (enemyRec.Right < objectRec.Left + 2 && ((enemyRec.Top <= objectRec.Top && enemyRec.Bottom >= objectRec.Top + 2) || (enemyRec.Top > objectRec.Top && objectRec.Bottom >= enemyRec.Top - 2)))
            {
                enemyCollidesFrom = "left";
            }
        }
        
    }
}
