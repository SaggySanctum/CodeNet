using System;
using System.Collections.Generic;

namespace CodeNet
{
    public class Resource
    {
        public string Name { get; set; }

        public object Object { get; set; }

        public Type Type { get; set; }

        public override bool Equals(object obj)
        {
            if (!obj.GetType().Equals(typeof(Resource)))
            {
                return base.Equals(obj);
            }

            var robj = (Resource)obj;

            if (!robj.Name.Equals(Name))
            {
                return false;
            }

            if (!robj.Type.Equals(Type))
            {
                return false;
            }

            return true;
        }
    }
}
