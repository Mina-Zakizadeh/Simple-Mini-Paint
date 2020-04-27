using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minipaint
{
    interface Itextserializer
    {
        String serialize();
        void deserialize(String textdata);
    }
}
