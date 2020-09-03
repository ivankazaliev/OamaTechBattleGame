using System.Drawing;

namespace GameObjects
{
    public class Bullet : GameObject
    {
        public Bullet(Point location)
        {
            // Adds the graphics to the bullet UserControl
            this.Controls.Add(this.GetPictureBox());

            // Sets how far the bullet will travel each 
            // iteration of the game loop
            this.Speed = 50;

            // Sets the size of the image representing the object.
            // This should match the actual size of the images 
            // you have created for the game.
            this.Width = 5;
            this.Height = 10;

            // Sets the starting location of the bullet
            this.Location = location;
        }

        // Returns the Bullet image when we call GetImage 
        // on an object of type GameObject
        public override Image GetImage()
        {
            return Graphics.Bullet;
        }

        // Moves the bullet up, and removes the bullet 
        // if it has moved out of the visible area.
        public override void UpdateObject()
        {
            this.MoveUp(this.Speed);
            if (this.Top < 0)
            {
                this.ParentForm.Controls.Remove(this);
            }
        }
    }
}