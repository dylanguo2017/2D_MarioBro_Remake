using Game.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MarioStateClass marioState;

        public Camera camera;
        public CameraObjectDetector camObj;
        public ItemSpawn itemSpawn;
        public IMario mario;
        
        private ArrayList contrl;
        
        public Texture2D oneCloudBgElement;
        public Texture2D threeCloudsBgElement;
        public Texture2D oneBushBgElement;
        public Texture2D threeBushesBgElement;
        public Texture2D smallMountainBgElement;
        public Texture2D bigMountainBgElement;

        public Texture2D smallCastle;
        public Texture2D flagpoleElement;

        public Texture2D goombaEnemy;
        public Texture2D koopaEnemy;

        public Texture2D marioSprites;
        public Texture2D fireballSprite;
        public Texture2D titleScreen;

        public Texture2D blockSprite;
        public Texture2D blueBlockSprite;
        public Texture2D itemSprite;

        public List<IBlock> blockList;
        public List<IBlock> questionBlockList;
        public List<IEnemy> enemyList;
        public List<IItem> itemList;
        public List<IBackground> bgList;

        public List<IBlock> blockCamList;
        public List<IBlock> questionBlockCamList;
        public List<IEnemy> enemyCamList;
        public List<IItem> itemCamList;
        public List<IBackground> bgCamList;

        public IController keyboard;
        public IController gmPad;

        public bool pause;
        public Pause paused;
        public HUD hud;

        private int animationModifier;
        public int animMod
        {
            get
            {
                return animationModifier;
            }
        }
        private int starDuration;
        
        public List<Fireball> fireBalls;
        public int fbDelay;
        public int countOfPopItem;

        public enum sides { left, right, top, bottom, none };

        private ICollisionDetector marioColDetector;
        private ICollisionDetector enemyColDetector;
        private ICollisionDetector itemColDetector;
        private ICollisionDetector projColDet;

        public SoundEffects soundEffect;
        public Sounds sound;

        public enum soundStates { mainTheme, starman, hurry, gameOver, pause, stop, reset };

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            soundEffect = new SoundEffects(this);
            sound = new Sounds(this);
            contrl = new ArrayList();
            camera = new Camera(this);
            camObj = new CameraObjectDetector(this);
            itemSpawn = new ItemSpawn(this);

            marioColDetector = new MarioCollisionDetector(this);
            enemyColDetector = new EnemyCollisionDetector(this);
            itemColDetector = new ItemCollisionDetector(this);
            
            keyboard = new KeyboardController();
            gmPad = new GamepadController();
            KeyBind keyB = new KeyBind(this);
            keyB.BindKey();
            contrl.Add(keyboard);
            contrl.Add(gmPad);
            paused = new Pause(this);

            hud = new HUD(this);

            marioState = new MarioStateClass(false, false, false, false);
            fireBalls = new List<Fireball>();
            fbDelay = 0;

            countOfPopItem = 0;
            projColDet = new ProjectileCollisionDetector(this, fireBalls);

            animationModifier = 0;
            starDuration = 500;

            base.Initialize();
        }


        protected override void LoadContent()
        {   

            spriteBatch = new SpriteBatch(GraphicsDevice);

            itemSprite = Content.Load<Texture2D>("SpriteSheets/Items");
            blockSprite = Content.Load<Texture2D>("SpriteSheets/Tileset");
            blueBlockSprite = Content.Load<Texture2D>("blueBricks");


            oneCloudBgElement = Content.Load<Texture2D>("1CloudBgElement");
            threeCloudsBgElement = Content.Load<Texture2D>("3CloudsBgElement");
            oneBushBgElement = Content.Load<Texture2D>("1BushElement");
            threeBushesBgElement = Content.Load<Texture2D>("3BushesBgElement");
            smallMountainBgElement = Content.Load<Texture2D>("SmallMountainBgElement");
            bigMountainBgElement = Content.Load<Texture2D>("BigMountainBgElement");

            smallCastle = Content.Load<Texture2D>("smallCastle");
            flagpoleElement = Content.Load<Texture2D>("flagPole");

            goombaEnemy = Content.Load<Texture2D>("goomba");
            koopaEnemy = Content.Load<Texture2D>("koopa");

            titleScreen = this.Content.Load<Texture2D>("titleScreen");
            marioSprites = this.Content.Load<Texture2D>("SpriteSheets/Mario");
            fireballSprite = Content.Load<Texture2D>("fireball");

            mario = new SmallMario(this);

            Level.LoadLists(this);
            enemyList = Level.enemyList;
            blockList = Level.blockList;
            itemList = Level.itemList;
            camObj.LoadLevel();
            
            bgList = Level.bgList;
            foreach(IBlock block in blockList)
            {
                if(block is Question)
                {
                    
                    countOfPopItem++;
                }
                
                
            }
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
        

        protected override void Update(GameTime gameTime)
        {
            hud.Update();
            paused.Update();
            if (pause)
            {
                return;
            }
            if(fbDelay > 0)
            {
                fbDelay--;
            }

            marioColDetector.Update();
            projColDet.Update();

            if (marioState.star)
            {
                starDuration--;
                if(starDuration < 0)
                {
                    sound.state = soundStates.mainTheme;
                    starDuration = 500;
                    if (marioState.curStat.Equals(MarioStateClass.marioStatus.small))
                    {
                        mario = new SmallMario(this);
                    }
                    else if (marioState.curStat.Equals(MarioStateClass.marioStatus.large))
                    {
                        mario = new LargeMario(this);
                    }
                    else
                    {
                        mario = new FireMario(this);
                    }
                }
            }

            itemSpawn.Update();
            animationModifier++;
            foreach (IController x in contrl)
            {
                if (x.isConnected())
                {
                    marioState.move = false;
                    x.Update();
                }
            }

            mario.Update();
            camObj.Update();
            if (fireBalls.Count != 0)
            {
                foreach (Fireball fBalls in fireBalls)
                {
                    fBalls.Update();
                }
            }
            foreach (IEnemy enemy in enemyCamList)
            {
                enemy.Update();
                enemyColDetector.Update();
            }

            if (animationModifier % 20 == 0)
            {
                foreach (IBackground background in bgList)
                {
                    background.Update();
                }
                foreach (IBlock block in blockCamList)
                {
                    block.Update();
                }
                //  foreach (IBlock block in questionBlockList)
                // {
                //   block.Update();
                //  }

                foreach (IItem item in itemCamList)
                {
                    item.Update();
                    itemColDetector.Update();
                }

            }
            sound.Update();
            
            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            hud.Draw(spriteBatch);
            paused.Draw(spriteBatch);
            itemSpawn.Draw(spriteBatch);
            foreach (IBackground background in bgList)
            {
                background.Draw(spriteBatch);
            }
            foreach (IBlock block in blockCamList)
            {
                block.Draw(spriteBatch);
            }

            foreach (IEnemy enemy in enemyCamList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IItem item in itemCamList)
            {
                item.Draw(spriteBatch);
            }
            foreach(IBlock block in blockCamList)
            {
                if (block is Question)
                {
                    if (block.hit.Equals(true))
                    {
                        
                    }
                    
                }
          }

            if (fireBalls.Count != 0)
            {
                foreach (Fireball fBalls in fireBalls)
                {
                    fBalls.Draw(spriteBatch);
                }
            }
            mario.Draw(spriteBatch);

            base.Draw(gameTime);
        }

    }
}
