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
    public partial class FormShapeMoveToDialog : Form
    {
        public FormShapeMoveToDialog()
        {
            InitializeComponent();
            
            comboBox1.DataSource = ShapeContainer.figureList;
            comboBox1.DisplayMember = "FigureName";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int newX, newY;
            try
            {
                if (((textBox1.Text != "") && (textBox2.Text != "")) || (textBox1.Text != "") || (textBox2.Text != ""))
                {
                    newX = int.Parse(textBox1.Text);
                    newY = int.Parse(textBox2.Text);
                    Figure figure = (Figure)comboBox1.SelectedItem;
                    figure.MoveTo(newX, newY);
                }
                else
                {
                    MessageBox.Show("Данных, которые вы ввели, не достаточно для перемещения фигуры", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Вы ввели некорректные данные. Пожалуйста, исправьте их", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormShapeMoveToDialog_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormShapeMoveToDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.replace = null;
        }
    }
}
