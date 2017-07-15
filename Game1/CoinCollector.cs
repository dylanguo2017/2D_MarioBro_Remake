using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public static class CoinCollector
    {

        
        private static int numberOfCoins=0;


        public static void setToZero()
        {
            numberOfCoins = 0;

        }

        public static void increment()
        {
            numberOfCoins++;
        }

        public static int coinOutput()
        {
            return numberOfCoins;
        }

        

        


    }
}
