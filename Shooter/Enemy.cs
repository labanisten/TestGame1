using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Enemy
    {
        //Sets animation for Enemy
        public Animation EnemyAnimation;

        //Sets position for enemy
        public Vector2 Position;

        //Set state of enemy
        public bool Active;

        //Sets the health of the enemy
        public int Health;

        //Sets the damage enemy does
        public int Damage;

        //Sets the Value of killing enemy
        public int Value;

        //get width of enemy
        public int Width
        {
            get { return EnemyAnimation.FrameWidth; }
        }
        //Get Height of enemy
        public int Height
        {
            get { return EnemyAnimation.FrameHeight; }
        }

        //Set the speed which enemy moves
        float enemyMoveSpeed;

        public void Initialize(Animation animation, Vector2 position)
        {
            //Load enemy ship texture
            EnemyAnimation = animation;

            //load enemy position
            Position = position;

            //State of enemy
            Active = true;

            //Health of enemy
            Health = 10;

            //Damage of enemy
            Damage = 10;

            //Speed of enemy
            enemyMoveSpeed = 6f;

            //Value of enemy kill
            Value = 100;
            
        }
        public void Update(GameTime gameTime)
        {
            //The enemy always moves to the left so decrement it's position
            Position.X -= enemyMoveSpeed;

            //Update the enemy animatoin
            EnemyAnimation.Position = Position;

            //update enemy animatoin
            EnemyAnimation.Update(gameTime);

            //if the enemy is past the screen or its health reaches 0 then deactive it.
            if (Position.X < -Width || Health <= 0)
            {
                //By setting Active false, the game will remove this object form the active game list.
                Active = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //draw enemy animation.
            EnemyAnimation.Draw(spriteBatch);
        }


    }
}
