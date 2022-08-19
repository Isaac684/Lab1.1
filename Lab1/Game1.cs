using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D sprite;//pacman
        Texture2D fondo;//laberinto
        Texture2D pared;//pared
        int spriteX = 0;//pos personaje principal
        int spriteY = 0;
        int moveY=0;//incremento de coordenadas
        int moveX=0;
        int norects;//cantidad de paredes del laberinto
        Rectangle[] rects;//arreglo maneja las coordenadas de las paredes del labe
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 1024;//ancho pantalla
            this._graphics.PreferredBackBufferHeight = 768;//alto
            crearrectangulos();
        }
        void crearrectangulos()
        {
            norects = 55;
            rects = new Rectangle[norects];
            rects[0] = new Rectangle();
            rects[0] = new Rectangle(160, 22, 10, 207);
            rects[1] = new Rectangle(217, 74, 78, 42);
            rects[2] = new Rectangle(346, 74, 102, 42);
            rects[3] = new Rectangle(575, 74, 102, 42);
            rects[4] = new Rectangle(729, 74, 78, 42);
            rects[5] = new Rectangle(213, 163, 78, 21);
            rects[6] = new Rectangle(422, 166, 174, 21);
            rects[7] = new Rectangle(725, 166, 78, 21);
            rects[8] = new Rectangle(160, 12, 687, 15); //linea superior
            rects[9] = new Rectangle(850, 15, 15, 207);
            rects[10] = new Rectangle(493, 15, 30, 93);//
            rects[11] = new Rectangle(160, 228, 140, 11);//bordes entrada
            rects[12] = new Rectangle(345, 225, 102, 21);
            rects[13] = new Rectangle(572, 225, 102, 21);
            rects[14] = new Rectangle(725, 225, 139, 12);
            rects[15] = new Rectangle(160, 455, 12, 249);//bordes entrada
            rects[16] = new Rectangle(851, 455, 12, 249);
            rects[17] = new Rectangle(340, 160, 30, 147);
            rects[18] = new Rectangle(645, 160, 30, 147);
            rects[19] = new Rectangle(492, 166, 30, 84);//borde de cruz 1 
            rects[20] = new Rectangle(646, 366, 30, 86);
            rects[21] = new Rectangle(345, 366, 30, 86);
            rects[22] = new Rectangle(160, 695, 687, 12);
            rects[23] = new Rectangle(420, 425, 174, 25);
            rects[24] = new Rectangle(220, 495, 74, 25);
            rects[25] = new Rectangle(723, 495, 78, 25);
            rects[26] = new Rectangle(160, 305, 130, 12);
            rects[27] = new Rectangle(725, 305, 140, 12);
            rects[28] = new Rectangle(160, 360, 140, 12);
            rects[29] = new Rectangle(725, 360, 140, 12);
            rects[30] = new Rectangle(160, 437, 135, 12);
            //rects[31] = new Rectangle(725, 437, 140, 12);
            rects[32] = new Rectangle(285, 360, 12, 84);
            rects[33] = new Rectangle(725, 360, 12, 84);
            rects[34] = new Rectangle(285, 233, 12, 84);//
            rects[35] = new Rectangle(725, 233, 12, 84);
            rects[36] = new Rectangle(345, 499, 102, 14);
            rects[37] = new Rectangle(573, 499, 102, 14);
            rects[38] = new Rectangle(580, 632, 227, 14);
            rects[39] = new Rectangle(220, 632, 227, 14);
            rects[40] = new Rectangle(420, 565, 177, 14);
            rects[41] = new Rectangle(170, 566, 48, 14);
            rects[42] = new Rectangle(802, 566, 48, 14);
            rects[43] = new Rectangle(265, 495, 30, 87);
            rects[44] = new Rectangle(725, 495, 30, 87);
            rects[45] = new Rectangle(494, 426, 30, 87);
            rects[46] = new Rectangle(493, 565, 30, 87);
            rects[47] = new Rectangle(345, 563, 30, 87);
            rects[48] = new Rectangle(649, 563, 30, 87);
            rects[49] = new Rectangle(417, 300, 9, 80);
            rects[50] = new Rectangle(591, 300, 9, 80);
            rects[51] = new Rectangle(419, 371, 170, 9);
            rects[52] = new Rectangle(418, 296, 66, 9);
            rects[53] = new Rectangle(533, 296, 66, 9);
            rects[54] = new Rectangle(465, 296, 66, 9);//Esta es la puerta

        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite = Content.Load<Texture2D>("pacman01");
            fondo = Content.Load<Texture2D>("nivel01");
            pared = Content.Load<Texture2D>("rect");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState currentState= Keyboard.GetState();
            
            Keys[] currenkey= currentState.GetPressedKeys();


            if (gameTime.TotalGameTime.Milliseconds % 20 == 0)
            {
                // codigo que se ejecuta cada 20ms
                moveX = sprite.Width;
                moveY = sprite.Height;
            }
            else
            {
                moveY = 0;
                moveX = 0;
            }

            if (gameTime.TotalGameTime.Milliseconds % 45 == 0)
            {
                sprite = Content.Load<Texture2D>("pacman01");
            }
            if (gameTime.TotalGameTime.Milliseconds % 70 == 0)
            {
                sprite = Content.Load<Texture2D>("pacman02");
            }

            foreach (Keys key in currenkey)
            {
                if(key==Keys.Up)
                {
                    moveY = -5;
                    moveX = 0;
                    if(checkbounds())
          
                        spriteY = spriteY + moveY;
                    
                   
                }
                if (key == Keys.Down)
                {
                    moveY = 5;
                    moveX = 0;
                    if (checkbounds())
                        spriteY = spriteY + moveY;
                }
                if (key == Keys.Left)
                {
                    moveY = 0;
                    moveX = -5;
                    if (checkbounds())
                        spriteX = spriteX + moveX;
                }
                if (key == Keys.Right)
                {
                    moveY = 0;
                    moveX = 5;
                    if (checkbounds())
                        spriteX = spriteX + moveX;
                }
                if(key == Keys.Escape)
                {
                    this.Exit();
                }
            }
            if(spriteX<0)
                spriteX=0;
            if(spriteY<0)
                spriteY=0;
            if(spriteX + moveX>_graphics.GraphicsDevice.Viewport.Width)
            {
                spriteX = _graphics.GraphicsDevice.Viewport.Width-moveX;
            }
            if (spriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)
            {
                spriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }
            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(fondo, new Rectangle(0, 0, fondo.Width, fondo.Height), Color.White);
            _spriteBatch.Draw(sprite, new Rectangle(spriteX, spriteY, sprite.Width, sprite.Height), Color.White);
            for (int i=0;i<norects;i++)
            {
                _spriteBatch.Draw(pared, rects[i], Color.White);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        //METODO PERMITE 
        bool checkbounds()
        {
            Rectangle temprect = new Rectangle(spriteX + moveX, spriteY + moveY, sprite.Width, sprite.Height);
            bool temreturn = true;
            for (int i = 0; i < norects; i++)
            {
                if (temprect.Intersects(rects[i]))
                {
                    temreturn = false;
                }

            }
            return temreturn;
        }
    }
}
