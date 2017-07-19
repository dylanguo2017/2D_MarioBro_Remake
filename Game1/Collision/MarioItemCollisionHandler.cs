namespace Game
{
    public class MarioItemCollisionHandler
    {
        private Game myGame;

        public MarioItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IItem item)
        {
            if (item.visible)
            {
                if (item is StarItem)
                {
                    StarItem star = item as StarItem;
                    star.PowerUp();
                }
                else if (item is RedMushroomItem)
                {
                    RedMushroomItem redMushroom = item as RedMushroomItem;
                    redMushroom.PowerUp();
                }
                else if (item is FlowerItem)
                {
                    FlowerItem fireFlower = item as FlowerItem;
                    fireFlower.PowerUp();
                }
                else if(item is GreenMushroomItem)
                {
                    GreenMushroomItem greenMushroom = item as GreenMushroomItem;
                    greenMushroom.OneUp();
                }
                else if(item is CoinItem)
                {
                    CoinItem coin = item as CoinItem;
                    coin.Collect();
                }
                else if(item is Flagpole)
                {
                    myGame.marioState.flagpole = true;
                }
            }

        }

    }
}
