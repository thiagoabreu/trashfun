#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

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

        // Variável responsável pelo background
        Background background;

        // Variáel responsáel pelo lixo
        Lixo lixo;

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
            // TODO: Add your initialization logic here

            EstadoDeJogo.ZeraJogo();

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
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;

            btnPlay = new cButton(Content.Load<Texture2D>("btn_new_game"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(300, 300));
            Texture2D texturaLixo = Content.Load<Texture2D>("box");

            lixo = new Lixo(texturaLixo, new Vector2(150, 150));

            scoreFont = Content.Load<SpriteFont>("ScoreFont");

            background = new Background(this.Content, GraphicsDevice.Viewport.Width);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            switch (EstadoDeJogo.FaseDeExecucao)
            {
            case Fase.Inicial:
                // TODO: Criar classe de tela de splash/menu
                if(btnPlay.isClicked == true)
                    EstadoDeJogo.FaseDeExecucao = Fase.Partida;
                btnPlay.Update(mouse);
                break;
            case Fase.Partida:
                lixo.Update();
                // TODO: Atualizar a posição dos lixos de acordo com o toque
                // TODO: Colocar novos lixos, se possível
                // vetorDeLixo.Update(gameTime);

                // TODO: Verificar colisoes com Lixeiros
                // lixeiros.Colisoes(vetorDeLixo);

                // TODO: Atualizar posição do Bg animado
                // background.Update(gameTime);
                break;
            case Fase.Final:
                if (mouse.LeftButton == ButtonState.Pressed)
                    EstadoDeJogo.ZeraJogo();
                break;
            default:
                break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            switch (EstadoDeJogo.FaseDeExecucao)
            {
            case Fase.Inicial:
                spriteBatch.Draw(Content.Load<Texture2D>("MainMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                btnPlay.Draw(spriteBatch);
                break;
            case Fase.Partida:
                // TODO: Desenhar Background
                // background.Draw(spriteBatch);

                // TODO: Desenhar Lixeiros
                // Lixeiros.Draw(spriteBatch);

                // TODO: Desenhar Lixos
                // VetorDeLixo.Draw(spriteBatch);
                lixo.Draw(spriteBatch);
                EstadoDeJogo.DrawScoreAndLife(spriteBatch, scoreFont);
                break;
            case Fase.Final:
                // TelaPontuacao.Draw();
                break;
            default:
                break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}