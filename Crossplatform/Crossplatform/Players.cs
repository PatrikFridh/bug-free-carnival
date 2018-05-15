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
        Random rnd;
        Players player;

        bool alive = true;
        float attackSpeed;
        float attackTimer;
        

        Rectangle towerRectangele;
        Rectangle heliRectangle;

        List<Bullet> bullets;

        //public Players(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, Tower tower, HeliCopter heliCopter)
        public Players(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, float playerHealth, float playerAttackSpeed, Tower tower, HeliCopter heliCopter)
        {
            health = 10;
            rnd = new Random();
            texture = playerTexture;
            position = playerStartPos;
            speed = playerSpeed;
            scale = playerScale;
            offset = (playerTexture.Bounds.Size.ToVector2() / 2.0f * scale);
            playerRectangle = new Rectangle((playerStartPos - offset).ToPoint(), (playerTexture.Bounds.Size.ToVector2() * playerScale).ToPoint());
            color = playerColor;
            rotation = playerRotation;
           // towerRectangele = tower.GetRectangle();
            heliRectangle = heliCopter.GetRectangle();
            health = playerHealth;
            alive = true;
            attackSpeed = playerAttackSpeed;
            attackTimer = 0;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState, Point windowSize, HeliCopter heliCopter)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float pixelsToMove = speed * deltaTime;
            Vector2 moveDir = Vector2.Zero;
<<<<<<< HEAD
            DamageTaken(heliRectangle);
            if (playerRectangle.Intersects(heliCopter.GetRectangle()))
            {
                Console.WriteLine("heli hit");
            }
=======

>>>>>>> 12d560986d55b10fcbd7cad18327d11eae484eb1
            if(alive)
            {
                
                if(position.X >= 0)
                {
                    
                    if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
                    {
                        moveDir.X = -1;
                    }
                }
                if (position.Y >= 0)
                {
                    
                    if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
                    {
                        moveDir.Y = -1;
                    }
                }
                if (position.X <= 800)
                {
                    if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
                    {
                        moveDir.X = 1;
                    }
                    
                }
                if(position.Y <= 470)
                {
                    if(keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
                    {
                        moveDir.Y = 1;
                    }
                }






                
                
                
                
                
                if (moveDir != Vector2.Zero)
                {
                    moveDir.Normalize();
                    //playerRectangle.Location += (moveDir * speed * deltaTime).ToPoint();
                    position += moveDir * pixelsToMove;
                    playerRectangle.Location += (position - offset).ToPoint();
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
                moveDir.Normalize();
                position += moveDir * pixelsToMove;
                playerRectangle.Location = (position - offset).ToPoint();
                color = Color.Black;
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
        public void DamageTaken(Rectangle damagingRectangle)
        {
            if (playerRectangle.Intersects(damagingRectangle))
            {
                Console.WriteLine("h<selij zdrv");
            }
        }
    }
}
