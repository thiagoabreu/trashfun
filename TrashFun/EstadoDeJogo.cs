using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrashFun
{
    enum Fase
    {
        Inicial,
        Partida,
        Final
    }

    static class EstadoDeJogo
    {
        public static int Pontuacao { get; private set; }

        public static int Bonus { get; private set; }

        public static Fase FaseDeExecucao { get; set; }

        public static int Vidas { get; set; }

        public static void ZeraJogo()
        {
            Pontuacao = 0;
            Vidas = 3;
            Bonus = 2;
            FaseDeExecucao = Fase.Inicial;
        }

        public static void Pontua()
        {
            Pontuacao += 5 * Bonus;
            Bonus = 2;
        }

        public static void GanhaBonus()
        {
            Bonus *= 2;
        }

        public static void DrawScoreAndLife(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, String.Format("PONTOS: {0}", Pontuacao), new Vector2(14, 14), Color.Black);
            spriteBatch.DrawString(font, String.Format("PONTOS: {0}", Pontuacao), new Vector2(12, 12), Color.White);
            StringBuilder lifeString = new StringBuilder();
            for(int i = 0; i < EstadoDeJogo.Vidas; i++)
                lifeString.Append("S2 ");
            spriteBatch.DrawString(font, lifeString.ToString(), new Vector2(700, 12), Color.Red);
        }

        public static void DrawScoreAndLife(SpriteBatch spriteBatch, SpriteFont font, Texture2D coracao)
        {
            spriteBatch.DrawString(font, String.Format("PONTOS: {0}", Pontuacao), new Vector2(14, 14), Color.Black);
            spriteBatch.DrawString(font, String.Format("PONTOS: {0}", Pontuacao), new Vector2(12, 12), Color.White);
            Rectangle core = new Rectangle();
            core.Height = 20;
            core.Width = 20;
            core.Y = 12;
            for(int i = 0; i < EstadoDeJogo.Vidas; i++)
            {
                core.X = 700 + (i * 30);
                spriteBatch.Draw(coracao, core, Color.White);             
            }
        }
            
    }
}
