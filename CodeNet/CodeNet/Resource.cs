using System;
using System.Collections.Generic;

namespace CodeNet
{
    public class Resource
    {
        public static Resource NotFound = new Resource() { Name = "NotFound" };

        public Resource()
        {
            Properties = new List<Object>();
        }

        public string Name { get; set; }

        public object Object { get; set; }

        public Type Type { get; set; }

        public List<object> Properties { get; set; }

        public override bool Equals(object obj)
        {
            if (!obj.GetType().Equals(typeof(Resource)))
            {
                return base.Equals(obj);
            }

            var robj = (Resource)obj;

            if (!robj.Type.Equals(Type))
            {
                return false;
            }


            // TODODODODODODODO fix
            foreach (object property in robj.Properties)
            {
                if (!Properties.Contains(property))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
