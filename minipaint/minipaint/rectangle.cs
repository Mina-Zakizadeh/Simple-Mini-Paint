using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
    class rectangle:fillableshape
    {public int width { get; set; }
      public int height { get; set; }
      
        public override void Draw(Graphics g)
        {
            if (isselect == true && fill)




                g.DrawRectangle (new Pen(Color.Red, thickness + 2), x, y, width, height);

            else if (isselect && fill == false)


                g.FillRectangle (new SolidBrush(Color.Red), x, y, width, height);
             if (fill)
           {
               g.FillRectangle(new SolidBrush(fillcolor), x, y,width,height);
           }
           g.DrawRectangle(new Pen(color, thickness), x, y, width, height);
        }
    

        public override string serialize()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6}", x, y, width,height,thickness,((int)color.A)<<24 | ((int) color.R)<<16 | ((int)color.G)<<8 | (int)color.B, ((int)fillcolor.A)<<24 | ((int)fillcolor.R)<<16 | ((int)fillcolor.G)<<8 | ((int)fillcolor.B));
        }

        public override void deserialize(string textdata)
        {
            var props = textdata.Split(',');
            x = int.Parse(props[0]);
            y = int.Parse(props[1]);
            width = int.Parse(props[2]);
            height = int.Parse(props[3]);
            thickness = int.Parse(props[4]);
            color = Color.FromArgb(int.Parse(props[5]));
            fillcolor = Color.FromArgb(int.Parse(props[6]));
            

        }

        public override object Clone()
        {
            var r = new rectangle();
            r.x = x;
            r.y = y;
            r.width = width;
            r.height = height;
            r.thickness = thickness;
            r.color = color;
            r.fillcolor = fillcolor;
            return r;
        }
        public override double distanceto(int X, int Y)
        {
            return Math.Sqrt(Math.Pow((x - X), 2)+ Math.Pow((y - Y), 2));
        }
    }
}
