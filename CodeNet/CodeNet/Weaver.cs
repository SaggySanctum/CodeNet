using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeNet
{
    public class Weaver
    {
        private HashSet<Middleware> _middleware;
        private Node _root;
        private Context _input;
        private Context _output;

        public Weaver(HashSet<Middleware> middleware, Context input, Context output)
        {
            _middleware = middleware;
            _root = new Node();
            _input = input;
            _output = output;
        }

        public int MoveRank(Middleware next)
        {
            int rank = 0;

            for(Resource resource in next.Out)
            {

            }
        }

        private class Move
        {
            public int Rank { get; set; }

            public HashSet<Resource> Before { get; set; }

            public HashSet<Resource> After { get; set; }
        }

    }
}
