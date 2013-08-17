using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Animation
    {
        //Image representing the collection of images
        Texture2D spriteStrip;
        //Scale used to display the sprite strip
        float scale;
        //time since last update frame
        int elapsedTime;
        //time we display a frame until next one
        int frameTime;
        //number of frames that an animation contains.
        int frameCount;
        //index of the current frae we are displaying
        int currentFrame;
        //the color of the frame we will be displaying
        Color color;
        //the area of the image strip we want to display
        Rectangle sourceRect = new Rectangle();
        //the area where we want to display the image strip in the game
        Rectangle destinationRect = new Rectangle();
        //width of given frame
        public int FrameWidth;
        //height of given frame
        public int FrameHeight;
        //state of animation
        public bool Active;
        //determines if the animation will keep playing or deactivate after one run
        public bool Looping;

        //position of frame
        public Vector2 Position;

        public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frametime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;

            Looping = looping;
            Position = position;
            spriteStrip = texture;

            //set time to 0
            elapsedTime = 0;
            currentFrame = 0;

            //Set animation to active by default
            Active = true;
        }
        public void Update(GameTime gameTime)
        {
            //do not update game if not active
            if (Active == false)
                return;
            //Update the elapsed time
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            //if the elapsed time is lager than the frame time we need to switch frames
            if (elapsedTime > frameTime)
            {
                //move to the next frame
                currentFrame++;

                //if the currentframe is equal to frameCount reset crurrentFrame to zero
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    //if we are not looping deactivate the animation
                    if (Looping == false)
                        Active = false;
                }

                //reset elapsed time to zero
                elapsedTime = 0;
            }

            //Grab the correct fram in the image strip by multiplying the current frame index by the frame width
            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            //destination
            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2,
                (int)Position.Y - (int)(FrameHeight * scale) / 2,
                (int)(FrameWidth * scale), (int)(FrameHeight * scale));
        
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }

        }

    }
}
