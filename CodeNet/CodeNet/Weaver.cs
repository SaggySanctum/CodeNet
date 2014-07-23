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

        public List<string> Cost(List<Middleware> target)
        {
            List<string> result;
            int cost = 0;
            List<Resource> inputsAvailable = _input;
            List<Resource> outputsToSatisfy = _output;

            foreach(middlewareAvailible in target)
            {
                cost++;
                // Checks to ensure that I can use this resourse at all
                var canUseThisResourse = true;
                if(middlewareAvailible.In().count != 0)
                {
                    foreach(reqiredInput in middlewareAvailible.In())
                    {
                        foreach(givenInput in _input)
                        {
                            var fulfilled = false;
                            if(reqiredInput == givenInput)
                            {
                                fulfilled = true;
                                break;
                            }
                        }

                        if(!fulfilled)
                        {
                            canUseThisResourse = false;
                            break;
                        }
                    }
                }

                // Check to see if you fulfill outputs
                if(canUseThisResourse){
                    foreach(output in middlewareAvailible.Out())
                    {
                        
                    }
                }
            }

        }

        public Context Execute(Context context)
        {
            return _root.Run(context);
        }

    }
}
