using Game.Background;
using Game.Enemies;
using Game.Sprites;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    public static class Level
    {
        public static List<IEnemy> enemyList;
        public static List<IItem> itemList;
        public static List<IBlock> blockList;

        public static List<IBackground> bgList;

        public static void LoadLists(Game myGame)
        {
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();

            bgList = new List<IBackground>();

            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "Level1-1.txt")
         );
            String inComingLine;
            int positionRow = 0;

            while (!levelFile.EndOfStream)
            {
                inComingLine = levelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int positionColumn = 0;
                while (positionColumn < target.Length)
                {
                    if (target[positionColumn].Equals("brick"))
                    {
                        Brick gameObject = new Brick(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("crack"))
                    {
                        Crack gameObject = new Crack(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }                    
                    else if (target[positionColumn].Equals("diamond"))
                    {
                        Diamond gameObject = new Diamond(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("question"))
                    {
                        Question gameObject = new Question(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("questionRedMushroom"))
                    {
                        //make question block draw a red mushroom on top when hit
                    }
                    else if (target[positionColumn].Equals("questionGreenMushroom"))
                    {
                        //make question block draw a green mushroom on top when hit
                    }
                    else if (target[positionColumn].Equals("questionStar"))
                    {
                        //make question block draw a star on top when hit
                    }
                    else if (target[positionColumn].Equals("questionCoin"))
                    {
                        //make question block gain a coin for mario when hit
                    }
                    else if (target[positionColumn].Equals("questionFlower"))
                    {
                        //make question block draw a fire flower on top when hit
                    }
                    else if (target[positionColumn].Equals("used"))
                    {
                        Used gameObject = new Used(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("invisible"))
                    {
                        Invisible gameObject = new Invisible(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("standardPipe"))
                    {
                        Pipe gameObject = new Pipe(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("star"))
                    {
                        StarItem gameObject = new StarItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("coin"))
                    {
                        CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flower"))
                    {
                        FlowerItem gameObject = new FlowerItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("redMushroom"))
                    {
                        RedMushroomItem gameObject = new RedMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("greenMushroom"))
                    {
                        GreenMushroomItem gameObject = new GreenMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("goomba"))
                    {
                        IEnemy gameObject = new GoombaEnemy(myGame, myGame.goombaEnemy, 1, 3, positionColumn * 16, positionRow * 16);
                        enemyList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("koopa"))
                    {
                        IEnemy gameObject = new KoopaEnemy(myGame, myGame.koopaEnemy, 1, 10, positionColumn * 16, positionRow * 16);
                        enemyList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneCloud"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.oneCloudBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeClouds"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.threeCloudsBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneBush"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.oneBushBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeBushes"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.threeBushesBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallMountain"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.smallMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("bigMountain"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.bigMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallCastle"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.smallCastle, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flagpole"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.flagpoleElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("title"))
                    {
                        IBackground gameObject = new Background.Background(myGame, myGame.titleScreen, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }

                    positionColumn++;
                }
                positionRow++;
            }
            levelFile.Close();
        }
        

    }
}
