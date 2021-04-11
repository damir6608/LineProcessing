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

    public partial class FormSquareDialog : Form
    {
        Square square;
        public FormSquareDialog()
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
                if (((x >= 0) && (x < Init.picturebox.Width)) && (y >= 0 && (y < Init.picturebox.Height)) && (w > 0 && (w < Init.picturebox.Width)) && (x + w <= Init.picturebox.Width) && (y + w <= Init.picturebox.Height))
                {
                    Init.squaresNumber++;
                    this.square = new Square(x, y, w, penSize, color);
                    square.DrawFigure();
                    ShapeContainer.AddFigure(this.square);
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
                    MessageBox.Show("Пожалуйста, заполните все поля для создания квадрата", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Данных, введенных вами для создания квадрата, не хватает, или они оказались некорректны. Пожалуйста, исправьте их", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormSquareDialog_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormSquareDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.createForSquare = null;
        }
    }
}
