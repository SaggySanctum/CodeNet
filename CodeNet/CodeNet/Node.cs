﻿using System.Collections.Generic;

namespace CodeNet
{
    public class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }

        public List<Node> Children { get; set; }

        public Middleware Middleware { get; set; }

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
