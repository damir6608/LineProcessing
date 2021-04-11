using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes;

namespace WindowsFormsApplication1
{
    public partial class FormFiguresMainWindow : Form
    {
        public static char i = 'a';
        public static bool flagForCreate = true;
        public static bool delete = false;
        public static string b = "";
        private Stack<char> z = new Stack <char>();
        Pen pen;
        Bitmap bitmap;
        int penSize = 1;
        public static FormCircleDialog createForCircle;
        public static FormEllipseDialog createForEllips;
        public static FormRectangleDialog createForRectangle;
        public static FormSquareDialog createForSquare;
        public static FormShapeDeleteDialog remove;
        public static FormShapeMoveToDialog replace;
        public static bool forAlarm = true;
        String del;
        Ellipse ellipse;
        Circle circle;
        Rectangle rectangle;
        Square square;
        Arc arc;



        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<int> operands = new Stack<int>();
        private Stack<string> nameOperands = new Stack<string>();
        public static string FigureName;

        ShapeContainer shapecontainer = new ShapeContainer();


        public FormFiguresMainWindow()
        {
            InitializeComponent();

            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, penSize);
            Init.bitmap = this.bitmap;
            Init.picturebox = pictureBox1;
            Init.pen = this.pen;
        }

        public void button2_Click(object sender, EventArgs e)
        {

            if (createForEllips != null)
            {
                return;
            }

            createForEllips = new FormEllipseDialog();




            createForEllips.Show();





        }

        public void button3_Click(object sender, EventArgs e)
        {



            if (createForCircle != null)
            {
                return;
            }

            createForCircle = new FormCircleDialog();


            createForCircle.Show();
        }

        public void button4_Click(object sender, EventArgs e)
        {


            if (createForSquare != null)
            {
                return;
            }

            createForSquare = new FormSquareDialog();


            createForSquare.Show();


        }

