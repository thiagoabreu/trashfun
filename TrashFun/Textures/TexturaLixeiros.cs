using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TrashFun
{
    public static class TexturaLixeiros
    {
        public static Texture2D MetalBin;
        public static Texture2D GlassBin;
        public static Texture2D NotRecycleBin;
        public static Texture2D PaperBin;
        public static Texture2D PlasticBin;

        public static void LoadTextures(ContentManager content) {
            MetalBin = content.Load<Texture2D>("Textures\\metal_trash");
            GlassBin = content.Load<Texture2D>("Textures\\glass_trash");
            NotRecycleBin = content.Load<Texture2D>("Textures\\not-recycle");
            PaperBin = content.Load<Texture2D>("Textures\\papel_trash");
            PlasticBin = content.Load<Texture2D>("Textures\\plastic_trash");
        }

        public static void UnloadTextures() {
            MetalBin.Dispose();
            GlassBin.Dispose();
            NotRecycleBin.Dispose();
            PaperBin.Dispose();
            PlasticBin.Dispose();
        }
    }
}

