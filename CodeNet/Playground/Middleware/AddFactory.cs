using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeNet;
using Playground.Resources;

namespace Playground.Middleware
{
    public class AddFactory<T> : CodeNet.Middleware where T : new()
    {
        public override List<Resource> In()
        {
            return inputs;
        }

        public override Context Logic(Context context)
        {
            context.AddResource(Fac, new Factory());
            return context;
        }

        public override List<Resource> Out()
        {
            return outputs;
        }

        private static Resource Fac = new Resource() { Type = typeof(IFactory<T>) };

        private class Factory : IFactory<T>
        {
            public T Create()
            {
                return new T();
            }
        }

        private static List<Resource> inputs = CreateInputs();

        private static List<Resource> outputs = CreateOutputs();

        public static List<Resource> CreateInputs()
        {
            List<Resource> ins = new List<Resource>();
            return ins;
        }

        public static List<Resource> CreateOutputs()
        {
            List<Resource> outs = new List<Resource>();
            outs.Add(Fac);
            return outs;
        }

    }
}
