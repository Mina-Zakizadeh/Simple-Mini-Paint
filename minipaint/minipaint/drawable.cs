using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
   abstract class drawable: Itextserializer,ICloneable
    {
        public int x { get; set; }
        public int y { get; set; }
        public abstract void Draw(Graphics g);

        public abstract string serialize();

        public abstract void deserialize(string textdata);
        public abstract object Clone();
        abstract public double distanceto(int X, int Y);
       [Browsable (false)]
        public bool isselect { get; set; }
    
    }
}
