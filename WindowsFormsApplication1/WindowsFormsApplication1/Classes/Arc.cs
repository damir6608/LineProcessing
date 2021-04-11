using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Arc : Figure
    {
        public Arc( int x, int y, int width, int height, int startAngle, int sweepAngle,Color color)
        {
            this.CoordX = x;
            this.CoordY = y;
            this.FigureWidth = width;
            this.FigureHeight = height;
            this.FigureName = "Дуга " + Convert.ToString(Init.ellipsesNumber);
            this.StartAnglee = startAngle;
            this.SweepAnglee = sweepAngle;

        }
        public Arc()
        {
            this.StartAnglee = 0;
            this.SweepAnglee = 0;
            this.CoordX = 0;
            this.CoordY = 0;
            this.FigureWidth = 0;
            this.FigureHeight = 0;
            this.figureColor = Color.Black;
        }

        public override void DrawFigure()
        {
            float bufferPenSize = Init.pen.Width;
            Color bufferColor = Init.pen.Color;
            Init.pen.Color = this.figureColor;
            Init.pen.Width = this.FigurePenSize;
            Graphics graphics = Graphics.FromImage(Init.bitmap);
            graphics.DrawArc(Init.pen, CoordX, CoordY, FigureWidth, FigureHeight,StartAnglee,SweepAnglee);
            Init.picturebox.Image = Init.bitmap;
            Init.pen.Color = bufferColor;
            Init.pen.Width = bufferPenSize;
        }
        public override void MoveTo(int newX, int newY)
        {
            if (!((this.CoordX + newX < 0 && this.CoordY + newY < 0) || (this.CoordY + newY < 0) || (this.CoordX + newX > Init.picturebox.Width && this.CoordY + newY < 0) || (this.CoordX + this.FigureWidth + newX > Init.picturebox.Width) || (this.CoordX + newX > Init.picturebox.Width && this.CoordY + newY > Init.picturebox.Height) || (this.CoordY + this.FigureHeight + newY > Init.picturebox.Height) || (this.CoordX + newX < 0 && this.CoordY + newY > Init.picturebox.Height) || (this.CoordX + newX < 0)))
            {
                this.CoordX += newX;
                this.CoordY += newY;
                this.DeleteFigure(this, false);
                this.DrawFigure();
            }
            else
            {
                MessageBox.Show("Фигура выйдет за экран");
            }
        }
    }
}
