using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crossplatform
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random;
        static float score;
        float scoreTimer;
        static float HP;
        Players player;
        Texture2D towerTexture;
        Texture2D heliTexture;
        Texture2D fallingTexture;
        Texture2D playerTexture;
        Vector2 towerStartPosition;
        Vector2 heliStartPosition;
        Vector2 fallingStartPosition;
        float playerHealth;
        float softCap;
        Tower tower;
        HeliCopter heliCopter;

        int numHeliCopters;
        List<HeliCopter> heliCopters;

        SpriteFont scoreFont;
        
        
     
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            random = new Random();
            numHeliCopters = 2;
            softCap = 1;
            HP = 10;
            score = 2;
            heliCopters = new List<HeliCopter>();
            scoreTimer = 0;
            towerStartPosition = new Vector2(Window.ClientBounds.Right, 450);
            heliStartPosition = new Vector2(800,600);
            fallingStartPosition = new Vector2( random.Next(10, 750), 0);
           // playerHealth = player.GetHealth();
            base.Initialize();
 
            

            tower = new Tower(towerTexture, new Vector2(800, 200), 1, new Vector2(0.3f,0.3f), Color.White, 1);
            heliCopter = new HeliCopter(heliTexture, heliStartPosition,1,new Vector2(1,1), Color.White, random.Next(-10,10), 100);
            player = new Players(playerTexture, new Vector2(200, -100), 1, new Vector2(1, 1), 0, Color.White, tower, heliCopter);

            IsMouseVisible = true;

            tower = new Tower(towerTexture, towerStartPosition, 1, new Vector2(1,1), Color.White, 1);
            heliCopter = new HeliCopter(heliTexture, heliStartPosition,random.Next(5,20),new Vector2(0.5f,0.5f), Color.White, random.Next(-10,10), 100);
            player = new Players(playerTexture, new Vector2(500, -50), 1, new Vector2(0.5f, 0.5f), 0, Color.White, tower, heliCopter);

            for (int i = 0; i < numHeliCopters; i++)
            {
                heliStartPosition = new Vector2(800, random.Next(0, 400));
                heliCopter.heliRotation = random.Next(-10, 10);

                heliCopters.Add(new HeliCopter(heliTexture, heliStartPosition, 1, new Vector2(0.5f,0.5f), Color.White, 1, 100));
                heliCopters.Add(new HeliCopter(heliTexture, heliStartPosition, 300, new Vector2(0.5f,0.5f), Color.White, 0, 100));
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            TextureLibrary.LoadTexture(Content, "ball");
            towerTexture = Content.Load<Texture2D>("Tower");
            heliTexture = Content.Load<Texture2D>("HeliCopter");
            fallingTexture = Content.Load<Texture2D>("FallingObject");
            scoreFont = Content.Load<SpriteFont>("File");
            playerTexture = Content.Load<Texture2D>("BigBird");
            //playerTexture = Content.Load<Texture2D>("HeliCopter");


            //playerTexture = Content.Load<Texture2D>("Tower");

            //playerTexture = Content.Load<Texture2D>("HeliCopter");

            //playerTexture = Content.Load<Texture2D>("Tower");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyBoardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
            // TODO: Add your update logic here
            float deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            scoreTimer += deltatime;
            player.Update(gameTime, keyBoardState, mouseState, Window.ClientBounds.Size);
            tower.Update(gameTime, tower, towerStartPosition);
            heliCopter.Update(gameTime, heliCopter, new Vector2(800, 200));

            if(softCap < 2)
            {
                softCap += deltatime;
                //Console.WriteLine("Full");
            }
            if (softCap >= 2)
            {
                player.Collides(tower.GetRectangle());
                //player.Collides(heliCopter.GetRectangle());
                softCap = 0;
                //Console.WriteLine("Recharging");
            }
            




            BulletManager.Update(deltatime, player, heliCopters);
            BulletManager.Update(deltatime, player, heliCopters);

            if (scoreTimer >= 0.5f)
            {
                score += 1;
                scoreTimer = 0f;
            }

            for (int i = 0; i < heliCopters.Count;i++)
            {
                heliCopters[i].Update(gameTime, heliCopter, new Vector2(800, random.Next(100,300)));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            tower.Draw(spriteBatch);
            player.Draw(spriteBatch);
            for (int i = 0; i < heliCopters.Count; i++)
            {
                heliCopters[i].Draw(spriteBatch, scoreFont);
            }
            BulletManager.Draw(spriteBatch);
            spriteBatch.DrawString(scoreFont, "Score: " + score.ToString(), new Vector2(50, 30), Color.Red);
            spriteBatch.DrawString(scoreFont, "Lives: " + player.health.ToString(), new Vector2(600, 30), Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }

}
