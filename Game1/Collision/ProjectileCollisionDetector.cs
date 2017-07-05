using Game.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class ProjectileCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IBlock> blockList;
        private List<IEnemy> enemyList;

        private Rectangle projRec;
        private Rectangle blockRec;
        private Rectangle enemyRec;

        private String projColFrom;

        private ProjectileBlockCollisionHandler projBlockColHandler;
        private ProjectileEnemyCollisionHandler projEnemyColHandler;

        List<Fireball> proj;
        List<Fireball> toBeRemoved;

        public ProjectileCollisionDetector(Game game,List<Fireball> projectile)
        {
            myGame = game;
            proj = projectile;
        }

        public void Update()
        {
            blockList = myGame.blockList;
            enemyList = myGame.enemyList;

            toBeRemoved = new List<Fireball>();
            if (proj.Count != 0)
            {
                foreach (Fireball fBalls in proj)
                {
                    projRec = fBalls.DestinationRectangle();

                    DetectProjBlockCol(fBalls);
                    DetectProjEnemyCol(fBalls);

                    if (fBalls.deleted)
                    {
                        toBeRemoved.Add(fBalls);
                    }
                }
                if (toBeRemoved.Count > 0)
                {
                    foreach (Fireball fireB in toBeRemoved)
                    {
                        proj.Remove(fireB);
                    }
                }
            }
        }

        private void DetectProjBlockCol(Fireball fBalls)
        {
            foreach (IBlock block in blockList)
            {
                blockRec = block.DestinationRectangle();

                if (blockRec.X <= 800 && projRec.Intersects(blockRec))
                {
                    CollidesFrom(blockRec);
                    projBlockColHandler = new ProjectileBlockCollisionHandler(myGame);
                    projBlockColHandler.HandleCollision(fBalls, projColFrom);
                }
            }
        }

        private void DetectProjEnemyCol(Fireball fBalls)
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                if (enemyRec.X <= 800 && projRec.Intersects(enemyRec))
                {
                    CollidesFrom(enemyRec);
                    projEnemyColHandler = new ProjectileEnemyCollisionHandler(myGame);
                    projEnemyColHandler.HandleCollision(enemy);
                }
            }
        }

        public void CollidesFrom(Rectangle objectRec)
        {
            projColFrom = "none";

            if (projRec.Bottom > objectRec.Bottom && projRec.Top > objectRec.Bottom - 2 && ((projRec.Left <= objectRec.Left && projRec.Right >= objectRec.Left + 2) || (projRec.Left > objectRec.Left && objectRec.Right >= projRec.Left - 2)))
            {
                projColFrom = "bottom";
            }
            else if (projRec.Top < objectRec.Top && projRec.Bottom < objectRec.Top + 2 && ((projRec.Left <= objectRec.Left && projRec.Right >= objectRec.Left + 2) || (projRec.Left > objectRec.Left && objectRec.Right >= projRec.Left - 2)))
            {
                projColFrom = "top";

            }

        }


    }
}
