#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Collections;

#endregion

namespace TrashFun
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Screen Adjustments
        int screenWidth = 800, screenHeight = 600;
        cButton btnPlay;

        SpriteFont scoreFont;

        Texture2D heart;

        // Variável responsável pelo background
        Background background;

        // Variáel responsáel pelo lixo
        Texture2D texLixo;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Matenha isso como True para poder ver o cursor do mouse
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            EstadoDeJogo.ZeraJogo();

            Sujeira.Limpa();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new cButton(Content.Load<Texture2D>("btn_new_game"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(300, 300));

            texLixo = Content.Load<Texture2D>("box");

            heart = Content.Load<Texture2D>("heart");
            scoreFont = Content.Load<SpriteFont>("ScoreFont");

            background = new Background(this.Content, GraphicsDevice.Viewport.Width);

            TexturaLixeiros.LoadTextures(Content);
            LoadLixeiros();
        }

        List<Lixeiro> lixeiros;

        protected void LoadLixeiros()
        {
            int quantidade = 5;

            this.lixeiros = new List<Lixeiro>(quantidade);

            int horizontal = screenWidth / quantidade;
            int offset = horizontal / 2 - 40;

            Vector2[] posicoes = new Vector2[quantidade];  

            for(int i = 0; i < quantidade; i++)
                posicoes[i] = new Vector2(offset + (i * horizontal), 100);

            lixeiros.Add(new Lixeiro(posicoes[0], TipoDeLixo.Metal));
            lixeiros.Add(new Lixeiro(posicoes[1], TipoDeLixo.Organico));
            lixeiros.Add(new Lixeiro(posicoes[2], TipoDeLixo.Papel));
            lixeiros.Add(new Lixeiro(posicoes[3], TipoDeLixo.Plastico));
            lixeiros.Add(new Lixeiro(posicoes[4], TipoDeLixo.Vidro));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            TexturaLixeiros.UnloadTextures();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            switch(EstadoDeJogo.FaseDeExecucao)
            {
            case Fase.Inicial:
                if(btnPlay.isClicked == true)
                {
                    EstadoDeJogo.FaseDeExecucao = Fase.Partida;
                    Sujeira.CriaLixo();
                }
                btnPlay.Update(mouse);
                break;
            case Fase.Partida:
                // TODO: Atualizar a posição dos lixos de acordo com o toque

                Sujeira.Update();

                Sujeira.CriaLixo(gameTime);

                VerificaPontuacao();

                background.Update(gameTime);

                if(EstadoDeJogo.Vidas == 0)
                    EstadoDeJogo.FaseDeExecucao = Fase.Final;
                break;
            case Fase.Final:
                btnPlay.isClicked = false;
                if(mouse.LeftButton == ButtonState.Pressed)
                    EstadoDeJogo.ZeraJogo();
                break;
            default:
                break;
            }

            base.Update(gameTime);
        }

        protected void VerificaPontuacao() {
            if(Sujeira.ativo != null)
            {
                bool pontua;
                if(Sujeira.ativo.VerificaColisoes(lixeiros, out pontua))
                {
                    if(pontua)
                        EstadoDeJogo.Pontuacao += 10;
                    else
                        EstadoDeJogo.Vidas--;

                    Sujeira.lixosNoChao.Remove(Sujeira.ativo);
                    Sujeira.ativo = null;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            switch(EstadoDeJogo.FaseDeExecucao)
            {
            case Fase.Inicial:
                spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                btnPlay.Draw(spriteBatch);
                break;
            case Fase.Partida:
                background.Draw(spriteBatch);

                // TODO: Desenhar Lixeiros
                // Lixeiros.Draw(spriteBatch);

                foreach(var item in lixeiros)
                {
                    item.Draw(spriteBatch);
                }

                Sujeira.DrawLixoNoChao(spriteBatch);

                // TODO: Desenhar Lixos
                // VetorDeLixo.Draw(spriteBatch);

                EstadoDeJogo.DrawScoreAndLife(spriteBatch, scoreFont, heart);
                break;
            case Fase.Final:
                // TelaPontuacao.Draw();
                Sujeira.Limpa();
                break;
            default:
                break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}