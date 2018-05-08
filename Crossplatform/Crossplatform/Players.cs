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
<<<<<<< HEAD
        public float health;

        Players player;
=======
        float health;
        bool alive = true;
        float attackSpeed;
        float attackTimer;
        
>>>>>>> 4ca9ff370f80833ca166f1586af32a447c59f765

        Rectangle towerRectangele;
        Rectangle heliRectangle;

        List<Bullet> bullets;

<<<<<<< HEAD
        public Players(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, Tower tower, HeliCopter heliCopter)
=======
        public Players(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, float playerHealth, float playerAttackSpeed)
>>>>>>> 4ca9ff370f80833ca166f1586af32a447c59f765
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
<<<<<<< HEAD
            towerRectangele = tower.GetRectangle();
            heliRectangle = heliCopter.GetRectangle();
=======
            health = playerHealth;
            alive = true;
            attackSpeed = playerAttackSpeed;
            attackTimer = 0;
>>>>>>> 4ca9ff370f80833ca166f1586af32a447c59f765
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState, Point windowSize)
        {
<<<<<<< HEAD
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float pixelsToMove = speed * deltaTime;
            
            Vector2 moveDir = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
=======
            if(alive)
>>>>>>> 4ca9ff370f80833ca166f1586af32a447c59f765
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                float pixelsToMove = speed * deltaTime;
                //position -= new Vector2(1, 0);
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
                    //rectangle.Location += (moveDir * speed * deltaTime).ToPoint();
                    position += moveDir * pixelsToMove;
                    rectangle.Location += (position - offset).ToPoint();
                }

                attackTimer += deltaTime;
                if(attackTimer <= attackSpeed)
                {
                    attackTimer += deltaTime;
                }

                if(mouseState.LeftButton == ButtonState.Pressed && attackTimer >= attackSpeed)
                {
                    Vector2 bulletDir = mouseState.Position.ToVector2() - position;
                    BulletManager.AddBullet(TextureLibrary.GetTexture("ball"), position, bulletDir, 800, new Vector2(0.2f, 0.2f),Bullet.Owner.Player, color);
                    attackTimer = 0;
                }
            }
            else
            {
<<<<<<< HEAD
                moveDir.Normalize();
                position += moveDir * pixelsToMove;
                playerRectangle.Location = (position - offset).ToPoint();
=======
                color = Color.Black;
>>>>>>> 4ca9ff370f80833ca166f1586af32a447c59f765
            }
            
            bullets = new List<Bullet>();
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

        public void ChangeHealth(float healthModifier)
        {
            health += healthModifier;
            if (health <= 0)
            {
                alive = false;
            }
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
