using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeNet
{
    public class Weaver
    {
        private List<Middleware> _middleware;
        private Node _root;
        private List<Resource> _input;
        private List<Resource> _output;

        public Weaver(List<Middleware> middleware, List<Resource> input, List<Resource> output)
        {
            _middleware = middleware;
            _root = new Node();
            _input = input;
            _output = output;
        }

        private Value Build(Middleware middleware, List<Resource> built)
        {
            List<Resource> updated = Clone(built);
            AddAll(updated, middleware.Out());

            var value = new Value()
            {
                Node = new Node()
                {
                    Middleware = middleware
                },
                Completed = Completed(updated),
                Missing = Missing(middleware, built)
            };

            if(value.Missing == 0 && value.Completed == _output.Count)
            {
                return value;
            }

            List<Value> values = new List<Value>();
            foreach (Middleware m in _middleware)
            {
                updated = Clone(built);
                AddAll(updated, middleware.Out());
                values.Add(Build(m, updated));
            }

            values = Sort(values);
        }

        private List<Value> Sort(List<Value> values)
        {
            return values.OrderBy(v => v.Completed - v.Missing).ToList();
        }

        private class Value
        {
            public Node Node { get; set; }

            public int Completed { get; set; }

            public int Missing { get; set; }

        }

        private int Missing(Middleware middleware, List<Resource> built)
        {
            int missing = 0;

            foreach(Resource r in middleware.In())
            {
                if (!built.Contains(r))
                {
                    missing++;
                }
            }

            return missing;
        }

        private int Completed(List<Resource> built)
        {
            int value = 0;
            
            foreach(Resource r in _output)
            {
                if (built.Contains(r))
                {
                    value++;
                }
            }

            return value;
        }

        private static List<Resource> Clone(List<Resource> other)
        {
            List<Resource> c = new List<Resource>();
            AddAll(c, other);
            return c;
        }

        private static void RemoveAll(List<Resource> dst, List<Resource> rem)
        {
            foreach(Resource r in rem)
            {
                dst.Remove(r);
            }
        }

        private static void AddAll(List<Resource> dst, List<Resource> add)
        {
            foreach(Resource r in add)
            {
                dst.Add(r);
            }
        }

        public Context Execute(Context context)
        {
            return _root.Run(context);
        }

    }
}
