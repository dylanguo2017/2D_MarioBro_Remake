using Game.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class ProjectileCollisionDetector
    {
        private Game myGame;
        private List<ISprite> projectileCollisionList;
        private List<IBlock> blockList;
        private List<IEnemy> enemyList;

        private Rectangle projectileRec;
        private Rectangle objectRec;

        private String projectileColFromHorizontalSide;
        private String projectileColFromVerticalSide;

        private ICollisionResponseProjectile projectileColHandler;
        List<Fireball> proj;
        List<Fireball> toBeRemoved;

        public ProjectileCollisionDetector(Game game,List<Fireball> projectile)
        {
            myGame = game;
            projectileCollisionList = new List<ISprite>();
            proj = projectile;
        }

        public void Update()
        {
            toBeRemoved = new List<Fireball>();
            if (proj.Count != 0)
            {
                foreach (Fireball fBalls in proj)
                {
                    projectileCollisionList = myGame.bgList;

                    projectileRec = fBalls.DestinationRectangle();

                    foreach (ISprite sprite in projectileCollisionList)
                    {
                        objectRec = sprite.DestinationRectangle();

                        if (projectileRec.Intersects(objectRec))
                        {
                            if (!sprite.type.Contains("BgElement"))
                            {
                                CollidesFrom();
                                Type(sprite);
                                projectileColHandler.HandleCollision(fBalls, sprite, projectileColFromHorizontalSide, projectileColFromVerticalSide);
                            }
                        }
                    }
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

        public void CollidesFrom()
        {
            projectileColFromHorizontalSide = "none";
            projectileColFromVerticalSide = "none";

            if (projectileRec.Left > objectRec.Right - 2 && ((projectileRec.Top <= objectRec.Top && projectileRec.Bottom >= objectRec.Top + 2) || (projectileRec.Top > objectRec.Top && objectRec.Bottom >= projectileRec.Top - 2)))
            {
                projectileColFromHorizontalSide = "right";
            }
            else if (projectileRec.Right < objectRec.Left + 2 && ((projectileRec.Top <= objectRec.Top && projectileRec.Bottom >= objectRec.Top + 2) || (projectileRec.Top > objectRec.Top && objectRec.Bottom >= projectileRec.Top - 2)))
            {
                projectileColFromHorizontalSide = "left";
            }

            if (projectileRec.Bottom > objectRec.Bottom && projectileRec.Top > objectRec.Bottom - 2 && ((projectileRec.Left <= objectRec.Left && projectileRec.Right >= objectRec.Left + 2) || (projectileRec.Left > objectRec.Left && objectRec.Right >= projectileRec.Left - 2)))
            {
                projectileColFromVerticalSide = "bottom";
            }
            else if (projectileRec.Top < objectRec.Top && projectileRec.Bottom < objectRec.Top + 2 && ((projectileRec.Left <= objectRec.Left && projectileRec.Right >= objectRec.Left + 2) || (projectileRec.Left > objectRec.Left && objectRec.Right >= projectileRec.Left - 2)))
            {
                projectileColFromVerticalSide = "top";

            }

        }

        private void Type(ISprite sprite)
        {
            if (sprite.type.Contains("Block"))
            {
                projectileColHandler = new ProjectileBlockCollisionHandler(myGame);
            }
            else if (sprite.type.Contains("Enemy"))
            {
                projectileColHandler = new ProjectileEnemyCollisionHandler(myGame);
            }
        }


    }
}
