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
            Inicial, Partida, Final
        }

    static class EstadoDeJogo
    {
        public static int Pontuacao { get; set; }
        public static Fase FaseDeExecucao { get; set; }
        public static int Vidas { get; set; }

        public static void ZeraJogo()
        {
            Pontuacao = 0;
            Vidas = 3;
            FaseDeExecucao = Fase.Inicial;
        }

        public static void DrawScoreAndLife(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, String.Format("PONTOS: {0}", Pontuacao), new Vector2(12, 12), Color.White);
            StringBuilder lifeString = new StringBuilder();
            for (int i = 0; i < EstadoDeJogo.Vidas; i++)
                lifeString.Append("<3 ");
            spriteBatch.DrawString(font, lifeString.ToString(), new Vector2(700, 12), Color.Red);
        }


    }
}
