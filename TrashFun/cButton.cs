﻿using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TrashFun
{
    public class cButton
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public cButton(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            //ScreenW = 800, ScreenH = 600
            //ImgW = 100, ImgH = 20
            size = new Vector2(graphics.Viewport.Width / 4, graphics.Viewport.Height / 10);
        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);
            Rectangle mouseRetangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if(mouseRetangle.Intersects(rectangle))
            {
                if(colour.A == 255)
                    down = false;
                if(colour.A == 0)
                    down = true;
                if(down)
                    colour.A += 3;
                else
                    colour.A -= 3;
                if(mouse.LeftButton == ButtonState.Pressed)
                    isClicked = true;
            } else if(colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }

        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }

    }
}

