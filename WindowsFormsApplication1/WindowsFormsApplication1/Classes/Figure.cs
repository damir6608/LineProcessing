using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    abstract public class Figure
    {
        private int coordX;
        private int coordY;
        private int figureWidth;
        private int figureHeight;
        private float figurePenSize;
        private string figureName;
        public int SweepAnglee;
        public int StartAnglee;
        public Color figureColor;
         public Pen FigurePen = new Pen(Color.Black, 1);

        public int SweepAngle
        {
            get { return SweepAnglee; }
            set { SweepAnglee = value; }
        }
        public int StartAngle
        {
            get { return StartAnglee; }
            set { StartAnglee = value; }
        }

        public int CoordX
        {
            get { return coordX; }
            set { coordX = value; }
        }
        public int CoordY
        {
            get { return coordY; }
            set { coordY = value; }
        }
        


        public int FigureWidth
        {
            get { return figureWidth; }
            set { figureWidth = value; }
        }

        public int FigureHeight
        {
            get { return figureHeight; }
            set { figureHeight = value; }
        }

        public string FigureName
        {   
            get { return figureName; }
            set { figureName = value; }
        }

        public float FigurePenSize
        {
            get { return figurePenSize; }
            set { figurePenSize = value; }
        }
      

        abstract public void DrawFigure();
        abstract public void MoveTo(int newX, int newY);

        public void Clear()
        {
            Graphics graphics = Graphics.FromImage(Init.bitmap);
            graphics.Clear(Init.picturebox.BackColor);
        }

        public void DeleteFigure(Figure figure, bool flag = true)
        {
            if (flag == true)
            {
                Graphics graphics = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                this.Clear();
                Init.picturebox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.DrawFigure();

                }
                if (figure.GetType() == typeof(Rectangle))
                {
                    Init.rectanglesNumber--;
                }
                else if (figure.GetType() == typeof(Square))
                {
                    Init.squaresNumber--;
                }
                else if (figure.GetType() == typeof(Ellipse))
                {
                    Init.ellipsesNumber--;
                }
                else if (figure.GetType() == typeof(Circle))
                {
                    Init.circlesNumber--;
                }
                else if (figure.GetType() == typeof(Alarm))
                {
                    Init.alarmNumber--;
                }
            }
            else
            {
                Graphics graphics = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                this.Clear();
                Init.picturebox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.DrawFigure();
                }
                ShapeContainer.figureList.Add(figure);
            }
           
        }
    }
}
