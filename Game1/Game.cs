using Game.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        GameTime gameTime;
        
        SpriteBatch spriteBatch;

        SpriteFont Font1;
        Vector2 FontPos;

        public MarioStateClass marioState;

        public Camera camera;
        public CameraObjectDetector camObj;
        public ItemSpawn itemSpawn;
        public IMario mario;
        
        public ArrayList contrl;
        
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

        public List<IBlock> blockPipeList;
        public List<IEnemy> enemyPipeList;
        public List<IItem> itemPipeList;

        public List<IBlock> blockCamList;
        public List<IBlock> questionBlockCamList;
        public List<IEnemy> enemyCamList;
        public List<IItem> itemCamList;
        public List<IBackground> bgCamList;

        public IController keyboard;
        public IController gmPad;

        public bool pause;
        public bool pipeLevel;
        public Pause paused;
        public HUD hud;
        public LevelControl lvCtrl;
        
        private int animationModifier;
        public int animMod
        {
            get
            {
                return animationModifier;
            }
        }
        public int starDuration;
        
        public List<Fireball> fireBalls;
        public int fbDelay;
        public int countOfPopItem;

        public ICollisionDetector marioColDetector;
        public ICollisionDetector enemyColDetector;
        public ICollisionDetector itemColDetector;
        public ICollisionDetector projColDet;

        public SoundEffects soundEffect;
        public Sounds sound;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            hud = new HUD(this);

            gameTime = new GameTime();
            soundEffect = new SoundEffects(this);
            sound = new Sounds(this);
            contrl = new ArrayList();
            camera = new Camera(this);
            camObj = new CameraObjectDetector(this);
            itemSpawn = new ItemSpawn(this);
            lvCtrl = new LevelControl(this);

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

            
            Font1 = Content.Load<SpriteFont>("Courier New");

                     
            FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);

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

            titleScreen = Content.Load<Texture2D>("titleScreen");
            marioSprites = Content.Load<Texture2D>("SpriteSheets/Mario");
            fireballSprite = Content.Load<Texture2D>("fireball");

            mario = new SmallMario(this);

            Level.LoadLists(this);
            enemyList = Level.enemyList;
            blockList = Level.blockList;
            itemList = Level.itemList;
            enemyPipeList = Level.enemyPipeList;
            blockPipeList = Level.blockPipeList;
            itemPipeList = Level.itemPipeList;
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
            
            hud.Update(gameTime);
            
            animationModifier++;

            lvCtrl.Update();

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            
            lvCtrl.Draw(spriteBatch);
            hud.Draw(spriteBatch);
            paused.Draw(spriteBatch);

            foreach (IBlock block in blockCamList)
            {
                if (block is Question)
                {
                    if (block.hit.Equals(true))
                    {
                        
                    }
                    
                }
            }

            base.Draw(gameTime);
        }

    }
}
