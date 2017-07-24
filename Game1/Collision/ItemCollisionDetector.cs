using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{
    class ItemCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IItem> itemList;
        private List<IBlock> blockList;

        private Rectangle itemRec;

        private sides hColFrom;
        private sides vColFrom;

        private ItemCollisionHandler itemColHandler;

        public ItemCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            blockList = myGame.blockCamList;
            itemList = myGame.itemCamList;

            Rectangle blockRec;
            foreach (IItem item in itemList)
            {
                itemRec = item.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    blockRec = block.DestinationRectangle();

                    if (block.visible && itemRec.Intersects(blockRec))
                    {
                        CollidesFrom(blockRec);
                        itemColHandler = new ItemCollisionHandler(myGame);
                        itemColHandler.hColFrom = hColFrom;
                        itemColHandler.vColFrom = vColFrom;
                        itemColHandler.HandleCollision(item);
                    }
                }

            }
        }

        public void CollidesFrom(Rectangle blockRec)
        {
            hColFrom = sides.none;
            vColFrom = sides.none;

            if ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + two) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - two))
            {
                if (itemRec.Right > blockRec.Right)
                {
                    hColFrom = sides.right;
                }
                else if (itemRec.Left < blockRec.Left)
                {
                    hColFrom = sides.left;
                }
            }

            if ((itemRec.Left <= blockRec.Left && itemRec.Right >= blockRec.Left + two) || (itemRec.Left > blockRec.Left && blockRec.Right >= itemRec.Left - two))
            {
                if (itemRec.Bottom > blockRec.Bottom)
                {
                    vColFrom = sides.bottom;
                }
                else if (itemRec.Top < blockRec.Top)
                {
                    vColFrom = sides.top;
                }
            }
        }

    }
}
