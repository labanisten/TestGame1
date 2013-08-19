using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Shooter
{
	class ParallaxingBackground
	{

        //image representing the parallaxing background
        Texture2D texture;

        // An array of positions of the parallaxing bacground
        Vector2[] positions;

        //speed which the background is moving
        int speed;

        public void Initialize(ContentManager content, String texturePath, int screenWidth, int speed)
        {

            //load the backgound texture
            texture = content.Load<Texture2D>(texturePath);

            //Set the speed of the background
            this.speed = speed;

            // If we divide the screen with the texture width then we can determine the number of tiles need.
            // We add 1 to it so that we won't have a gap in the tiling
            positions = new Vector2[screenWidth / texture.Width + 1];

            //set the initial positions of the parralaxing background
            for (int i = 0; i < positions.Length; i++)
            {
                //we need the tiles to be side by side to create a tiling effect
                positions[i] = new Vector2(i * texture.Width, 0);
            }
        }
        public void Update()
        {
            //update the positions of the background
            //Når de under skriver at når den går til høyre og til venstre, men at .x += speed så kan då speed være -5 slik bilde då går til venstre.
            //Metoden her er bygget for å kunne gå både til høyre og venstre, alt etter hva du spesifiserer i classe initialiseringen.
            for (int i = 0; i < positions.Length; i++)
            {
                //update the position of the screen by adding the speed
                positions[i].X += speed;
                //if the speed has the bacground moving to the left
                if (speed <= 0)
                {
                    //check the texture is out of view then put that texture at the end of the screen
                    if (positions[i].X <= -texture.Width)
                    {
                        positions[i].X = texture.Width * (positions.Length - 1);
                    }
                }

                //if the speed has the bacground moving to the right
                else
                {
                    // check if the texture is out of view then position it to the start of the screen
                    if (positions[i].X >= texture.Width * (positions.Length - 1))
                    {
                        positions[i].X = -texture.Width;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                spriteBatch.Draw(texture, positions[i], Color.White);
            }
        }


	}
}
