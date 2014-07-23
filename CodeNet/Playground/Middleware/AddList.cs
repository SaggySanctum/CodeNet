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
            int count = context.
            List<T> list = new List<T>();

        }

        public override List<Resource> Out()
        {
            return outputs;
        }

        private static List<Resource> inputs = CreateInputs();

        private static List<Resource> outputs = CreateOutputs();

        public static List<Resource> CreateInputs()
        {
            List<Resource> ins = new List<Resource>();
            ins.Add(new Resource() { Type = typeof(IFactory<T>) });
            // options hacky, need solution with type and properties
            ins.Add(new Resource() { Type = typeof(Option<ListOption>) });
            return ins;
        }

        public static List<Resource> CreateOutputs()
        {
            List<Resource> outs = new List<Resource>();
            outs.Add(new Resource() { Type = typeof(List<T>) });
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
