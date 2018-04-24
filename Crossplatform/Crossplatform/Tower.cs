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
    class Tower
    {
        // variabler
        #region
        Texture2D texture;
        Rectangle rectangle;

        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offSet;

        Color towerColor;
        Random rnd;

        float towerSpeed;
        float towerRotation;
        #endregion
        public Tower(Texture2D towerTexture,  Vector2 startPos, float speed,  Vector2 towerScale, Color color, float rotation) // tar emot och delar ut värden
        {
            texture = towerTexture;
            position = startPos;
            moveDir = new Vector2(-1, 0);
            scale = towerScale * 0.9f;
            offSet = (towerTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            rectangle = new Rectangle((startPos - offSet).ToPoint(), (towerTexture.Bounds.Size.ToVector2() * scale).ToPoint());
            towerRotation = 0;
            towerSpeed = speed;
            towerColor = color;
        }
        public void Update(GameTime gametime, Tower tower, Vector2 startPosition) // flyttar och ser om tornet är utanför mappen
        {
            float deltaTime = (float)gametime.ElapsedGameTime.Seconds;
            rnd = new Random();

            position = position - new Vector2(10,0);
            rectangle.Location = (position - offSet).ToPoint();

            if (rectangle.Location.X < -300)
            {
                position = startPosition + new Vector2(0, rnd.Next(-100, 0));
            }
        }
        public void Draw(SpriteBatch spriteBatch)// ritar ut tornet
        {
            spriteBatch.Draw(texture, position, null, towerColor, towerRotation, offSet, scale, SpriteEffects.None, 0);

        }
        public Rectangle GetRectangle()
        {
            return rectangle;
        }
        public Vector2 Getposition()
        {
            return position;
        }
    }
    
}
