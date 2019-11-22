using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkGraph
{
    public class EList<T>: List<T>
    {
        new public void Add(T add)
        {
            base.Add(add);
            CollectionChanged?.Invoke(this,EventArgs.Empty);
        }

        new public void Remove(T rem)
        {
            base.Remove(rem);
            CollectionChanged?.Invoke(this, EventArgs.Empty);
        }

        public delegate void changed(object sender, EventArgs e);
        public event changed CollectionChanged;
    }
}
