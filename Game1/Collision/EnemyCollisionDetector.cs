using Game.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class EnemyCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IEnemy> enemyList;
        private List<IBlock> blockList;

        private Rectangle enemyRec;

        private String enemyColFrom;
        private EnemyCollisionHandler enemyColHandler;

        public EnemyCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            blockList = myGame.blockList;
            enemyList = myGame.enemyList;

            Rectangle blockRec;

            foreach (IEnemy enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    blockRec = block.DestinationRectangle();

                    if (blockRec.X <= 800 && enemyRec.Intersects(blockRec))
                    {
                        CollidesFrom(blockRec);
                        enemyColHandler = new EnemyCollisionHandler(myGame);
                        enemyColHandler.HandleCollision(enemy, enemyColFrom);
                    }

                }
            }
        }

        public void CollidesFrom(Rectangle blockRec)
        {
            enemyColFrom = "none";

            if (enemyRec.Left > blockRec.Right - 2 && ((enemyRec.Top <= blockRec.Top && enemyRec.Bottom >= blockRec.Top + 2) || (enemyRec.Top > blockRec.Top && blockRec.Bottom >= enemyRec.Top - 2)))
            {
                enemyColFrom = "left";
            }
            else if (enemyRec.Right < blockRec.Left + 2 && ((enemyRec.Top <= blockRec.Top && enemyRec.Bottom >= blockRec.Top + 2) || (enemyRec.Top > blockRec.Top && blockRec.Bottom >= enemyRec.Top - 2)))
            {
                enemyColFrom = "right";
            }
        }
        
    }
}
