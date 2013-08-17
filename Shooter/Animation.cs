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

        public void Initialize()
        {
        }
        public void Update()
        {
        }
        public void Draw()
        {
        }

    }
}
