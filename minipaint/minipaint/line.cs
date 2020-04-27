using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
    class line:shape
    {
       
        public int x2 { get; set; }
          public int y2 { get; set; }
          public override void Draw(Graphics g) {
              if (isselect)
              {
                  g.DrawLine(new Pen(Color.Red, thickness + 2), x, y, x2, y2);
              }
              g.DrawLine(new Pen(color, thickness), x, y, x2, y2);
          }
          public override string serialize()
          {
              return String.Format("{0},{1},{2},{3},{4},{5}", x, y, x2, y2, thickness, ((int)color.A) << 24 | ((int)color.R) << 16 | ((int)color.G) << 8 | (int)color.B);
          }

          public override void deserialize(string textdata)
          {
              var props = textdata.Split(',');
              x = int.Parse(props[0]);
              y = int.Parse(props[1]);
              x2 = int.Parse(props[2]);
              y2 = int.Parse(props[3]);
              thickness = int.Parse(props[4]);
              color = Color.FromArgb(int.Parse(props[5]));
             


          }
     //  public int x2 { get; set; }
     //  public int y2 { get; set; }
     //  public void draw(Graphics g) {
     //      fill = false;
     //      g.DrawLine(new Pen(color, thickness), x, y, x2, y2);
     //  }

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
