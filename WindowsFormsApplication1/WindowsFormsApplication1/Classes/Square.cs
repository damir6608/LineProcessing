using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Square : Rectangle
    {
        public Square(int x, int y, int w, float penSize, Color color) : base (x, y, w, w, penSize, color) 
        {
            this.FigureName = "Квадрат " + Convert.ToString(Init.squaresNumber);
        }
    }
}
