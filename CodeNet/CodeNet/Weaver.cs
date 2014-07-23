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

        public int Cost(List<Middleware> target, _input, _output)
        {
            int cost = 0;

            foreach(step in target)
            {

            }

        }

        public Context Execute(Context context)
        {
            return _root.Run(context);
        }

    }
}
