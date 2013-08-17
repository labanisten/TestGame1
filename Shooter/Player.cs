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
        public Animation PlayerAnimation;
        //Player position
        public Vector2 Position;
        //Player State
        public bool Active;
        //Player health
        public int Health;
        //player width
        public int Width
        {
            get { return PlayerAnimation.FrameWidth; }
        }
        //Player Height
        public int Height
        {
            get { return PlayerAnimation.FrameHeight; }
        }

        public void Initialize(Animation animation, Vector2 position)
        {
            PlayerAnimation = animation;
                        
            //Sets starting position
            Position = position;
            //set player state True
            Active = true;
            //set player health
            Health = 100;
        }
        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);

        }
    }
}
