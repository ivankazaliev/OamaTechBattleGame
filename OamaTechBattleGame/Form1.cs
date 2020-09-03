using GameObjects;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Threading;

namespace OamaTechBattleGame
{
    public partial class Form1 : Form
    {
        public bool GameOver { get; set; }

        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(50)
        };

        DispatcherTimer enemyTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };

        public Form1()
        {
            InitializeComponent();
            GameObject p = new Player();
            p.Speed = 30;
            p.Location = new Point(this.Height, this.Width / 2);
            this.Controls.Add(p);
            init();
        }

        public void init()
        {
            //GameOver = false;
            timer.Tick += GameLoop;
            timer.Start();

            enemyTimer.Tick += SpawnEnemy;
            enemyTimer.Start();

        }

        public void SpawnEnemy(object sender, EventArgs e)
        {
            Random rand = new Random();
            int placement = (int)(this.Width * rand.NextDouble());
            if (placement < 50)
            {
                placement = 50;
            }
            else if (placement > this.Width - 50)
            {
                placement = this.Width - 50;
            }

            GameObject eo = new Enemy(new Point(placement, 0));
            this.Controls.Add(eo);
        }

        public void GameLoop(object sender, EventArgs e)
        {
            if (GameOver) return;

            foreach (GameObject c in this.Controls)
            {
                c.UpdateObject();
                if (c is Enemy)
                {
                    if (GameOver) return;

                    foreach (GameObject b in this.Controls)
                    {
                        if (b is Bullet)
                        {
                            if (c.Bounds.IntersectsWith(b.Bounds))
                            {
                                this.Controls.Remove(b);
                                this.Controls.Remove(c);

                            }
                        }
                        else if (b is Player)
                        {
                            if (c.Bounds.IntersectsWith(b.Bounds))
                            {
                                timer.Stop();
                                enemyTimer.Stop();
                                GameOver = true;
                                MessageBox.Show("GAME OVER");
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}