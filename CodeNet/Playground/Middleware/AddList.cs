using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeNet;
using Playground.Resources;

namespace Playground.Middleware
{
    public class AddList<T> : CodeNet.Middleware
    {
        public override List<Resource> In()
        {
            return inputs;
        }

        public override Context Logic(Context context)
        {
            int count = 10;
            IFactory<T> factory = (IFactory<T>)(context.GetResource(Factory).Object);

            List<T> list = new List<T>();
            for(int c = 0; c < count; c++)
            {
                list.Add(factory.Create());
            }

            context.AddResource(List, list);

            return context;
        }

        public override List<Resource> Out()
        {
            return outputs;
        }

        private static Resource Factory = new Resource() { Type = typeof(IFactory<T>) };

        private static Resource List = new Resource() { Type = typeof(List<T>) };

        private static List<Resource> inputs = CreateInputs();

        private static List<Resource> outputs = CreateOutputs();

        public static List<Resource> CreateInputs()
        {
            List<Resource> ins = new List<Resource>();
            ins.Add(Factory);
            return ins;
        }

        public static List<Resource> CreateOutputs()
        {
            List<Resource> outs = new List<Resource>();
            outs.Add(List);
            return outs;
        }
    }

    public class ListOption
    {
        public ListOption(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
