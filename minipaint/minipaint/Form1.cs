using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minipaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            shapes = new List<drawable>();
        }
        List<drawable> shapes;
        
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

         
            Refresh();
        }



        public void Refresh()
        {
            var g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);

            foreach (var item in shapes)
            {
                if (item is rectangle)
                {
                    rectangle r = (rectangle)item;
                    r.Draw(g);

                }
                else if (item is circle)
                {
                    circle c = (circle)item;
                    c.Draw(g);
                }
                else if (item is ellipse)
                {
                    ellipse e = (ellipse)item;
                    e.Draw(g);
                }
                else if (item is line)
                {
                    line l = (line)item;
                    l.Draw(g);
                }
                else if (item is polygon)
                {
                    
                   polygon p = (polygon)item;
                    p.Draw(g);
                  
                }
               
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rectangle r = new rectangle
            {
                x = 34,
                y = 34,
                width = 54,
                height = 34,
                thickness = 1,
                color = Color.DarkCyan,
                fillcolor = Color.Gainsboro,


            };

            
            propertyGrid1.SelectedObject = r;
          
            shapes.Add(r);
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            circle c = new circle
            {
                r = 34,
                x = 30,
                y = 40,
                thickness = 1,
                color = Color.LightSkyBlue,
                fillcolor = Color.Orange,

            };
            
         
            propertyGrid1.SelectedObject = c;
            shapes.Add(c);
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ellipse el = new ellipse
            {
                x = 40,
                y = 30,
                r1 = 45,
                r2 = 89,
                thickness = 1,
                color = Color.SteelBlue,
                fillcolor = Color.Red,
            };
          
            propertyGrid1.SelectedObject = el;
            shapes.Add(el);
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            line l = new line
            {
                x = 67,
                y = 30,
                x2 = 12,
                y2 = 21,
                color = Color.Black,
            };
           
            propertyGrid1.SelectedObject = l;
            shapes.Add(l);
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            polygon p = new polygon
            {
                x = 50,
                y = 50,
                x2 = 34,
                y2 = 23,
                x3 = 45,
                y3 = 54,
                x4 = 56,
                y4 = 65,
                x5 = 67,
                y5 = 76,
                thickness = 1,
                color = Color.SandyBrown,
                fillcolor = Color.BlueViolet,

            };
 
            propertyGrid1.SelectedObject = p;
            shapes.Add(p);
            Refresh();
        }
        

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            drawable near = null;
            double mindist = double.MaxValue ;
            foreach (var item in shapes)
            {
                item.isselect = false;
                var dist = item.distanceto(e.X, e.Y);
                if (dist<mindist)
                {
                    near = item;
                    mindist = dist;
                    
                }
            }
            near.isselect = true;
            propertyGrid1.SelectedObject = near;
         
            Refresh();
        }
        drawable dragshape = null;
        
        int xmousedrag, ymousedrag;
        int xshapedrag, yshapedrag;
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            drawable near = null;
           
            double mindist = double.MaxValue;
            foreach (var item in shapes)
            {
                
                var dist = item.distanceto(e.X, e.Y);
                if (dist < mindist)
                {
                    near = item;
                    mindist = dist;

                }
            }
            if (near!= null)
            {
                dragshape = near;
                xshapedrag = dragshape.x;
                yshapedrag = dragshape.y;
               xmousedrag= e.X;
               ymousedrag = e.Y;
                
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragshape!=null)
            {
                dragshape = null;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragshape!=null)
            {
                int dx = e.X - xmousedrag;
            int dy=e.Y-ymousedrag;
            dragshape.x = xshapedrag + dx;
            dragshape.y = yshapedrag + dy;
            Refresh();
            }
        }

       

       

   
       

    }
}
      
 
 
  

