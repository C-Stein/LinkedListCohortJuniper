﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return next; }
            set { 
                    if (value == this)
                    {
                           throw new ArgumentException();
                     }
                next = value;
            }
        }

        private string value;
        public string Value 
        {
            get { return value; }
            set { this.Value = value; }
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            this.value = value;

            // Used by the visualizer:
            allNodes.Add(this);
        }

        public override string ToString()
        {
            return value;
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            SinglyLinkedListNode otherNode = obj as SinglyLinkedListNode;
            if (otherNode != null)
            {
                return this.value.CompareTo(otherNode.value);
            } else
            {
                throw new ArgumentException("is this a node?");
            }
        }

        public bool IsLast()
        {
            return (Next == null);
        }
        public override bool Equals(object obj)
        {
            //return (this.CompareTo(obj) == 0);
            SinglyLinkedListNode node = obj as SinglyLinkedListNode;
            if (node == null)
            {
                return false;
            } else
            {
                return value.Equals(node.Value);
            }
        }
    }
    
}
