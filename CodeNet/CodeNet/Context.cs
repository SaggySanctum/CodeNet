using System.Collections.Generic;

namespace CodeNet
{
    public class Context
    {
        public List<object> Resources { get; set; }

        public Resource GetResource(Resource target)
        {
            foreach(object resource in Resources)
            {
                if (target.Equals(resource))
                {
                    return (Resource)resource;
                }
            }

            return Resource.NotFound;
        }
    }
}
