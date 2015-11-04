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
        public int count = 0;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            //first = new SinglyLinkedListNode(values[0].ToString());
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != null)
                {
                    AddLast(values[i].ToString());
                }
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set { throw new NotImplementedException();
                    // NodeAt(i).Value = value; (only works because Node is a trivial object)
            }
        }

        public void AddAfter(string existingValue, string value)
        {
           /* if (last.Value == existingValue)
            {
                AddLast(value);
            } */
            SinglyLinkedListNode adding = new SinglyLinkedListNode(value);
            SinglyLinkedListNode test = first;
            while (true) {
                if (test == null)
                {
                    throw new ArgumentException();
                }
                if (test != null)
                {
                    if (test.Value == existingValue)
                    {
                        adding.Next = test.Next;
                        test.Next = adding;
                        count++;
                        break;
                    }
                    test = test.Next;
                } 
            }
        }

        public void AddFirst(string value)
        {
            if (first == null)
            {
                first = new SinglyLinkedListNode(value);
                first.Next = null;
                count++;

                // or AddLast(value);
            } else
            {
                SinglyLinkedListNode middle = first;
                first = new SinglyLinkedListNode(value);
                first.Next = middle;
                count++;
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

            count++;

            
            //if there's an old last, make the old last != true
            
                   
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {

            return count; 
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

            //return NodeAt(index).Value;
            // so, um, create a NodeAt() method, utility method should help with the listbracket assignment setter
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

            SinglyLinkedListNode Current_node = first;
            int position = 0;
            bool found = false;
            if (first.Value == null)
            {
                position = -1;
            }
            else
            {
                while (!Current_node.IsLast())
                {
                    if (value == Current_node.Value)
                    {
                        found = true;
                        break;
                    }
                    Current_node = Current_node.Next;
                    position++;
                }
                if (!found)
                {
                    position = -1;
                }
            }
            return position;
        }

        public bool IsSorted()
        {
            if (Count() == 0)
            {
                return true;
            }
            SinglyLinkedListNode left = first;
            SinglyLinkedListNode right = first.Next;

            while (right != null)
            {
                  if (left > right)
                {
                    return false;
                }

                left = right;
                right =left.Next;
            }

          

            return true;
          
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
            int position = IndexOf(value);
            if (position >= 0)
            {

                if (position == 0)
                {
                    first = first.Next;
                    count--;
                } //else if (position >= 1 && !NodeAt(position).IsLast())
                  //{
                throw new NotImplementedException();
                //NodeAt(position -1).Next = NodeAt(IndexOf(value) + 1);


                // }else if (NodeAt(position).IsLast() )
                //{
                //count --;
                //}
            }

        }

        public void Sort() // use at least 2 algorithms (quick sort, bubble sort, merge sort, insertion/selection sort)
        {
            if (Count() == 0)
            {
                return;
            }
 
            SinglyLinkedListNode left = first;
            SinglyLinkedListNode right = first.Next;
            bool swapOccured = false;
            while (right != null)
            {
                if (left > right)
                {
                    //nodes ought to be swapped
                    string value = left.Value;
                    left.Value = right.Value;
                    right.Value = value;
                    swapOccured = true;
                }

                left = right;
                right = left.Next;
            }
           if(swapOccured)
           {
                Sort();
           }



        }

        public string[] ToArray()
        {
            if (first == null)
            {
                return new string[] { };
            }

            List<string> result = new List<string>();
            result.Add(first.Value);
            SinglyLinkedListNode node = first.Next;
            while (node != null)
            {
                result.Add(node.Value);
                node = node.Next;
            }
            return result.ToArray();
            /* SinglyLinkedListNode node = first;
            int length = 1;
            while(!node.IsLast())
            {
                length++;
                node = node.Next;
            }
            string[] answr = new string[length];
            for (int i = 0; i < length; i++)
            {
                answer[i] = ElementAt(i);
            }
            return answer; */


        }

        public override string ToString()
        {
            if (first == null)
            {
                return "{ }";
            } 
            StringBuilder LLToString = new StringBuilder("{ ");
            LLToString.Append("\"" + first.Value + "\"");
            SinglyLinkedListNode node = first.Next;
            while (node != null)
            {
                LLToString.Append(", \"" + node.Value + "\"");
                node = node.Next;
            }
                LLToString.Append(" }");
                return LLToString.ToString();
        }
    }
}
