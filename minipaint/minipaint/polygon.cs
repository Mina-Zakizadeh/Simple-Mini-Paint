using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
    class polygon:fillableshape
    {
        public int x2 { get; set; }
          public int x3 { get; set; }
          public int x4 { get; set; }
          public int x5 { get; set; }
          public int y2 { get; set; }
          public int y3 { get; set; }
          public int y4 { get; set; }
          public int y5 { get; set; }
          public override void Draw(Graphics g) {
              Point point1=new Point(x,y);
              Point point2=new Point(x2,y2);
              Point point3=new Point(x3,y3);
              Point point4=new Point(x4,y4);
              Point point5=new Point(x5,y5);
              Point[] point ={point1,point2,point3,point4,point5
                                };
              if (isselect == true && fill)




                  g.DrawPolygon  (new Pen(Color.Red, thickness + 2),point);

              else if (isselect && fill == false)


                  g.FillPolygon (new SolidBrush(Color.Red),point);
        
                          if (fill)
              {
                  g.FillPolygon(new SolidBrush(fillcolor),point);
              }
                          g.DrawPolygon(new Pen(color, thickness), point);
          }
          public override string serialize()
          {
              return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", x, y, x2, y2, x3, y3, x4, y4, x5, y5, thickness, ((int)color.A) << 24 | ((int)color.R) << 16 | ((int)color.G) << 8 | (int)color.B, ((int)fillcolor.A) << 24 | ((int)fillcolor.R) << 16 | ((int)fillcolor.G) << 8 | ((int)fillcolor.B));
          }

          public override void deserialize(string textdata)
          {
              var props = textdata.Split(',');
              x = int.Parse(props[0]);
              y = int.Parse(props[1]);
              x2 = int.Parse(props[2]);
              y2 = int.Parse(props[3]);
              x3 = int.Parse(props[4]);
              y3 = int.Parse(props[5]);
              x4 = int.Parse(props[6]);
              y4 = int.Parse(props[7]);
              x5 = int.Parse(props[8]);
              y5 = int.Parse(props[9]);
              thickness = int.Parse(props[10]);
              color = Color.FromArgb(int.Parse(props[11]));
              fillcolor = Color.FromArgb(int.Parse(props[12]));


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
