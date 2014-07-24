using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeNet;
using Playground.Resources;

namespace Playground.Middleware
{
    public class Physics<T> : CodeNet.Middleware
    {
        public static Random r = new Random();
        public static int cx = 350;
        public static int cy = 300;

        public Physics()
        {
            ListIn = new Resource();
            ListIn.Type = typeof(List<T>);

            ListOut = new Resource();
            ListOut.Type = typeof(List<T>);
            ListOut.Properties.Add("Simulated");

            Inputs = new List<Resource>();
            Inputs.Add(ListIn);
            Outputs = new List<Resource>();
            Outputs.Add(ListOut);
        }

        public Resource ListIn { get; set; }

        public Resource ListOut { get; set; }

        public List<Resource> Inputs { get; set; }

        public List<Resource> Outputs { get; set; }

        public override List<Resource> In()
        {
            return Inputs;
        }

        public override Context Logic(Context context)
        {
            Resource listResource = context.GetResource(ListIn);
            List<T> list = (List<T>)(listResource.Object);

            for(int i1 = 0; i1 < list.Count; i1++)
            {
                var st1 = (Simulatable)(list[i1]);

                var cxd = cx - st1.X;
                var cyd = cy - st1.Y;
                var cd = Math.Sqrt(cxd * cxd + cyd * cyd);

                if(cd > 75)
                {
                    if(cxd != 0)
                        st1.Xt += cxd / Math.Abs(cxd);
                    if (cyd != 0)
                        st1.Yt += cyd / Math.Abs(cyd);
                }

                for (int i2 = 0; i2 < list.Count; i2++)
                {
                    var st2 = (Simulatable)(list[i2]);

                    var xd = st2.X - st1.X;
                    var yd = st2.Y - st1.Y;
                    var d = Math.Sqrt(xd * xd + yd * yd);

                    if (d <= 50)
                    {
                        if (xd != 0)
                        {
                            st2.Xt += xd / (Math.Abs(xd)) * .1;
                        }
                        if( yd != 0)
                        {
                            st2.Yt += yd / (Math.Abs(yd)) * .1;
                        }
                    }
                }
            }

            for (int i1 = 0; i1 < list.Count; i1++)
            {
                var st1 = (Simulatable)(list[i1]);

                st1.X += st1.Xt;
                st1.Xt = 0;

                st1.Y += st1.Yt;
                st1.Yt = 0;
            }

            listResource.Properties.Add("Simulated");

            return context;
        }

        public override List<Resource> Out()
        {
            return Outputs;
        }
    }
}
