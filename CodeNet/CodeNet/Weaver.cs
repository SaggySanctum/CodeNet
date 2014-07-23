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
        private List _middlewareExe;
        private List<Resource> _input;
        private List<Resource> _output;

        public Weaver(List<Middleware> middleware, List<Resource> input, List<Resource> output)
        {
            _middleware = middleware;
            _input = input;
            _output = output;

            public List<Middleware> standAlone;
            public List<Middleware> notStandAlone;

            // Determines the stand alone middleware
            foreach(Middleware availableMiddleware in _middleware)
            {
                if(availableMiddleware.In().length == 0)
                {
                    standAlone.Add(availableMiddleware);
                }
                else
                {
                    notStandAlone.Add(availableMiddleware);
                }
            }

            // Create the list
            while(output.length != 0)
            {
                // Costs the least so its easiest to check these first
                foreach(Middleware standAloneMiddleware in standAlone)
                {
                    var middlewareUsed = false;
                    foreach(Resource availableOutput in standAloneMiddleware.Out())
                    {
                        Resource requirementToRemove;
                        foreach(Resource requiredOutput in _output)
                        {   
                            if(availableOutput.equals(requiredOutput))
                            {
                                requirementToRemove = requiredOutput;
                                middlewareUsed = true;
                                break;
                            }
                        }
                        if(requirementToRemove != undefined)
                        {
                            _output.Remove(requirementToRemove);
                        }
                    }
                    if(middlewareUsed)
                    {
                        _middlewareExe.Add(standAloneMiddleware);
                        foreach(Resourse newResourse in standAloneMiddleware.Out())
                        {
                            _input.Add(newResourse);
                        }
                    }
                    if(output.length == 0)
                    {
                        break;
                    }
                }

                // Combine Middleware so thatyou can use the one that are not standAlone -- assuming we need more middleware
                if(output.length =! 0)
                {
                    foreach(Middleware multi in notStandAlone)
                    {
                        var requirementToRemove;
                        foreach(Resource needed in _output)
                        {
                            if(multi.has(needed))
                            {
                                foreach(Middleware single in standAlone)
                                {
                                    foreach(Resource giving in single.Out())
                                    {
                                        foreach(Resource taking in multi.In())
                                        {
                                            if(giving.equals(taking))
                                            {
                                                if(!_middlewareExe.contains(multi))
                                                {
                                                    _middlewareExe.Add(multi);
                                                }
                                                if(!_middlewareExe.contains(single))
                                                {
                                                    _middlewareExe.Add(single);
                                                }
                                                requirementToRemove = needed;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if(requirementToRemove != undefined)
                        {

                        }
                    }
                }
            }
        }

        public List<Resource> ResoursesUsed(List<Middleware> target)
        {
            List<Resource> inputsAvailable = _input;
            List<Resource> outputsToSatisfy = _output;
            List<Resource> outputsSatisfied;

            foreach(middlewareAvailible in target)
            {
                cost++;
                // Checks to ensure that I can use this resourse at all
                var canUseThisResourse = true;
                if(middlewareAvailible.In().count != 0)
                {
                    foreach(Resource reqiredInput in middlewareAvailible.In())
                    {
                        foreach(Resource givenInput in _input)
                        {
                            var fulfilled = false;
                            if(reqiredInput.equals(givenInput))
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
                        foreach(neededOutput in outputsToSatisfy)
                        {
                            if(output.equals(neededOutput))
                            {
                                outputsSatisfied.Add(output);
                                break;
                            }
                        }
                    }
                }
            }
            return outputsSatisfied;
        }

        public int cost(List<Middleware> target, List<Resource> outputsSatisfied)
        {
            return target.length - outputsSatisfied.length;
        }

        public Context Execute(Context context)
        {
            foreach(middleware in _middlewareExe)
            {
                middleware.Run(context);
            }
        }

    }
}
