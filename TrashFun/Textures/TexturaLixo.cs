using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TrashFun
{
    public static class TexturaLixo
    {
        public static Texture2D Metal;
        public static Texture2D Papel;

        public static void LoadTextures(ContentManager content){
            Metal = content.Load<Texture2D>("Textures\\lata_2");
            Papel = content.Load<Texture2D>("Textures\\papel_1");
        }
    }
}

