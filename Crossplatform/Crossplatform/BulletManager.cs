﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crossplatform
{
    class BulletManager
    {
        static List<Bullet> bullets = new List<Bullet>();

        public static void AddBullet(Texture2D texture, Vector2 startPosition, Vector2 dir, float speed, Vector2 scale, Bullet.Owner owner, Color color)
        {
            bullets.Add(new Bullet(texture, startPosition, dir, speed, scale, owner, color));
        }

        public static void Update(float deltaTime, Players player, List<HeliCopter> heliCopters)
        {
            for (int i = bullets.Count - 1; i >= 0; --i)
            {
                if (bullets[i].GetIsAlive())
                {
                    bullets[i].Update(deltaTime);
                    Bullet.Owner owner = bullets[i].GetOwner();
                    float damage = 0;
                    switch (owner)
                    {
                        case Bullet.Owner.Player:
                            for (int j = 0; j < heliCopters.Count; ++j)
                            {
                                damage = bullets[i].Damage(heliCopters[j].GetRectangle());
                                heliCopters[j].ChangeHealth(-damage);
                            }
                            break;
                    }
                }
                else
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bullets.Count; ++i)
            {
                bullets[i].Draw(spriteBatch);
            }

        }
    }
}
