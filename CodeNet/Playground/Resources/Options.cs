using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Resources
{
    public interface IOptionsAccessor
    {
        Option<V> GetOptions<V>(Option<V> type);
    }

    public class Option<V>
    {
        public Type Type { get; set; }

        public V Value { get; set; }
    }
}
