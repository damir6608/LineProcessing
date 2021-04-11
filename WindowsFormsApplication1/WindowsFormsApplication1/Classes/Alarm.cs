using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   public  class Alarm:Figure
    {
        public  double kW;
        public  double kH;
        public int w;
        public int h;

        public Alarm(int x, int y, int w, int h, string FigureName)
        {
                this.CoordX = x;
                this.CoordY = y;
                this.FigureName = FigureName;

            this.w = w;
            this.h = h;

                kW = (double)w / 241;
                kH = (double)h / 350;
            
        }
        public Alarm()
        {
            this.CoordX = 0;
            this.CoordY = 0;
            this.FigureWidth = 0;
            this.FigureHeight = 0;
            this.figureColor = Color.Black;
        }
        Rectangle rectangle;
        Circle circle;
       
        public override void DrawFigure()
        {
            
            Graphics graphics = Graphics.FromImage(Init.bitmap);


            graphics.DrawEllipse(Init.pen, CoordX, CoordY, FigureWidth, FigureHeight);

            //rectangle = new Rectangle(CoordX + 33, CoordY + 30,Convert.ToInt32( 274 * kW), Convert.ToInt32(380*kH), 0, Color.Black);
            //rectangle.DrawFigure();
            double width = 241 * kW;
            double height = 350 * kH;
            if (w > 250 && h > 360)
            {
                width = 241 * kW;
                height = 365 * kH;

            }
            else if (w < 250 && w > 205 && h < 360 && h > 270)
            {
                width = 241 * kW;
                height = 350 * kH;
            }
            else if (w < 205 && h < 270)
            {
                width = 221 * kW;
                height = 265 * kH;
            }


            SolidBrush interf = new SolidBrush(Color.LightYellow);
            SolidBrush legs = new SolidBrush(Color.Red);
            SolidBrush bell = new SolidBrush(Color.Red);
            SolidBrush forArrow = new SolidBrush(Color.Black);

            Pen forBell = new Pen(Color.DarkRed, 4);
            

            if (((this.CoordX > 0) && (this.CoordY > 0) && (this.CoordX + width < 610) && (this.CoordY + height < 425)))
            {
                //Фон
                //rectangle = new Rectangle(50, 50, 712 - 100, 516 - 300, 300, Color.LightBlue);
                //rectangle.DrawFigure();
                ////Солнце
                //circle = new Circle(60, 60, 40, 40, Color.Yellow);
                //circle.DrawFigure();
                ////Стол

                //rectangle = new Rectangle(50, 400, 712, 516, 200, Color.BurlyWood);
                //rectangle.DrawFigure();

                //for (int x1 = 60; x1 < 700; x1 += 180)
                //{
                //    rectangle = new Rectangle(x1, 450, 90, 1, 1, Color.Black);
                //    rectangle.DrawFigure();
                //}
                //for (int x1 = 0; x1 < 700; x1 += 140)
                //{
                //    rectangle = new Rectangle(x1, 350, 90, 1, 1, Color.Black);
                //    rectangle.DrawFigure();
                //}
                //for (int x1 = 140; x1 < 700; x1 += 180)
                //{
                //    rectangle = new Rectangle(x1, 400, 50, 1, 1, Color.Black);
                //    rectangle.DrawFigure();
                //}
                //for (int x1 = 120; x1 < 700; x1 += 180)
                //{
                //    rectangle = new Rectangle(x1, 310, 40, 1, 1, Color.Black);
                //    rectangle.DrawFigure();
                //}



                
                //Фон будильника
                graphics.FillEllipse(interf, Convert.ToInt32(CoordX + 45 * kW), Convert.ToInt32(CoordY + 115*kH), Convert.ToInt32(250 *kW), Convert.ToInt32(250 *kW) );


                circle = new Circle(Convert.ToInt32(CoordX + 166*kW), Convert.ToInt32(CoordY + 234*kH), Convert.ToInt32(8 *kW), Convert.ToInt32(8 * kW), Color.Black);
                circle.DrawFigure();

                //Стрелки
                graphics.FillPolygon(forArrow, new Point[]
                    {
                    new Point(Convert.ToInt32(CoordX + 170 * kW),Convert.ToInt32(CoordY + 240 * kH)),new Point(Convert.ToInt32(CoordX +175 * kW),Convert.ToInt32(CoordY +215 * kH)),
                    new Point(Convert.ToInt32(CoordX +175 * kW),Convert.ToInt32(CoordY +215 * kH)),new Point(Convert.ToInt32(CoordX +205 * kW),Convert.ToInt32(CoordY +195 * kH)),
                    new Point (Convert.ToInt32(CoordX +205 * kW),Convert.ToInt32(CoordY +195 * kH)),new Point(Convert.ToInt32(CoordX +195 * kW),Convert.ToInt32(CoordY +228 * kH)),
                    new Point(Convert.ToInt32(CoordX +195 * kW),Convert.ToInt32(CoordY +228 * kH)),new Point(Convert.ToInt32(CoordX +170 * kW),Convert.ToInt32(CoordY +240 * kH))
                    });
                graphics.FillPolygon(forArrow, new Point[]
                   {
                    new Point(Convert.ToInt32(CoordX + 170* kW),Convert.ToInt32(CoordY + 240* kH)),new Point(Convert.ToInt32(CoordX +155* kW),Convert.ToInt32(CoordY +225* kH)),
                    new Point(Convert.ToInt32(CoordX +155* kW),Convert.ToInt32(CoordY +225* kH)),new Point(Convert.ToInt32(CoordX +95* kW),Convert.ToInt32(CoordY +235* kH)),
                    new Point (Convert.ToInt32(CoordX +95* kW),Convert.ToInt32(CoordY +235* kH)),new Point(Convert.ToInt32(CoordX +150* kW),Convert.ToInt32(CoordY +248* kH)),
                    new Point(Convert.ToInt32(CoordX +150* kW),Convert.ToInt32(CoordY +248* kH)),new Point(Convert.ToInt32(CoordX +170* kW),Convert.ToInt32(CoordY +240* kH))
                   });


                //ножки
                for (int x1 = Convert.ToInt32(60 *kW); x1 <= Convert.ToInt32(230*kW); x1 += Convert.ToInt32(165*kW))
                {
                    circle = new Circle(CoordX + x1, Convert.ToInt32(CoordY + 350*kW), Convert.ToInt32(55 *kW), Convert.ToInt32(6 * kW), Color.DarkRed);
                    circle.DrawFigure();
                    graphics.FillEllipse(legs, CoordX + x1, Convert.ToInt32(CoordY + 350*kW), Convert.ToInt32(55 *kW), Convert.ToInt32(55 *kW));
                }



                //Колокол
                circle = new Circle(Convert.ToInt32(CoordX + 166*kW), Convert.ToInt32(CoordY + 35*kH), Convert.ToInt32(8 *kW), Convert.ToInt32(8*kW), Color.DarkRed);
                circle.DrawFigure();
                graphics.FillPie(bell, Convert.ToInt32(CoordX + 95*kW), Convert.ToInt32(CoordY + 43*kH), Convert.ToInt32(150 *kW), Convert.ToInt32(100 *kH), 0, -180);
                graphics.DrawPie(forBell, Convert.ToInt32(CoordX + 95*kW), Convert.ToInt32(CoordY + 43*kH), Convert.ToInt32(150 *kW), Convert.ToInt32(100 *kH), 0, -180);

                graphics.FillRectangle(bell, Convert.ToInt32(CoordX + 140*kW), Convert.ToInt32(CoordY + 95*kH), Convert.ToInt32(60 *kW), Convert.ToInt32(15 *kH));
                rectangle = new Rectangle(Convert.ToInt32(CoordX + 140*kW), Convert.ToInt32(CoordY + 95*kH), Convert.ToInt32(60 *kW), Convert.ToInt32(15 *kH), Convert.ToInt32(4*kW), Color.DarkRed);
                rectangle.DrawFigure();
                Init.picturebox.Image = Init.bitmap;

                //Оконтовка будильника
                circle = new Circle(Convert.ToInt32(CoordX + 45 * kW), Convert.ToInt32(CoordY + 115*kH), Convert.ToInt32(250 *kW), Convert.ToInt32(20*kW), Color.Red);
                circle.DrawFigure();
                circle = new Circle(Convert.ToInt32(CoordX + 35*kW), Convert.ToInt32(CoordY + 105*kH), Convert.ToInt32(270 *kW), Convert.ToInt32(4*kW), Color.DarkRed);
                circle.DrawFigure();




                //Черные окружности на циферблате
                for (double angle = 0; angle <= 5.72 ; angle += 0.52)
                {



                    circle = new Circle(Convert.ToInt32(CoordX + (155*kW) + (int)(90*kW * Math.Cos(angle))), Convert.ToInt32(CoordY + (225*(kW+0.05)) + (int)(90 *kW* Math.Sin(angle))), Convert.ToInt32(30 *kW), 4, Color.Black);
                    circle.DrawFigure();



                }
                //Рамка
                rectangle = new Rectangle(0, 0, 712, 516, 70, Color.Brown);
                rectangle.DrawFigure();
                rectangle = new Rectangle(0, 0, 712 - 5, 516 - 5, 10, Color.Black);
                rectangle.DrawFigure();
                rectangle = new Rectangle(30, 30, 712 - 60, 516 - 60, 5, Color.Black);
                rectangle.DrawFigure();

        }
            else
            {
                
                FormFiguresMainWindow.flagForCreate = false;


            }
}
        public override void MoveTo(int newX, int newY)
        {
            double width = 241 * kW;
            double height = 350 * kH;

            if (w > 250 && h > 360)
            {
                width = 241 * kW;
                height = 365 * kH;

            }
            else if (w < 250 && w > 205 && h < 360 && h > 270)
            {
                width = 241 * kW;
                height = 350 * kH;
            }
            else if (w < 205 && h < 270)
            {
                width = 221 * kW;
                height = 265 * kH;
            }

            if (((this.CoordX   +newX> 0) && (this.CoordY  + newY > 0) && (this.CoordX + width  + newX< 610) && (this.CoordY + height + newY < 425)))
            {
                this.CoordX += newX;
                this.CoordY += newY;
                this.DeleteFigure(this, false);
                //this.DrawFigure();
            }
            else
            {
                MessageBox.Show("Фигура выйдет за экран");
            }
        }
        public void Draw(int newX,int newY)
        {
            Graphics graphics = Graphics.FromImage(Init.bitmap);


            double width = 241 * kW;
            double height = 350 * kH;


            if (((this.CoordX > 0) && (this.CoordY > 0) && (this.CoordX + width < 610) && (this.CoordY + height < 446)))
            {


                SolidBrush interf = new SolidBrush(Color.LightYellow);
                SolidBrush legs = new SolidBrush(Color.Red);
                SolidBrush bell = new SolidBrush(Color.Red);
                SolidBrush forArrow = new SolidBrush(Color.Black);

                Pen forBell = new Pen(Color.DarkRed, 4);


            




                //Фон будильника
                graphics.FillEllipse(interf, Convert.ToInt32(CoordX + 45 * kW), Convert.ToInt32(CoordY + 115 * kH), Convert.ToInt32(250 * kW), Convert.ToInt32(250 * kW));


                circle = new Circle(Convert.ToInt32(CoordX + 166 * kW), Convert.ToInt32(CoordY + 234 * kH), Convert.ToInt32(8 * kW), Convert.ToInt32(8 * kW), Color.Black);
                circle.DrawFigure();

                //Стрелки
                graphics.FillPolygon(forArrow, new Point[]
                    {
                    new Point(Convert.ToInt32(CoordX + 170 * kW),Convert.ToInt32(CoordY + 240 * kH)),new Point(Convert.ToInt32(CoordX +175 * kW),Convert.ToInt32(CoordY +215 * kH)),
                    new Point(Convert.ToInt32(CoordX +175 * kW),Convert.ToInt32(CoordY +215 * kH)),new Point(Convert.ToInt32(CoordX +205 * kW),Convert.ToInt32(CoordY +195 * kH)),
                    new Point (Convert.ToInt32(CoordX +205 * kW),Convert.ToInt32(CoordY +195 * kH)),new Point(Convert.ToInt32(CoordX +195 * kW),Convert.ToInt32(CoordY +228 * kH)),
                    new Point(Convert.ToInt32(CoordX +195 * kW),Convert.ToInt32(CoordY +228 * kH)),new Point(Convert.ToInt32(CoordX +170 * kW),Convert.ToInt32(CoordY +240 * kH))
                    });
                graphics.FillPolygon(forArrow, new Point[]
                   {
                    new Point(Convert.ToInt32(CoordX + 170* kW),Convert.ToInt32(CoordY + 240* kH)),new Point(Convert.ToInt32(CoordX +155* kW),Convert.ToInt32(CoordY +225* kH)),
                    new Point(Convert.ToInt32(CoordX +155* kW),Convert.ToInt32(CoordY +225* kH)),new Point(Convert.ToInt32(CoordX +95* kW),Convert.ToInt32(CoordY +235* kH)),
                    new Point (Convert.ToInt32(CoordX +95* kW),Convert.ToInt32(CoordY +235* kH)),new Point(Convert.ToInt32(CoordX +150* kW),Convert.ToInt32(CoordY +248* kH)),
                    new Point(Convert.ToInt32(CoordX +150* kW),Convert.ToInt32(CoordY +248* kH)),new Point(Convert.ToInt32(CoordX +170* kW),Convert.ToInt32(CoordY +240* kH))
                   });


                //ножки
                for (int x1 = Convert.ToInt32(60 * kW); x1 <= Convert.ToInt32(230 * kW); x1 += Convert.ToInt32(165 * kW))
                {
                    circle = new Circle(CoordX + x1, Convert.ToInt32(CoordY + 350 * kW), Convert.ToInt32(55 * kW), Convert.ToInt32(6 * kW), Color.DarkRed);
                    circle.DrawFigure();
                    graphics.FillEllipse(legs, CoordX + x1, Convert.ToInt32(CoordY + 350 * kW), Convert.ToInt32(55 * kW), Convert.ToInt32(55 * kW));
                }



                //Колокол
                circle = new Circle(Convert.ToInt32(CoordX + 166 * kW), Convert.ToInt32(CoordY + 35 * kH), Convert.ToInt32(8 * kW), Convert.ToInt32(8 * kW), Color.DarkRed);
                circle.DrawFigure();
                graphics.FillPie(bell, Convert.ToInt32(CoordX + 95 * kW), Convert.ToInt32(CoordY + 43 * kH), Convert.ToInt32(150 * kW), Convert.ToInt32(100 * kH), 0, -180);
                graphics.DrawPie(forBell, Convert.ToInt32(CoordX + 95 * kW), Convert.ToInt32(CoordY + 43 * kH), Convert.ToInt32(150 * kW), Convert.ToInt32(100 * kH), 0, -180);

                graphics.FillRectangle(bell, Convert.ToInt32(CoordX + 140 * kW), Convert.ToInt32(CoordY + 95 * kH), Convert.ToInt32(60 * kW), Convert.ToInt32(15 * kH));
                rectangle = new Rectangle(Convert.ToInt32(CoordX + 140 * kW), Convert.ToInt32(CoordY + 95 * kH), Convert.ToInt32(60 * kW), Convert.ToInt32(15 * kH), Convert.ToInt32(4 * kW), Color.DarkRed);
                rectangle.DrawFigure();
                Init.picturebox.Image = Init.bitmap;

                //Оконтовка будильника
                circle = new Circle(Convert.ToInt32(CoordX + 45 * kW), Convert.ToInt32(CoordY + 115 * kH), Convert.ToInt32(250 * kW), Convert.ToInt32(20 * kW), Color.Red);
                circle.DrawFigure();
                circle = new Circle(Convert.ToInt32(CoordX + 35 * kW), Convert.ToInt32(CoordY + 105 * kH), Convert.ToInt32(270 * kW), Convert.ToInt32(4 * kW), Color.DarkRed);
                circle.DrawFigure();




                //Черные окружности на циферблате
                for (double angle = 0; angle <= 5.72; angle += 0.52)
                {



                    circle = new Circle(Convert.ToInt32(CoordX + (155 * kW) + (int)(90 * kW * Math.Cos(angle))), Convert.ToInt32(CoordY + (225 * (kW + 0.05)) + (int)(90 * kW * Math.Sin(angle))), Convert.ToInt32(30 * kW), 4, Color.Black);
                    circle.DrawFigure();



                }
                //Рамка
                rectangle = new Rectangle(0, 0, 712, 516, 70, Color.Brown);
                rectangle.DrawFigure();
                rectangle = new Rectangle(0, 0, 712 - 5, 516 - 5, 10, Color.Black);
                rectangle.DrawFigure();
                rectangle = new Rectangle(30, 30, 712 - 60, 516 - 60, 5, Color.Black);
                rectangle.DrawFigure();

            }
            else
            {

                FormFiguresMainWindow.flagForCreate = false;


            }
        }
       
    }
}
