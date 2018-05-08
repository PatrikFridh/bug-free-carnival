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
    class Players
    {
        Texture2D texture;
        Rectangle playerRectangle;

        Vector2 position;
        Vector2 scale;
        Vector2 offset;

        Color color;

        float speed;
        float rotation;
        public float health;

        Players player;

        Rectangle towerRectangele;
        Rectangle heliRectangle;

        List<Bullet> bullets;

        public Players(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, Tower tower, HeliCopter heliCopter)
        {
            health = 10;
            
            texture = playerTexture;
            position = playerStartPos;
            speed = playerSpeed * 400;
            scale = playerScale;
            offset = (playerTexture.Bounds.Size.ToVector2() / 2.0f * scale);
            playerRectangle = new Rectangle((playerStartPos - offset).ToPoint(), (playerTexture.Bounds.Size.ToVector2() * playerScale).ToPoint());
            color = playerColor;
            rotation = playerRotation;
            towerRectangele = tower.GetRectangle();
            heliRectangle = heliCopter.GetRectangle();
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float pixelsToMove = speed * deltaTime;
            
            Vector2 moveDir = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                moveDir.X = 1;
            }
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                moveDir.X = -1;
            }
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                moveDir.Y = 1;
            }
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                moveDir.Y = -1;
            }
            if (moveDir != Vector2.Zero)
            {
                moveDir.Normalize();
                position += moveDir * pixelsToMove;
                playerRectangle.Location = (position - offset).ToPoint();
            }
            
            bullets = new List<Bullet>();
        }
        public void ChangeHealth(float healthModifier)
        {
            health += healthModifier;
            if (health <= 0)
            {
                player = null;
            }
        }

        public bool Collides(Rectangle aCollisionBox)
        {
            if (playerRectangle.Intersects(aCollisionBox))
            {
                Console.WriteLine("player hit");
                health--;
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);
        }

        public Rectangle GetRectangle()
        {
            return playerRectangle;
        }

        public Vector2 GetPositon()
        {
            return position;
        }
        public float GetHealth()
        {
            return health;
        }
    }
}
