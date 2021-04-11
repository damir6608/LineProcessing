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
    public partial class FormCircleDialog : Form
    {
        Circle circle;
        public FormCircleDialog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x, y, w;
            float penSize;
            Color color;
            try
            {
                x = Int32.Parse(textBox4.Text);
                y = Int32.Parse(textBox3.Text);
                w = Int32.Parse(textBox1.Text);
                color = Init.pen.Color;
                penSize = Init.pen.Width;
                if (((x >= 0) && (x <= Init.picturebox.Width)) && (y >= 0 && (y <= Init.picturebox.Height)) && (w > 0 && (w <= Init.picturebox.Width)) && (x + w <= Init.picturebox.Width) && (y + w <= Init.picturebox.Height))
                {
                    Init.circlesNumber++;
                    this.circle = new Circle(x, y, w, penSize, color);
                    circle.DrawFigure();
                    ShapeContainer.AddFigure(this.circle);
                    Close();
                }
                else
                {
                    MessageBox.Show("Невозможно создать окружность с заданными параметрами", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                if ((textBox1.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля для создания окружности", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Данных, введенных вами для создания окружности, не хватает, или они оказались некорректны. Пожалуйста, исправьте их", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormCircleDialog_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormCircleDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.createForCircle = null;
        }
    }
}
