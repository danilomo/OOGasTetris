#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

#endregion

namespace OOGasTetris
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		//Random rand = new Random();
		private Texture2D bujaum;
		private TetrisBoard board;
		private Texture2D borderVertical;
		private Texture2D borderHorizontal;
		private KeyboardState oldState;
		private SoundEffect effect;


		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			setSize(20 * 25, 27 * 25);

		}


		protected override void Initialize ()
		{
			base.Initialize ();
			this.IsMouseVisible = true;
			oldState = Keyboard.GetState();
		}


		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			bujaum = Content.Load<Texture2D>(@"bujaum");
			borderVertical = Content.Load<Texture2D>(@"bordervertical");
			borderHorizontal = Content.Load<Texture2D>(@"borderhorizontal");
			this.effect = Content.Load<SoundEffect> ("oogas");

			board = new TetrisBoard (bujaum);
			board.setBorderVertical (borderVertical);
			board.setBorderHorizontal (borderHorizontal);
			board.newTetromino ();
			board.setEffect (effect);

			effect.Play ();
		}
			
		protected override void Update (GameTime gameTime)
		{	
			KeyboardState newState = Keyboard.GetState();

			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit ();
			}

			base.Update (gameTime);

			board.updateTime ((float) gameTime.ElapsedGameTime.TotalSeconds);
			board.handleInput (newState, oldState);

			oldState = newState;
		}


			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.White);
			spriteBatch.Begin();

			board.drawBoard ( spriteBatch );

			spriteBatch.End();
            
			base.Draw (gameTime);
		}

		private void setSize( int w, int h ){
			graphics.PreferredBackBufferWidth = w;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = h;   // set this value to the desired height of your window
			graphics.ApplyChanges();
		}
	}
}

