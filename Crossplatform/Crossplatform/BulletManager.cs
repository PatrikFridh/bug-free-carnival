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
    static class BulletManager
    {
        static List<Bullets> bullets = new List<Bullets>();

        public static void AddBullet(Texture2D texture, Vector2 startPosition, Vector2 dir, float speed, Vector2 scale, Bullets.Owner owner, Color color)
        {
            bullets.Add(new Bullets(texture, startPosition, dir, speed, scale, owner, color));
        }

        public static void Update(float deltaTime, Player player)
        {
            for (int i = bullets.Count; i >= 0; --i)
            {
                if(bullets[i].GetIsAlive())
                {
                    bullets[i].Update(deltaTime);
                    Bullets.Owner owner = bullets[i].GetOwner();
                    float damage = 0;
                    switch (owner)
                    {
                        case Bullets.Owner.Player:
                            for (int j = 0; j < enemies.Count; ++j)
                            {
                                damage = bullets[i].Damage(enemies[j].GetRectange());
                                enemies[j].ChangeHealth(-damage);
                            }
                            break;
                        case Bullets.Owner.Enemy:
                            damage = bullets[i].Damage(player.GetRectangle());
                            player.ChangeHealth(-damage);
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
