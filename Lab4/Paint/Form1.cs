using System;


using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace Lab4
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            IntPtr screen = GetDC(IntPtr.Zero);
            g_decstop = Graphics.FromHdc(screen);
        }
        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        private Graphics g_decstop = null;

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    DrawTriangle();
                    break;
                case 1:
                    DrawSquare();
                    break;
                case 2:
                    DrawPentagon();
                    break;
            }
        }
        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        //public static extern void ReleaseDC(IntPtr dc);
        static Brush b = Brushes.Aqua;
        void DrawTriangle()
        {
            //ClassLibrary1.Class1 qqqq= new ClassLibrary1.Class1();
            
            using (Graphics g = Graphics.FromHdc(GetDC(IntPtr.Zero)))
            {
                PointF[] pnts = new PointF[3];
                pnts[0] = new PointF(100, 400);
                pnts[1] = new PointF(500, 400);
                pnts[2] = new PointF(300, 100);


                g.FillPolygon(b,pnts);
            }
        }
        void DrawSquare()
        {
            using (Graphics g = Graphics.FromHdc(GetDC(IntPtr.Zero)))
            {
                g.FillRectangle(b, 100, 100, 400, 400);
            }
        }
        void DrawPentagon()
        {
            using (Graphics g = Graphics.FromHdc(GetDC(IntPtr.Zero)))
            {
                PointF[] pnts = new PointF[5];
                pnts[0] = new PointF(300, 100);
                pnts[1] = new PointF(500, 300);
                pnts[2] = new PointF(400, 500);
                pnts[3] = new PointF(200, 500);
                pnts[4] = new PointF(100, 300);


                g.FillPolygon(b, pnts);
            }
        }
        private void paint_simple()
        {
            Pen p = new Pen(CurrentColor);
            g_decstop.DrawLine(p, PrevPoint, CurrentPoint);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                paint_simple();
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
                CurrentColor = colorDialog1.Color;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Point k = new Point();
            k.X = 400;
            k.Y = 400;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = ":)| *.*";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                g_decstop.DrawImage(Image.FromFile(open.FileName),k);
            }
        }
       
        
        private void Button5_Click(object sender, EventArgs e)
        {

            
            //if (obj.method()) MessageBox.Show("Library!");
        }
    }
}
