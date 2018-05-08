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
    class HeliCopter
    {
        // variabler
        #region
        Texture2D heliTexture;
        Rectangle heliRectangle;
        Tower tower;
        public float Lives;
        public float heliHealth;
        bool alive = true;
        Rectangle towerRectangle;
        Game1 game1;

        Vector2 heliMoveDir;
        Vector2 heliPosition;
        Vector2 heliScale;
        Vector2 heliOffSet;

        Color heliColor;
        Random rnd;

        int rotations;
        public float heliSpeed;
        public float heliRotation;
        #endregion 

        public HeliCopter(Texture2D texture, Vector2 startPos, float speed, Vector2 scale, Color color, float rotation, float health)// tar imot och ger ut värden
        {
            heliTexture = texture;
            Lives = 10;
            heliHealth = health;
            alive = true;
           // towerRectangle = tower.GetRectangle();
            heliPosition = startPos;
            heliMoveDir = new Vector2(1, 0);
            heliScale = scale;
            heliOffSet = (texture.Bounds.Size.ToVector2() / 2.0f) * scale;
            heliRectangle = new Rectangle((startPos - heliOffSet).ToPoint(), (texture.Bounds.Size.ToVector2() * heliScale).ToPoint());
            heliRotation = rotation;
            heliSpeed = speed;
            heliColor = Color.LightPink;
            rotations = 2;
            
        }
        public void Update(GameTime gameTime, HeliCopter heliCopter, Vector2 startPosition) // här flyttas helicoptern och ser när den kommit utanför bannan 
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.Seconds;
            rnd = new Random();

            heliPosition -= new Vector2(1, heliRotation);
            heliRectangle.Location = (heliPosition - heliOffSet).ToPoint();
            RotationCheck();
            

            if (heliRectangle.Location.X < -200 || heliRectangle.Location.Y < 0 || heliRectangle.Location.Y > 1200)
            {

                heliRotation = 0;
                heliPosition = startPosition;
                rotations = 6;

            } 
            //if (heliRectangle.Intersects(towerRectangle))
            //{
            //    Console.WriteLine("Hello");
            //    Lives--;
            //}
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont scoreFent) // ritar ut helicoptern
        {

            spriteBatch.Draw(heliTexture, heliPosition, null, heliColor, 0, heliOffSet, heliScale, SpriteEffects.None, 0);
        }

        public void ChangeHealth(float healthMod)
        {
            heliHealth += healthMod;
            if(heliHealth <= 0)
            {
                alive = false;
            }
        }

        public Rectangle GetRectangle()
        {
            return heliRectangle;
        }
        public Vector2 GetPosition()
        {
            return heliPosition;
        }

        void RotationCheck() // kollar om HeliCoptern har gått förbi en viss linje, och om det är sant så bytar den riktning
        {
            if (heliRectangle.Location.X < 600 && rotations == 6)
            {
                if (rotations == 6)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10, 10);
                    rotations--;
                }
            }
            if (heliRectangle.Location.X < 500 && rotations == 5)
            {
                if (rotations == 5)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10, 10);
                    rotations--;
                }
            }
            if (heliRectangle.Location.X < 400 && rotations == 4)
            {
                if (rotations == 4)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10, 10);
                    rotations--;
                }
            }
            if (heliRectangle.Location.X < 300 && rotations == 3)
            {
                if (rotations == 3)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10, 10);
                    rotations--;
                }
            }
            if (heliRectangle.Location.X < 200 && rotations == 2)
            {
                if (rotations == 2)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10, 10);
                    rotations--;
                }
            }
            if (heliRectangle.Location.X < 100 && rotations == 1)
            {
                if (rotations == 1)
                {
                    heliRotation = 0;
                    heliRotation = heliRotation + rnd.Next(-10,10);
                    rotations--;
                }
            }

        }
        
    }
}
