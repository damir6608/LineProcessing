using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Circle : Ellipse
    {
        public Circle(int x, int y, int w, float penSize, Color color) : base (x, y, w, w, penSize, color)
        {
            this.FigureName = "Окружность " + Convert.ToString(Init.circlesNumber);
        }
    }
}
