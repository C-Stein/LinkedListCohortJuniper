using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
        //I read the instsructions
    {
        private SinglyLinkedListNode first;
        private SinglyLinkedListNode last;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            if (first == null)
            {
                first = new SinglyLinkedListNode(value);
            } else
            {
                //??
            }
        }

        public void AddLast(string value)
        {
            
            if (last == null)
            {
                last = new SinglyLinkedListNode(value);
                first = last;
                last.Next = null;
            } else
            {
                SinglyLinkedListNode middle = last;
                last = new SinglyLinkedListNode(value);
                middle.Next = last;
            }

            
            //if there's an old last, make the old last != true
            
                   
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            if ( first == null) {
                throw new ArgumentOutOfRangeException("There's no item there");
            }
            index = Math.Abs(index);
            if (index == 0) //combine this with the following loop once you get the other stuff to work
            {
                return first.Value;
            } else if (index > 0)
            {
                SinglyLinkedListNode result = first.Next;
                for (int i = 1; i < index; i++)
                {
                    result = result.Next;
                    if (result == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                    return result.Value;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string First()
        {
            if (first == null)
            {
                return null;
            }
            else
            {
                return first.Value;
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (last !=  null)
            {
                return last.Value;
            } else
            {
                return null;
            }
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (first == null)
            {
                return "{ }";
            } 
            StringBuilder LLToString = new StringBuilder("{ ");
            LLToString.Append("\"" + first.Value + "\"");
            if (first.Next != null)
            {
                LLToString.Append(", \"" + first.Next.Value + "\"");
            } else
            {
                LLToString.Append(" }");
                return LLToString.ToString();
            }
            if (first.Next.Next != null)
            {
                LLToString.Append(", \"" + first.Next.Next.Value + "\"");
            }
            LLToString.Append(" }");
            return LLToString.ToString();
          
        }
    }
}
