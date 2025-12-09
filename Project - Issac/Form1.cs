using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project___Issac
{
    public partial class Form1 : Form
    {
        class Issac // Main Hero
        {
            public int X;
            public int Y;
            public List<Bitmap> image = new List<Bitmap>();
            public int animationIndex;
        }
        class Tear // Bullets
        {
            public int X;
            public int Y;
            public Bitmap image;
        }
        List<Issac> hero = new List<Issac>();
        List<Tear> bullet = new List<Tear>();
        bool BulletShot = false;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            Graphics g = this.CreateGraphics();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(this.BackColor);
            for (int i = 0; i < hero.Count; i++)
            {
                if (bullet[0].X == this.Width)
                {

                }
                // Shooting in one direction (Test)
                if (e.KeyCode == Keys.Right)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        bullet[0].X += 10;
                    }
                    BulletShot = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        bullet[0].X -= 10;
                    }
                    BulletShot = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        bullet[0].Y -= 10;
                    }
                    BulletShot = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        bullet[0].Y += 10;
                    }
                    BulletShot = true;
                }
                // Hero Movement.
                if (e.KeyCode == Keys.A)
                {
                    hero[i].X -= 10;
                }
                if (e.KeyCode == Keys.D)
                {
                    hero[i].X += 10;
                }
                if (e.KeyCode == Keys.S)
                {
                    hero[i].Y += 10;
                }
                if (e.KeyCode == Keys.W)
                {
                    hero[i].Y -= 10;
                }
                DrawIssac(g);
                if (BulletShot == true)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        DrawTear(g);
                    }

                }
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawIssac(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadIssac();
            LoadTear();
        }

        public void LoadIssac()
        {
            Issac issac = new Issac();
            issac.X = this.Width / 2 - 150;
            issac.Y = this.Height / 2;
            for (int j = 1; j <= 4; j++)
            {
                Bitmap bmp = new Bitmap("w" + j + ".bmp");
                bmp.MakeTransparent(bmp.GetPixel(0, 0));
                issac.image.Add(bmp);
            }
            hero.Add(issac);
        }
        public void LoadTear()
        {
            Tear tear = new Tear();
            tear.X = hero[0].X + 10;
            tear.Y = hero[0].Y - 10;
            for (int i = 1; i <= 1; i++)
            {
                Bitmap bmp = new Bitmap("ball2.bmp");
                bmp.MakeTransparent(bmp.GetPixel(0, 0));
                tear.image = bmp;
            }
            bullet.Add(tear);
        }
        public void DrawIssac(Graphics g)
        {
            g = this.CreateGraphics();
            for (int i = 0; i < hero.Count; i++)
            {
                hero[i].animationIndex = (hero[i].animationIndex + 1) % 4;
                int j = hero[i].animationIndex;
                g.DrawImage(hero[i].image[j], hero[i].X, hero[i].Y);
            }
        }
        public void DrawTear(Graphics g)
        {
            g = this.CreateGraphics();
            for (int i = 0; i < bullet.Count; i++)
            {
                g.DrawImage(bullet[i].image, bullet[0].X, bullet[0].Y);
            }
        }
    }
}

