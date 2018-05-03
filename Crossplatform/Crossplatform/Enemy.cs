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
    class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color color;
        float speed;
        float rotation;

        public Enemy(Texture2D enemyTexture, Vector2 enemyStartPos, float enemySpeed, Vector2 enemyScale, float enemyRotation, Color enemyColor)
        {
            texture = enemyTexture;
            position = enemyStartPos;
            speed = enemySpeed;
            moveDir = Vector2.Zero;
            scale = enemyScale;
            offset = (enemyTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            rectangle = new Rectangle((enemyStartPos - offset).ToPoint(), (enemyTexture.Bounds.Size.ToVector2() * enemyScale).ToPoint());
            color = enemyColor;
            rotation = enemyRotation;

        }
        public void Update(GameTime gameTime, Player player)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float pixelToMove = speed * deltaTime;
            moveDir.X = 1;
            moveDir.Normalize();
            position += moveDir * pixelToMove;
            rectangle.Location = (position - offset).ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public class Game1 : Game
        {
            GraphicsDeviceManager grapfics;
            SpriteBatch spriteBatch;
            Player player;
            Enemy enemy;
            Texture2D ballTexture;
            
       
            protected override void Initialize()
            {
                base.Initialize();
                player = new Player();
                enemy = new Enemy(ballTexture, new Vector2(100, 50), 300, new Vector2(1, 1), 0, Color.Blue);
            }
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                ballTexture = Content.Load<Texture2D>("ball");
            }

            protected override void Update(GameTime gameTime)
            {
                enemy.Update(gameTime, player);
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                enemy.Draw(spriteBatch);
                spriteBatch.End();  
                base.Draw(gameTime);
            }
        }
    }
}