        public void button6_Click(object sender, EventArgs e)
        {
            if (ShapeContainer.figureList.Count == 0)
            {
                MessageBox.Show("Отсутствуют созданные фигуры", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (remove != null)
                {
                    return;
                }

                remove = new FormShapeDeleteDialog();


                remove.Show();
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            if (ShapeContainer.figureList.Count == 0)
            {
                MessageBox.Show("Отсутствуют созданные фигуры", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (replace != null)
                {
                    return;
                }

                replace = new FormShapeMoveToDialog();


                replace.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            if (createForRectangle != null)
            {
                return;
            }

            createForRectangle = new FormRectangleDialog();




            createForRectangle.Show();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Alarm.main = this;
            //Reference.form = this;
        }

       

        public void MainHandler()
        {
            ClearOper();
            FormFiguresMainWindow.FigureName = "";
            
            for (int i = 0; i < textBoxInputString.Text.Length; i++)
            {
               

               

                if (IsNotOperation(textBoxInputString.Text[i]))
                {
                    try
                    {


                        if (!(Char.IsDigit(textBoxInputString.Text[i])) && !(textBoxInputString.Text[i] == ',') && !(textBoxInputString.Text[i] == ' ') && !(textBoxInputString.Text[i] == '-'))
                        {
                            try
                            {
                                if (operators.Peek().symbolOperator == '(')
                                {
                                    FigureName += Convert.ToString(textBoxInputString.Text[i]);
                                    continue;
                                }
                                else
                                {
                                    comboBox1.Items.Add("<<" + textBoxInputString.Text + ">>" + "  некорректно");
                                    break;
                                }
                            }
                            catch
                            {
                                comboBox1.Items.Add("<<" + textBoxInputString.Text + ">>" + "  некорректно");
                            }



                        }

                        else if (Char.IsDigit(textBoxInputString.Text[i]) && textBoxInputString.Text[i - 1] != '-')
                        {
                            if (Char.IsDigit(textBoxInputString.Text[i + 1]))
                            {
                                if (Char.IsDigit(textBoxInputString.Text[i + 2]))
                                {

                                    this.operands.Push((Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i])) * 100) + (Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 1])) * 10) + Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 2])));
                                    i += 2;
                                    continue;
                                }
                                else if (textBoxInputString.Text[i + 2] == ',')
                                {

                                    this.operands.Push((Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i])) * 10) + (Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 1]))));
                                    i += 1;
                                    continue;
                                }

                            }

                            else if (textBoxInputString.Text[i + 1] == ',')
                            {
                                this.operands.Push(Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i])));
                                continue;
                            }
                        }
                        else if (Char.IsDigit(textBoxInputString.Text[i]) && textBoxInputString.Text[i - 1] == '-')
                        {
                            if (Char.IsDigit(textBoxInputString.Text[i + 1]))
                            {
                                if (Char.IsDigit(textBoxInputString.Text[i + 2]))
                                {

                                    this.operands.Push(-1 * ((Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i])) * 100) + (Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 1])) * 10) + Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 2]))));
                                    i += 2;
                                    continue;
                                }
                                else if ((textBoxInputString.Text[i + 2] == ',' || textBoxInputString.Text[i + 2] == ')'))
                                {

                                    this.operands.Push(-1 * ((Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i])) * 10) + (Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i + 1])))));
                                    i += 1;
                                    continue;
                                }

                            }

                            else if ((textBoxInputString.Text[i + 1] == ',' || textBoxInputString.Text[i + 1] == ')'))
                            {
                                this.operands.Push(-1 * (Convert.ToInt32(Convert.ToString(textBoxInputString.Text[i]))));
                                continue;
                            }
                        }

                    }
                    catch
                    {
                        dontSelected();
                    }


                }
                else if (textBoxInputString.Text[i] == 'O')
                {
                    if (this.operators.Count == 0)
                    {

                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                    }
                }
                else if (textBoxInputString.Text[i] == 'M')
                {
                    if (this.operators.Count == 0)
                    {

                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                    }
                }
                else if (textBoxInputString.Text[i] == 'D')
                {
                    if (this.operators.Count == 0)
                    {

                        this.operators.Push(OperatorContainer.FindOperator(textBoxInputString.Text[i]));
                    }
                }
                else if (textBoxInputString.Text[i] == ',')
                {
                    this.z.Push((textBoxInputString.Text[i]));
                }
                else if (textBoxInputString.Text[i] == '(')
                {

                    this.operators.Push(OperatorContainer.FindOperator
                    (textBoxInputString.Text[i]));
                }
                else if (textBoxInputString.Text[i] == ')')
                {
                    //try
                    //{
                    //    if ((textBoxInputString.Text[i + 1] > 1 && textBoxInputString.Text[i + 1] < 127) ||
                    //        (textBoxInputString.Text[i + 2] > 1 && textBoxInputString.Text[i + 2] < 127))
                    //    {
                    //        FigureName = " ";
                    //    }
                    //}
                    //catch
                    //{

                    //}


                    


                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();

                                break;

                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                   

                }

               
            }
            
            try
            {
               
                if (operators.Peek() != null&&FigureName!="" &&z.Count%4==0)
                {
                    
                    this.SelectingPerformingOperation(operators.Peek());

                }
                else  
                {
                    MessageBox.Show("Введенной операции не существует");
                    dontSelected();
                }
               
               

            }
            catch
            {
              
                   


            }
            


        }
        public delegate void rem();
        private void dontSelected()
        {
            MessageBox.Show("Запись некорректна");
            comboBox1.Items.Add("<<" +textBoxInputString.Text + ">>" + "  некорректно" );
        }

        public void SelectingPerformingOperation(Operator op)
        {
            
            if (op.symbolOperator == 'O')
            {
                flagForCreate = true;
                if (operands.Count != 4)
                {
                    
                    flagForCreate = false;
                }
                 
                foreach (Alarm a in ShapeContainer.figureList)
                {
                    if(a.FigureName==FigureName)
                    {
                        flagForCreate = false;
                    }
                    
                }

                int h = Convert.ToInt32(operands.Pop().ToString());
                int w = Convert.ToInt32(operands.Pop().ToString());
                int y = Convert.ToInt32(operands.Pop().ToString());
                int x = Convert.ToInt32(operands.Pop().ToString());



                Alarm al = new Alarm(x, y, w, h, FigureName);

                al.DrawFigure();
                

                if (flagForCreate)
                {
                   
                    
                    ShapeContainer.AddFigure(al);

                    comboBox1.Items.Add("Рисунок под названием " + al.FigureName + " отрисован.");
                    //op.operatorMethod();
                    FigureName = "";
                    ClearOper();
                   
                }
                else
                {
                    comboBox1.Items.Add("Некорректные данные");
                    MessageBox.Show("Некорректные даннные");
                    ClearOper();
                    
                }
                ClearOperand();
                ClearZ();

            }

           else if (op.symbolOperator == 'M')
            {
                flagForCreate = true;
                if (operands.Count != 4)
                {
                    dontSelected();
                    flagForCreate = false;
                }


                int h = Convert.ToInt32(operands.Pop().ToString());
                int w = Convert.ToInt32(operands.Pop().ToString());
                int y = Convert.ToInt32(operands.Pop().ToString());
                int x = Convert.ToInt32(operands.Pop().ToString());
                bool flag = true;

                if (flagForCreate)
                {


                    foreach (Alarm a in ShapeContainer.figureList)
                    {

                        if (a.FigureName == FigureName)
                        {
                            if (w == a.w && a.h == h)
                            {
                                //Graphics graphics = Graphics.FromImage(Init.bitmap);

                                //ShapeContainer.figureList.Remove(a);
                                this.Clear();
                                Init.picturebox.Image = Init.bitmap;

                                a.MoveTo(x, y);

                                //ShapeContainer.AddFigure(a);
                                comboBox1.Items.Add("Рисунок под названием " + a.FigureName + " перемещен.");
                                flag = false;
                            }

                        }
                        foreach (Alarm f in ShapeContainer.figureList)
                        {

                            f.DrawFigure();


                        }
                    }
                    if (flag)
                    {
                        MessageBox.Show("Фигура не найдена или не задан верный размер");
                        comboBox1.Items.Add("Фигуры " + FigureName + " с такими парметрами\n не существует");
                    }
                }

                    ClearOper();
                ClearOperand();
                ClearZ();
            }

           else  if (op.symbolOperator == 'D')
            {
                rem d = deleteAlarm;
                d();
                //Figure figure = nameOperands.Pop();
                //Graphics graphics = Graphics.FromImage(Init.bitmap);
                //ShapeContainer.figureList.Remove(figure);




            }
            else
            {
                dontSelected();
            }
            
        }


        public void Clear()
        {
            Graphics graphics = Graphics.FromImage(Init.bitmap);
            graphics.Clear(Init.picturebox.BackColor);
        }


        private void button7_Click_1(object sender, EventArgs e)
        {



            //drawBack();
            //Alarm al = new Alarm(0, 0, 0, 0);
            //al.DrawFigure();
            //Init.alarmNumber++;
            //ShapeContainer.AddFigure(al);
            


        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Reference r = new Reference();
                r.Show();
            
            
            
            
        }

        public void ClearOper()
        {
            try
            {
                while (operators.Peek() != null)
                {
                    operators.Pop();
                }
            }
            catch
            {

            }
           
        }
        public void ClearOperand()
        {
            try
            {
                while (operands.Count != 0)
                {
                    operands.Pop();
                }
            }
            catch
            {

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                ClearOper();
                MainHandler();
                 b = textBoxInputString.Text;
                textBoxInputString.Text = "";
               
            }
            if (e.KeyCode == Keys.Up)
            {
                textBoxInputString.Text = b;
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==79  ) //79=O    
            {
                textBoxInputString.Text += "(name"+(i++)+", 10, 10, 241, 350)";
            }
            if (e.KeyChar == 77)//77=M 
            {
                textBoxInputString.Text += "(name" + ", 10, 10, 241, 350)";
            }

            if (e.KeyChar == 68) // 68 = D
            {
                textBoxInputString.Text += "(name)";
            }
           
        }
        private bool IsNotOperation(char item)
        {
            if (!(item == 'O' || item == 'M' || item == 'D'   || item == ',' || item == '(' || item == ')'))
                {
                return true;
                }
            else
                {
                return false;
                }

        }
        public void ClearZ()
        {
            try
            {
                while (z.Count != 0)
                {
                    z.Pop();
                }
            }
            catch
            {

            }
        }
        public void deleteAlarm()
        {
            bool flag = true;
            foreach (Alarm a in ShapeContainer.figureList)
            {
                if (a.FigureName == FigureName)
                {
                    Graphics graphics = Graphics.FromImage(Init.bitmap);
                    ShapeContainer.figureList.Remove(a);
                    this.Clear();
                    Init.picturebox.Image = Init.bitmap;
                    comboBox1.Items.Add("Рисунок под названием " + a.FigureName + " удален.");
                    flag = false;
                }
                foreach (Alarm f in ShapeContainer.figureList)
                {
                    f.DrawFigure();

                }
            }
            if (flag)
            {
                MessageBox.Show("Фигура не найдена");
                comboBox1.Items.Add("Фигуры с именем " + FigureName + " не существует");
            }
            else
            {
                MessageBox.Show("Фигура " + FigureName + "удалена.");
            }
            ClearOper();
            ClearZ();
            
        }

        
    }
}
