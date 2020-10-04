using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public interface INode<K>
    {
        K Value { get; set; }
    }
}
