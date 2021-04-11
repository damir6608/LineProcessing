using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormEllipseDialog : Form
    {
        Ellipse ellipse;
        public bool Enabled { get; set; }
        public FormEllipseDialog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x, y, w, h;
            float penSize;
            Color color;
            try
            {
                x = Int32.Parse(textBox4.Text);
                y = Int32.Parse(textBox3.Text);
                w = Int32.Parse(textBox1.Text);
                h = Int32.Parse(textBox2.Text);
                color = Init.pen.Color;
                penSize = Init.pen.Width;
                if (((x >= 0) && (x <= Init.picturebox.Width)) && (y >= 0 && (y <= Init.picturebox.Height)) && (w > 0 && (w <= Init.picturebox.Width)) && (h > 0 && (h <= Init.picturebox.Height)) && (x + w <= Init.picturebox.Width) && (y + h <= Init.picturebox.Height))
                {
                    Init.ellipsesNumber++;
                    this.ellipse = new Ellipse(x, y, w, h, penSize, color);
                    ellipse.DrawFigure();
                    ShapeContainer.AddFigure(this.ellipse);
                    Close();

                }
                else
                {
                    MessageBox.Show("Ложные параметры", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
                {
                    MessageBox.Show("Все поля должны быть заполнены", "Оповщениее", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Исправьте данные или введите недостающие", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormEllipseDialog_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormEllipseDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.createForEllips = null;
        }

       
    }
}
