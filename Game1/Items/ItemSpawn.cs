using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{
    public class ItemSpawn
    {
        private Game myGame;
        public List<RedMushroomItem> spawnItem;
        public List<RedMushroomItem> spawned;
        public ItemSpawn(Game game)
        {
            myGame = game;
            spawnItem = new List<RedMushroomItem>();
            spawned = new List<RedMushroomItem>();
        }
        public void SpawnItem(Point spawnLoc)
        {
            RedMushroomItem spawnThis = new RedMushroomItem(myGame, myGame.itemSprite, twentyOne, thirtySix, spawnLoc.X, spawnLoc.Y);
            spawnItem.Add(spawnThis);
        }
        public void Update()
        {
            if(spawnItem.Count != 0)
            {
                foreach (RedMushroomItem spawnIt in spawnItem)
                {
                    spawnIt.spawnCtr++;
                    if (spawnIt.spawnCtr > sixteen)
                    {
                        spawned.Add(spawnIt);
                    }
                }
            }
            if(spawned.Count != zero)
            {
                foreach (RedMushroomItem spawnIt in spawned)
                {
                    spawnItem.Remove(spawnIt);
                    myGame.itemList.Add(spawnIt);
                    myGame.itemCamList.Add(spawnIt);
                }
                spawned.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (RedMushroomItem spawnIt in spawnItem)
            {
                spawnIt.Draw(spriteBatch);
            }
        }
    }
}
