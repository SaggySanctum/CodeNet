using System.Collections.Generic;

namespace CodeNet
{
    public class Context
    {
        public Context()
        {
            Resources = new List<Resource>();
        }

        public List<Resource> Resources { get; set; }

        public Resource GetResource(Resource target)
        {
            foreach (object resource in Resources)
            {
                if (target.Equals(resource))
                {
                    return (Resource)resource;
                }
            }

            return Resource.NotFound;
        }

        public void AddResource(Resource target, object value)
        {
            Resources.Add(new Resource()
            {
                Type = target.Type,
                Properties = target.Properties,
                Object = value
            });
        }
    }
}
