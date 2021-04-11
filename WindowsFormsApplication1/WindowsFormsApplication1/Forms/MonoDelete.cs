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
    public partial class FormShapeDeleteDialog : Form
    {
        public FormShapeDeleteDialog()
        {
            InitializeComponent();

            comboBox1.DataSource = ShapeContainer.figureList;
            comboBox1.DisplayMember = "FigureName";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Figure figure = (Figure)comboBox1.SelectedItem;
            figure.DeleteFigure(figure, true);
            MessageBox.Show("Удалено", "Сведения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormShapeDeleteDialog_Load(object sender, EventArgs e)
        {

        }

        private void FormShapeDeleteDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormFiguresMainWindow.remove = null;
        }
    }
}
