using System.Collections.Generic;

namespace CodeNet
{
    public class Context
    {
        public HashSet<Resource> Resources { get; set; }

        public int Distance(Context other)
        {
            int distance = 0;

            for(Resource resource in Resources)
            {
                if (other.Resources.Contains(resource))
                {
                    distance++;
                }
            }

            return distance;
        }
    }
}
