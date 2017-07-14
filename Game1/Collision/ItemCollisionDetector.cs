using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Game.Game;

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
            blockList = myGame.blockList;
            itemList = myGame.itemList;

            Rectangle blockRec;
            foreach (IItem item in itemList)
            {
                itemRec = item.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    blockRec = block.DestinationRectangle();

                    if (blockRec.X <= 800 && itemRec.Intersects(blockRec))
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
            hColFrom = Game.sides.none;
            vColFrom = Game.sides.none;

            if ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + 2) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - 2))
            {
                if (itemRec.Right > blockRec.Right)
                {
                    hColFrom = Game.sides.right;
                }
                else if (itemRec.Left < blockRec.Left)
                {
                    hColFrom = Game.sides.left;
                }
            }

            if ((itemRec.Left <= blockRec.Left && itemRec.Right >= blockRec.Left + 2) || (itemRec.Left > blockRec.Left && blockRec.Right >= itemRec.Left - 2))
            {
                if (itemRec.Bottom > blockRec.Bottom)
                {
                    vColFrom = Game.sides.bottom;
                }
                else if (itemRec.Top < blockRec.Top)
                {
                    vColFrom = Game.sides.top;
                }
            }
        }

    }
}
