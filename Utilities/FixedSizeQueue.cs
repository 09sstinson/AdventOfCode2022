using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FixedSizeQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        private readonly int _size;

        public FixedSizeQueue(int size){
            _size = size;
        }

        public void Enqueue(T value)
        {
            _queue.Enqueue(value);

            if(_queue.Count > _size)
            {
                _queue.Dequeue();
            }
        }

        public bool IsDistinct()
        {
            return _queue.Distinct().Count() == _size;
        }
    }
}
