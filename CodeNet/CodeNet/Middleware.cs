using System;
using System.Collections.Generic;

namespace CodeNet
{
    public abstract class Middleware
    {
        public string Name { get; set; }

        public abstract List<Resource> In();
              
        public abstract List<Resource> Out();

        public abstract Context Logic(Context context);

        public Context Run(Context context)
        {
            foreach (Resource rin in In())
            {
                if (!context.Resources.Contains(rin))
                {
                    throw new InvalidOperationException("Resource " + rin.Name + " is declared required but is not present for node " + Name + ".");
                }
            }

            context = Logic(context);

            foreach (Resource rout in Out())
            {
                if (!context.Resources.Contains(rout))
                {
                    throw new InvalidOperationException("Resource " + rout.Name + " is declared provided and is not present for node " + Name + ".");
                }
            }

            return context;
        }

        public bool HasResource(Resource target)
        {
            foreach(Resource output in Out())
            {
                if(output.equals(target))
                {
                    return true;
                }
            }
            return false;
        } 
    }
}
