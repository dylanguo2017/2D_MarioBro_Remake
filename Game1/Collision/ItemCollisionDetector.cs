using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class ItemCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<ISprite> itemList;
        private List<ISprite> itemCollisionList;
        private Rectangle itemRec;
        private Rectangle objectRec;
        private String itemCollidesFrom;
        private /*ICollisionResponse*/ ItemCollisionHandler itemCollisionHandler;

        public ItemCollisionDetector(Game game)
        {
            myGame = game;
            itemList = new List<ISprite>();
            itemCollisionList = new List<ISprite>();
        }

        public void Update()
        {
            itemList = Level.ItemList();
            itemCollisionList = myGame.list;

            foreach (ISprite item in itemList)
            {
                itemRec = item.DestinationRectangle();
                foreach (ISprite sprite in itemCollisionList)
                {
                    {
                        objectRec = sprite.DestinationRectangle();

                        if (itemRec.Intersects(objectRec))
                        {
                            if (!sprite.type.Contains("BgElement"))
                            {
                                if (itemRec.Center != objectRec.Center)
                                {
                                    CollidesFrom();
                                    itemCollisionHandler = new ItemCollisionHandler(myGame);
                                    itemCollisionHandler.HandleCollision(item, itemCollidesFrom);
                                }
                            }
                        }
                    }


                }
            }
        }

        public void CollidesFrom()
        {
            itemCollidesFrom = "none";

            if (itemRec.Left > objectRec.Right - 2 && ((itemRec.Top <= objectRec.Top && itemRec.Bottom >= objectRec.Top + 2) || (itemRec.Top > objectRec.Top && objectRec.Bottom >= itemRec.Top - 2)))
            {
                itemCollidesFrom = "right";
            }
            else if (itemRec.Right < objectRec.Left + 2 && ((itemRec.Top <= objectRec.Top && itemRec.Bottom >= objectRec.Top + 2) || (itemRec.Top > objectRec.Top && objectRec.Bottom >= itemRec.Top - 2)))
            {
                itemCollidesFrom = "left";
            }
        }

    }
}
