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
    public partial class FormRectangleDialog : Form
    {
       
        Rectangle rectangle;
        
        public FormRectangleDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
                    Init.rectanglesNumber++;
                    this.rectangle = new Rectangle(x, y, w, h, penSize, color);
                    rectangle.DrawFigure();
                    ShapeContainer.AddFigure(this.rectangle);
                    
                    Close();
                }
                else
                {
                    MessageBox.Show("Невозможно создать прямоугольник с заданными параметрами", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == "") && (textBox4.Text == ""))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля для создания прямоугольника", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Данных, введенных вами для создания прямоугольника, не хватает, или они оказались некорректны. Пожалуйста, исправьте их", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


               
        }

        private void FormRectangleDialog_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormRectangleDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.createForRectangle = null;
        }
    }
}
