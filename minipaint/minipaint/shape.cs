using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
   abstract class shape : drawable
    {
        public Color color { get; set; }
        public int thickness { get; set; }
    }
}
