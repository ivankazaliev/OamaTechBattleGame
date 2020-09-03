using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameObjects
{
    public class Player : GameObject
    {
        public Player()
        {
            this.Controls.Add(this.GetPictureBox());
            this.Width = 50;
            this.Height = 50;
        }

        public override Image GetImage()
        {
            return Graphics.Hero;
        }

        public override void UpdateObject()
        {
            if (Keyboard.IsKeyDown(Key.Left))
            {
                this.MoveLeft(this.Speed);
            }

            else if (Keyboard.IsKeyDown(Key.Right))
            {
                this.MoveRight(this.Speed);
            }

            else if (Keyboard.IsKeyDown(Key.Up))
            {
                this.MoveUp(this.Speed);
            }

            else if (Keyboard.IsKeyDown(Key.Down))
            {
                this.MoveDown(this.Speed);
            }

            else if (Keyboard.IsKeyDown(Key.Space))
            {
                GameObject bullet = new Bullet(new Point(this.Left + 25, this.Top - 25));
                this.ParentForm.Controls.Add(bullet);
            }
        }
    }
}
