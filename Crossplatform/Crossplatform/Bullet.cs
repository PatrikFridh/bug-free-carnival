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
    class Bullet
    {
        public enum Owner { Player};
        Owner owner;
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        Vector2 moveDir;
        Vector2 scale;
        Vector2 offset;
        Color color;
        float speed;
        float damage;
        float rotation;
        bool alive;

        public Bullet(Texture2D bulletTexture, Vector2 bulletStartPos, Vector2 bulletDir, float bulletSpeed, Vector2 bulletScale, Owner bulletOwner, Color bulletColor)
        {
            texture = bulletTexture;
            position = bulletStartPos;
            speed = bulletSpeed;
        }
    }
}
