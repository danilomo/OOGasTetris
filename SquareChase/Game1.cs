#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace SquareChase
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Random rand = new Random();
		Texture2D squareTexture;
		Rectangle currentSquare;
		int playerScore = 0;
		float timeRemaining = 0.0f;
		const float TimePerSquare = 1.50f;
		Color[] colors = new Color[3] {Color.Red, Color.Green, Color.Blue};

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;		
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();
			this.IsMouseVisible = true;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
			squareTexture = Content.Load<Texture2D>("square");
			//TODO: use this.Content to load your game content here 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit ();
			}
			// TODO: Add your update logic here			
			base.Update (gameTime);

			if (timeRemaining == 0.0f)
			{
				currentSquare = new Rectangle(
					rand.Next(0, Window.ClientBounds.Width - 25),
					rand.Next(0, Window.ClientBounds.Height - 25),
					25, 25);
				timeRemaining = TimePerSquare;
			}
			MouseState mouse = Mouse.GetState();
			if ((mouse.LeftButton == ButtonState.Pressed)
			    && (currentSquare.Contains(mouse.X, mouse.Y)))
			{
				++playerScore;
				timeRemaining = 0.0f;
			}
			timeRemaining = MathHelper.Max(0, timeRemaining - (float)gameTime.ElapsedGameTime.TotalSeconds);
			Window.Title = "Score : " + playerScore.ToString();
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			spriteBatch.Begin();
			spriteBatch.Draw(squareTexture, currentSquare, colors[playerScore % 3]);
			spriteBatch.End();
			//TODO: Add your drawing code here
            
			base.Draw (gameTime);
		}
	}
}

