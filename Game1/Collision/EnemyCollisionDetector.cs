using Game.Enemies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Game.Game;

namespace Game
{
    class EnemyCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IEnemy> enemyList;
        private List<IBlock> blockList;

        private Rectangle enemyRec;

        private sides hColFrom;
        private sides vColFrom;

        private EnemyCollisionHandler enemyColHandler;

        public EnemyCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            blockList = myGame.blockCamList;
            enemyList = myGame.enemyCamList;

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
                        enemyColHandler.hColFrom = hColFrom;
                        enemyColHandler.vColFrom = vColFrom;
                        enemyColHandler.HandleCollision(enemy);
                    }

                }
            }
        }

        public void CollidesFrom(Rectangle blockRec)
        {
            hColFrom = sides.none;
            vColFrom = sides.none;

            if ((enemyRec.Top <= blockRec.Top && enemyRec.Bottom >= blockRec.Top + 2) || (enemyRec.Top > blockRec.Top && blockRec.Bottom >= enemyRec.Top - 2))
            {
                if (enemyRec.Right > blockRec.Right)
                {
                    hColFrom = sides.right;
                }
                else if (enemyRec.Left < blockRec.Left)
                {
                    hColFrom = sides.left;
                }
            }

            if ((enemyRec.Left <= blockRec.Left && enemyRec.Right >= blockRec.Left + 2) || (enemyRec.Left > blockRec.Left && blockRec.Right >= enemyRec.Left - 2))
            {
                if (enemyRec.Bottom > blockRec.Bottom)
                {
                    vColFrom = sides.bottom;
                }
                else if (enemyRec.Top < blockRec.Top)
                {
                    vColFrom = sides.top;
                }
            }
        }
        
    }
}
