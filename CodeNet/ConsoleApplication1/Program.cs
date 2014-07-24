using CodeNet;
using Playground.Middleware;
using Playground.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Context context = new Context();

            // Simulated middleware chain
            // var init = Weaver.Build(requirements...)
            var addFactory = new AddFactory<Thing>();
            var addList = new AddList<Thing>();
            // var loop = Weaver.Build(requirements....)
            var physics = new Physics<Thing>();
            var render = new Render<Thing>();

            // init.Execute(context)
            addFactory.Logic(context);
            addList.Logic(context);
            while (true)
            {
                // init.Loop(context)
                physics.Logic(context);
                render.Logic(context);
                var end = context.GetResource(render.ListOut);
                end.Properties.Remove("Rendered");
                Thread.Sleep(50);
            }

        }

        private class Thing : Simulatable
        {
            public static Random rand = new Random();

            public Thing()
            {
                X = rand.Next(750);
                Y = rand.Next(500);
            }

            public double X { get; set; }

            public double Y { get; set; }

            public double Xt { get; set; }

            public double Yt { get; set; }
        }
    }
}
