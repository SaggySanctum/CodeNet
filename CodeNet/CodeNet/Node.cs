using System.Collections.Generic;

namespace CodeNet
{
    public class Node
    {
        List<Node> Children { get; set; }

        Middleware Middleware { get; set; }

        public Context Run(Context context)
        {
            Middleware.Run(context);

            foreach(Node node in Children)
            {
                context = node.Run(context);
            }

            return context;
        }
    }
}
