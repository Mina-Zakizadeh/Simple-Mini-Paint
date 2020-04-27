using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
  abstract  class fillableshape : shape
    {
        public Color fillcolor { get; set; }
        public bool fill { get; set; }
       
    }
}
