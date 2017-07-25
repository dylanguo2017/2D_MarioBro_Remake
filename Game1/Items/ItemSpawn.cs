using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{
    public class ItemSpawn
    {
        private Game myGame;
        private List<IItem> spawnItem;
        private List<IItem> spawned;

        public ItemSpawn(Game game)
        {
            myGame = game;
            spawnItem = new List<IItem>();
            spawned = new List<IItem>();
        }

        public void SpawnItem(Point spawnLoc, Question theQ)
        {
            if (theQ.contain.Equals(Utility.items.redM))
            {
                IItem spawnThis = new RedMushroom(myGame, spawnLoc.X, spawnLoc.Y);
                spawnItem.Add(spawnThis);
            }
            if (theQ.contain.Equals(Utility.items.coin))
            {
                IItem spawnThis = new Coin(myGame, spawnLoc.X, spawnLoc.Y);
                spawnItem.Add(spawnThis);
            }
            if (theQ.contain.Equals(Utility.items.greenM))
            {
                IItem spawnThis = new GreenMushroom(myGame, spawnLoc.X, spawnLoc.Y);
                spawnItem.Add(spawnThis);
            }
            if (theQ.contain.Equals(Utility.items.flower))
            {
                IItem spawnThis = new FireFlower(myGame, spawnLoc.X, spawnLoc.Y);
                spawnItem.Add(spawnThis);
            }

        }

        public void Update()
        {
            if(spawnItem.Count != 0)
            {
                foreach (IItem spawnIt in spawnItem)
                {
                    spawnIt.spwnCtr++;
                    if (spawnIt.spwnCtr > stdSpriteSize)
                    {
                        spawned.Add(spawnIt);
                    }
                }
            }
            if(spawned.Count != zero)
            {
                foreach (IItem spawnIt in spawned)
                {
                    spawnItem.Remove(spawnIt);
                    if (spawnIt is Coin)
                    {

                    } 
                    else
                    {
                        myGame.itemList.Add(spawnIt);
                        myGame.itemCamList.Add(spawnIt);
                    }
                }
                spawned.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem spawnIt in spawnItem)
            {
                spawnIt.Draw(spriteBatch);
            }
        }
    }
}
