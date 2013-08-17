using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Player
    {
        //Player animation
        public Texture2D PlayerTexture;
        //Player position
        public Vector2 Position;
        //Player State
        public bool Active;
        //Player health
        public int Health;
        //player width
        public int Width
        {
            get { return PlayerTexture.Width; }
        }
        //Player Height
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            //sets the texture of player
            PlayerTexture = texture;
            //Sets starting position
            Position = position;
            //set player state True
            Active = true;
            //set player health
            Health = 100;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

        }
    }
}
