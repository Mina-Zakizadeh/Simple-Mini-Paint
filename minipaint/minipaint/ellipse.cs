using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
    class ellipse: fillableshape
    {
        public int r1 { get; set; }
        public int r2 { get; set; }
        public override void Draw(Graphics g) {
            if (isselect == true && fill)




                g.DrawEllipse(new Pen(Color.Red, thickness + 2), x, y, r1, r2);

            else if (isselect && fill == false)


                g.FillEllipse(new SolidBrush(Color.Red), x, y, r1, r2);
            if (fill)
            {
                g.FillEllipse(new SolidBrush(fillcolor), x, y, r1, r2);
        
            }
            g.DrawEllipse(new Pen(color, thickness), x, y, r1, r2);
        }
        public override string serialize()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6}", x, y, r1, r2, thickness, ((int)color.A) << 24 | ((int)color.R) << 16 | ((int)color.G) << 8 | (int)color.B, ((int)fillcolor.A) << 24 | ((int)fillcolor.R) << 16 | ((int)fillcolor.G) << 8 | ((int)fillcolor.B));
        }

        public override void deserialize(string textdata)
        {
            var props = textdata.Split(',');
            x = int.Parse(props[0]);
            y = int.Parse(props[1]);
            r1 = int.Parse(props[2]);
            r2 = int.Parse(props[3]);
            thickness = int.Parse(props[4]);
            color = Color.FromArgb(int.Parse(props[5]));
            fillcolor = Color.FromArgb(int.Parse(props[6]));


        }
   
        public override object Clone()
        {
            throw new NotImplementedException();
        }
        public override double distanceto(int X, int Y)
        {
            return Math.Sqrt(Math.Pow((x - X), 2) + Math.Pow((y - Y), 2));
        }
    }
}
