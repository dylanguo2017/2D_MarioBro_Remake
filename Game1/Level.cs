using Game.Blocks;
using Game.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    public static class Level
    {
        public static List<IEnemy> enemyList;
        public static List<IItem> itemList;
        public static List<IBlock> blockList;

        public static List<IEnemy> enemyPipeList;
        public static List<IItem> itemPipeList;
        public static List<IBlock> blockPipeList;

        public static List<IBackground> bgList;

        public static void LoadLists(Game myGame)
        {
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();

            enemyPipeList = new List<IEnemy>();
            itemPipeList = new List<IItem>();
            blockPipeList = new List<IBlock>();

            bgList = new List<IBackground>();

            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "Level1-1.txt")
         );

            StreamReader bonusLevelFile = new StreamReader(
       Path.Combine(Directory.GetCurrentDirectory(),
                    "Content", "Levels", "Level1-1BONUS.txt")
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
                        //RedMushroomItem gameObject = new RedMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        //questionItemArray[countOfPopItem] = gameObject;
                        //countOfPopItem++;
                    }
                    else if (target[positionColumn].Equals("questionGreenMushroom"))
                    {
                        //GreenMushroomItem gameObject = new GreenMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        //questionItemArray[countOfPopItem] = gameObject;
                        //countOfPopItem++;
                    }
                    else if (target[positionColumn].Equals("questionStar"))
                    {
                        //StarItem gameObject = new StarItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        //questionItemArray[countOfPopItem] = gameObject;
                        //countOfPopItem++;
                    }
                    else if (target[positionColumn].Equals("questionCoin"))
                    {
                        //CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        //questionItemArray[countOfPopItem] = gameObject;
                        //countOfPopItem++;
                    }
                    else if (target[positionColumn].Equals("questionFlower"))
                    {
                        //FlowerItem gameObject = new FlowerItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        //questionItemArray[countOfPopItem] = gameObject;
                        //countOfPopItem++;
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

                    else if (target[positionColumn].Equals("standardPipeTransition"))
                    {
                        PipeTransition gameObject = new PipeTransition(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("popPipe"))
                    {
                        popPipe gameObject = new popPipe(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
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
                        IBackground gameObject = new Background(myGame, myGame.oneCloudBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeClouds"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.threeCloudsBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneBush"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.oneBushBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeBushes"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.threeBushesBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallMountain"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.smallMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("bigMountain"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.bigMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallCastle"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.smallCastle, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flagpole"))
                    {
                        IItem gameObject = new Flagpole(myGame, myGame.flagpoleElement, 1, 1, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("title"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.titleScreen, 1, 1, positionColumn * 16, positionRow * 16);
                        bgList.Add(gameObject);
                    }

                    positionColumn++;
                }
                positionRow++;
            }

            positionRow = 0;
            while (!bonusLevelFile.EndOfStream)
            {
                inComingLine = bonusLevelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int positionColumn = 0;

                while (positionColumn < target.Length)
                {
                    if (target[positionColumn].Equals("blueBrick"))
                    {
                        BlueBrick gameObject = new BlueBrick(myGame, myGame.blueBlockSprite, 1, 2, positionColumn * 16, positionRow * 16);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("blueCrack"))
                    {
                        BlueCrack gameObject = new BlueCrack(myGame, myGame.blueBlockSprite, 1, 2, positionColumn * 16, positionRow * 16);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("coin"))
                    {
                        CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("sidePipe"))
                    {
                        SidePipe gameObject = new SidePipe(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockPipeList.Add(gameObject);
                    }
                    positionColumn++;
                }
                positionRow++;
            }
            levelFile.Close();
            bonusLevelFile.Close();
            IComparer<IBlock> blockComp = new BlockComparer<IBlock>();
            IComparer<IItem> itemComp = new ItemComparer<IItem>();
            IComparer<IEnemy> enemyComp = new EnemyComparer<IEnemy>();
            blockList.Sort(blockComp);
            itemList.Sort(itemComp);
            enemyList.Sort(enemyComp);
            blockPipeList.Sort(blockComp);
            itemPipeList.Sort(itemComp);
            enemyPipeList.Sort(enemyComp);

            //TESTING ONLY BELOW THIS PT
            //for (int i = 0; i < 576; i++)
            //    System.Diagnostics.Debug.WriteLine("OBJECT NAME: " + blockList[i].texture.ToString() + "    LOCATION:" + blockList[i].DrawLoc + "      OBJ #:"+i);
        }
        
        private class BlockComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T  a, T b)
            {
                IBlock b1 = (IBlock)a;
                IBlock b2 = (IBlock)b;
                if (b1.DrawLoc > b2.DrawLoc)
                    return 1;
                if (b1.DrawLoc < b2.DrawLoc)
                    return -1;
                else
                    return 0;
            }
        }
        private class ItemComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T a, T b)
            {
                IItem b1 = (IItem)a;
                IItem b2 = (IItem)b;
                if (b1.currentLoc > b2.currentLoc)
                    return 1;
                if (b1.currentLoc < b2.currentLoc)
                    return -1;
                else
                    return 0;
            }
        }
        private class EnemyComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T a, T b)
            {
                IEnemy b1 = (IEnemy)a;
                IEnemy b2 = (IEnemy)b;
                if (b1.enemyPhys.XCoor > b2.enemyPhys.XCoor)
                    return 1;
                if (b1.enemyPhys.XCoor < b2.enemyPhys.XCoor)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
