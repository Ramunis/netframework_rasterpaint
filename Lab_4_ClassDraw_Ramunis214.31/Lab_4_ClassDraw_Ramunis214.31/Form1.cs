using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab_4_ClassDraw_Ramunis214._31
{
    public partial class Form1 : Form
    {
        public Graphics dra;
        public Bitmap buf;
        public int n=2; // 
        public int isDown = 0;
        public int oX, oY;
        public int mX, mY;
        public int tX, tY;
        public double deg = 0;
        public int t,tm,th = 0; //
        public int ft,pt = 0;
        Form2 inputbox = new Form2(); //
        List<Point> points = new List<Point>(); //
        List<Point> points1 = new List<Point>(); // 
        List<Point> points2 = new List<Point>(); //
        List<Point> points3 = new List<Point>(); //
        public static int count = 0;  //  
        public int coun = 0;  //
        public int count1 = 0;  //
        public int count2 = 0;  //
        Point[] pa1 = new Point[count]; //
        Point[] pa2 = new Point[count]; //
        Point[] pa3 = new Point[count]; //
       
        public Form1()
        {
            InitializeComponent();
            // buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            dra = this.CreateGraphics(); ;//Graphics.FromImage(buf); 
        }

        //  void GetRGB(int width, int height, int x, int y)
        // {
        //Bitmap bmp = new Bitmap(width, height);
        //string pixel = bmp.GetPixel(x, y).R.ToString()+ bmp.GetPixel(0, 0).G.ToString() +bmp.GetPixel(0, 0).B.ToString() + bmp.GetPixel(0, 0).A.ToString();      
        //toolStripStatusLabel3.Text = pixel;
        // }
        
        public void DrawSin(int cX,int cY, int stage, Color col)
        {
            double WW, HH, AA, St;         
            if (oX < cX) { mX = oX; } else { mX = cX; };
            if (oY < cY) { mY = oY; } else { mY = cY; };
            WW = Math.Abs(oX - cX);
            HH = Math.Abs(oY - cY);
            AA = HH / 8.0;
            St = (2.0 * Math.PI) / WW;
            int WW2 = Convert.ToInt32(2 * WW);
            Point[] MP = new Point[WW2];
            int j = 0;
            for (double i = 0.0; i < 2.0 * Math.PI; i += St)
            {
                MP[j].X = mX + j;
                MP[j].Y = (mY + Convert.ToInt32((stage * HH)/8)) - Convert.ToInt32((AA * Math.Sin(i +deg)));
                MP[WW2 - 1 - j].X = mX + j;
                MP[WW2 - 1 - j].Y = (mY + Convert.ToInt32((6 * HH) / 8)) - Convert.ToInt32((AA * Math.Sin(i+deg)) - AA);
                j++;
            }
            dra.FillPolygon(new SolidBrush(col), MP);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isDown = 1;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (n == 0) isDown = 1;
                if (n == 1) isDown = 3;
                if (n == 2) isDown = 2;
                if (n == 3) isDown = 4;
                if (n == 4) isDown = 5;
                if (n == 5) isDown = 6;
                if (n == 6) isDown = 7;
                if (n == 7) isDown = 8;
                if (n == 8) isDown = 9;
                if (n == 9) isDown = 11;
                if (n == 10) isDown = 13;
                if (n == 11) isDown = 14;
                if (n == 12) isDown = 15;
                if (n == 13) isDown = 16;
            }
            if (Control.ModifierKeys == Keys.Control)
            {
                isDown = 10;
            }
            if (Control.ModifierKeys == Keys.Alt)
            {
                isDown = 12;
            }
            if (isDown == 13)
            {
                points.Add(new Point(e.X, e.Y));
                coun++;
            }
            if (isDown == 14)
            {                
                points1.Add(new Point(e.X, e.Y));
                count++;
            }
            if (isDown == 15)
            {
                points2.Add(new Point(e.X, e.Y));
                count1++;
            }
            if (isDown == 16)
            {
                points3.Add(new Point(e.X, e.Y));
                count2++;
            }
            oX = e.X;
            oY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown == 4)
            {
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(colorDialog1.Color);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                dra.DrawString(inputbox.text, fontDialog1.Font, drawBrush, e.X, e.Y, drawFormat);             
            }

            if (isDown == 3)
            {
                //Pen p = new Pen(new SolidBrush(Color.FromArgb(12, 32, 98)), 3);
                Pen p = new Pen(new SolidBrush(colorDialog1.Color), trackBar1.Value);

                if (pt ==0) p.DashStyle = DashStyle.Solid;
                if (pt ==1) p.DashStyle = DashStyle.Dash;
                if (pt ==2) p.DashStyle = DashStyle.DashDot;
                if (pt ==3) p.DashStyle = DashStyle.DashDotDot;
                if (pt == 4) p.DashStyle = DashStyle.Dot;

                dra.DrawLine(p, oX, oY, e.X, e.Y);
                oX = e.X;
                oY = e.Y;
            }
           
            if (isDown == 2)
            {                                          
                dra.FillEllipse(new SolidBrush(colorDialog1.Color), e.X, e.Y, trackBar1.Value, trackBar1.Value);
                oX = e.X;
                oY = e.Y;
            }
                 
            if (isDown == 1)
            {
                Pen p = new Pen(new SolidBrush(Color.Black), 1);
                dra.FillEllipse(new SolidBrush(Form1.DefaultBackColor), oX - 16, oY - 16, 32, 32);
                dra.FillEllipse(new SolidBrush(Color.LightGreen), e.X - 15, e.Y - 15, 30, 30);
                dra.DrawEllipse(p, e.X - 15, e.Y - 15, 30, 30);
                oX = e.X;
                oY = e.Y;
            }
          
            toolStripStatusLabel1.Text = Convert.ToString(trackBar1.Value)+" px";
            toolStripStatusLabel2.Text = "Coords: "+Convert.ToString(e.X) + "," + Convert.ToString(e.X);          
            //GetRGB(1508, 905, e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDown == 16)
            {
                toolStripStatusLabel4.Text = "Построено: " + Convert.ToString(count2) + " Точек";
                try
                {
                    pa3 = points3.ToArray();
                    dra.FillEllipse(new SolidBrush(Color.Red), pa3[count2 - 1].X, pa3[count2 - 1].Y, 5, 5);
                    dra.DrawClosedCurve(new Pen(colorDialog1.Color, trackBar1.Value), pa3);
                }
                catch
                {
                    Console.WriteLine("Полигон строиться по 2 точкам");
                }
            }

            if (isDown == 15)
            {
                toolStripStatusLabel4.Text = "Построено: " + Convert.ToString(count1) + " Точек";
                try
                {
                    pa2 = points2.ToArray();
                    dra.FillEllipse(new SolidBrush(Color.Red), pa2[count1 - 1].X, pa2[count1 - 1].Y, 5, 5);
                    dra.DrawLines(new Pen(colorDialog1.Color, trackBar1.Value), pa2);
                }
                catch
                {
                    Console.WriteLine("Линия строиться по 2 точкам");
                }
            }

            if (isDown == 14)
            {
                toolStripStatusLabel4.Text = "Построено: "+Convert.ToString(count)+" Точек";
                try
                {
                    pa1 = points1.ToArray();
                    dra.FillEllipse(new SolidBrush(Color.Red), pa1[count - 1].X, pa1[count - 1].Y, 5, 5);
                    dra.DrawBeziers(new Pen(colorDialog1.Color, trackBar1.Value), pa1);
                    //dra.DrawCurve(new Pen(colorDialog1.Color, trackBar1.Value), pa1);                    
                }
                catch
                {
                    Console.WriteLine("Кривая строиться по 4 точкам");
                }
            }

            if (isDown == 13)
            {                
                toolStripStatusLabel4.Text = "Построено: " + Convert.ToString(coun) + " Точек";
                Point[] pa = points.ToArray();
                dra.FillEllipse(new SolidBrush(Color.Red), pa[coun - 1].X, pa[coun - 1].Y, 5, 5);
                dra.FillPolygon(new SolidBrush(colorDialog1.Color), pa);               
            }

            if (isDown == 12)
            {
                tX = e.X;
                tY = e.Y;
                DrawSin(tX, tY, 1, Color.White);
                DrawSin(tX, tY, 3, Color.Red);
                DrawSin(tX, tY, 5, Color.Blue);
            }
           
            if (isDown == 11)
            {
                tX = e.X;
                tY = e.Y;
                DrawSin(tX, tY, 1, colorDialog1.Color);              
            }

            if (isDown == 10)
            {
                int SS = Math.Abs(oY - e.Y) / 3;
                dra.FillRectangle(new SolidBrush(Color.White), oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
                dra.FillRectangle(new SolidBrush(Color.Blue), oX, oY+SS, Math.Abs(oX - e.X), Math.Abs(oY - e.Y)-SS);
                dra.FillRectangle(new SolidBrush(Color.Red), oX, oY+SS+SS, Math.Abs(oX - e.X), Math.Abs(oY - e.Y)-SS-SS);
            }

            if (isDown == 9)
            {
                dra.DrawEllipse(new Pen(colorDialog1.Color, trackBar1.Value), oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
            }

            if (isDown == 8)
            {
                dra.DrawRectangle(new Pen(colorDialog1.Color, trackBar1.Value), oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
            }

            if (isDown == 7)
            {
                Pen punkt = new Pen(colorDialog1.Color, trackBar1.Value);
                if (pt == 0)
                {
                    dra.DrawLine(new Pen(colorDialog1.Color, trackBar1.Value), oX, oY, e.X, e.Y);
                }
                if (pt == 1)
                {
                    punkt.DashStyle = DashStyle.Dash;
                    dra.DrawLine(punkt, oX, oY, e.X, e.Y);
                }
                if (pt == 2)
                {
                    punkt.DashStyle = DashStyle.DashDot;
                    dra.DrawLine(punkt, oX, oY, e.X, e.Y);
                }
                if (pt == 3)
                {
                    punkt.DashStyle = DashStyle.DashDotDot;
                    dra.DrawLine(punkt, oX, oY, e.X, e.Y);
                }
                if (pt == 4)
                {
                    punkt.DashStyle = DashStyle.Dot;
                    dra.DrawLine(punkt, oX, oY, e.X, e.Y);
                }
            }

            if (isDown == 6)
            {
                if (ft ==0) dra.FillEllipse(new System.Drawing.SolidBrush(colorDialog1.Color), oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
                if (ft == 1)
                {
                    LinearGradientBrush lgBrush_1 = new LinearGradientBrush(new RectangleF(oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y)), colorDialog1.Color, Color.Yellow, LinearGradientMode.Horizontal);
                    dra.FillEllipse(lgBrush_1, oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
                }
            }

            if (isDown == 5)
            {
                if (ft ==0) dra.FillRectangle(new System.Drawing.SolidBrush(colorDialog1.Color), oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
                if (ft == 1)
                {
                    LinearGradientBrush lgBrush_1 = new LinearGradientBrush(new RectangleF(oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y)), colorDialog1.Color, Color.Yellow, LinearGradientMode.Horizontal);
                    dra.FillRectangle(lgBrush_1, oX, oY, Math.Abs(oX - e.X), Math.Abs(oY - e.Y));
                }
                
            }

            if (isDown == 1)
            {
                dra.FillEllipse(new SolidBrush(Form1.DefaultBackColor), e.X - 16, e.Y - 16, 32, 32);
            }
            isDown = 0;         
        }       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 1; // Pen
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            trackBar1.Minimum = 10;
            trackBar1.Maximum = 50;
            trackBar1.Value = 10;
            n = 2; // Brush         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = 0; // Erase
        }

        private void button4_Click(object sender, EventArgs e)
        {
           inputbox.Show();
           n = 3; // Text;
           button4.Enabled = false;        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            n = 4;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            n = 5;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 6;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 7;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 8;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            n = 10;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;               
            n = 11;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 12;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 15;
            trackBar1.Value = 1;
            n = 13;          
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            openFileDialog1.ShowDialog();
            dra.Clear(Color.White);
            dra.DrawImage(new Bitmap(openFileDialog1.FileName),135,24);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dra.Clear(Color.White);
        }

        private void standartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ft = 0;
        }

        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ft = 1;
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt = 0;
        }

        private void dashDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt = 2;
        }

        private void dashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt = 3;
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt = 4;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактор Растровой Графики  1.0\n\n\nРазработал студент МГУ Невельского кафедры ФЭИТ гр 214.31 Рамунис С.Ю.", "Information");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            n = 9;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            t += 1;
            if (t == 60)
            {
                tm += 1;
                t = 0;
            }
            if (tm == 60)
            {
                th += 1;
                t = 0;
            }
            toolStripStatusLabel3.Text = "Прошло: "+Convert.ToString(th)+":" + Convert.ToString(tm) + ":" + Convert.ToString(t);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer1.Interval = 250;
            if (button13.Text == "Стоп")
            {
                button13.Text = "Старт";
                timer1.Stop();
            }
            else
            {
                button13.Text = "Стоп";
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {         
            deg += 0.3;
            this.Refresh();
            if (trackBar1.Value == 2)
            {
                DrawSin(tX, tY, 1, Color.White);
                DrawSin(tX, tY, 3, Color.Red);
                DrawSin(tX, tY, 5, Color.Blue);
            }
            else
            {
                DrawSin(tX, tY, 1, colorDialog1.Color);
            }         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();         
        }
    }
}
