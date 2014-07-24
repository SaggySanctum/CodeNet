using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeNet;
using Playground.Resources;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace Playground.Middleware
{
    public class Render<T> : CodeNet.Middleware
    {
        public RenderForm form;
        public Thread thread;

        public Render()
        {
            ListIn = new Resource();
            ListIn.Type = typeof(List<T>);
            ListIn.Properties.Add("Simulated");

            ListOut = new Resource();
            ListOut.Type = typeof(List<T>);
            ListOut.Properties.Add("Rendered");

            Inputs = new List<Resource>();
            Inputs.Add(ListIn);
            Outputs = new List<Resource>();
            Outputs.Add(ListOut);

            form = new RenderForm();

            thread = new Thread(Runner.Run);
            thread.Start(form);
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
            listResource.Properties.Remove("Simulated");
            IEnumerable<Simulatable> list = (IEnumerable<Simulatable>)(listResource.Object);

            form.Draw(list);

            listResource.Properties.Add("Rendered");
            return context;
        }

        public override List<Resource> Out()
        {
            return Outputs;
        }
    }
    
    public static class Runner
    {
        public static void Run(object o)
        {
            Application.Run((Form)o);
        }
    }
}
