using System.Drawing;
using System.Windows.Forms;

namespace GameObjects
{
    public partial class GameObject : UserControl
    {
        public int Speed { get; set; }

        public GameObject()
        {
            InitializeComponent();
        }

        public GameObject(int speed)
        {
            this.Speed = speed;
            InitializeComponent();
        }

        // The child classes will implement GetImage to return
        // the correct image to use for the specific object.
        public PictureBox GetPictureBox()
        {
            return new PictureBox()
            {
                Image = this.GetImage(),
                Size = new System.Drawing.Size(this.Width, this.Height),
            };
        }

        public virtual Image GetImage() { return null; }
        public virtual void UpdateObject() { }

        public void MoveLeft(int speed)
        {
            this.Left -= speed;
        }

        public void MoveRight(int speed)
        {
            this.Left += speed;
        }

        public void MoveDown(int speed)
        {
            this.Top += speed;
        }

        public void MoveUp(int speed)
        {
            this.Top -= speed;
        }
    }
}