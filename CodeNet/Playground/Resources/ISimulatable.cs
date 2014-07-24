using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Resources
{
    public interface Simulatable
    {
        double X { get; set; }

        double Xt { get; set; }

        double Y { get; set; }

        double Yt { get; set; }
    }
}
