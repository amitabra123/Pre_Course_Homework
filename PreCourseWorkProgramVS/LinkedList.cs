using System.Collections.Generic;

namespace PreCourseWorkProgramVS
{
    public class LinkedList
    {
        public Node Head;
        private Node lastNode;
        private Node maxNode;
        private Node minNode;

        public LinkedList(int value)
        {
            Head = new Node (value,null);
            lastNode = Head;
            maxNode = Head;
            minNode = Head;
        }

        public void Append(int newValue) 
        {
            Node newNode = new Node(newValue, null);
            lastNode.Next = newNode;
            lastNode = newNode;
            CheckMaxOrMin(newNode);
        }

        public void Prepend(int newValue)
        {
            if (Head == null)
            {
                Head = new Node(newValue,null);
                return;
            }
            Node firstNode = new Node(newValue,Head);
            Head = firstNode;
            CheckMaxOrMin(firstNode);
        }


        private void CheckMaxOrMin(Node addNewNode)
        {
            if (addNewNode.Value > maxNode.Value)
            {
                maxNode = new Node(addNewNode.Value, null);
            }
            else if (addNewNode.Value < minNode.Value)
            {
                minNode = new Node(addNewNode.Value, null);
            }
        }

        private Node UpdateMaxNode()
        {
            int newMaxValueInList = Head.Value;
            Node newMaxNodeInList = new Node(Head.Value, null);
            Node checkMaxInList = Head;
            while(checkMaxInList != null)
            {
                if(checkMaxInList.Value > newMaxValueInList)
                {
                    newMaxValueInList = checkMaxInList.Value;
                    newMaxNodeInList = checkMaxInList;
                }
                checkMaxInList = checkMaxInList.Next;
            }
            return newMaxNodeInList;
        }

        private Node UpdateMinNode()
        {
            int newMinValueInList = Head.Value;
            Node newMinNodeInList = new Node(Head.Value, null);
            Node checkMinInList = Head;
            while (checkMinInList != null)
            {
                if (checkMinInList.Value < newMinValueInList)
                {
                    newMinValueInList = checkMinInList.Value;
                    newMinNodeInList = checkMinInList;
                }
                checkMinInList = checkMinInList.Next;
            }
            return newMinNodeInList;
        }


        public int Pop()
        {
            Node nodesInTheList = Head;
            while (nodesInTheList.Next.Next != null)
                nodesInTheList = nodesInTheList.Next;
            int lastInList = nodesInTheList.Next.Value;
            Node checkMaxOrMinNode = nodesInTheList.Next;
            nodesInTheList.Next = null;
            if (checkMaxOrMinNode.Value == maxNode.Value)
            {
                maxNode = UpdateMaxNode();
            }
            else if (checkMaxOrMinNode.Value == minNode.Value)
            {
                minNode = UpdateMinNode();
            }
            return lastInList;
        }

        public int Unqueue()
        {
            Node firstNodeInList = Head;
            int firstInList = firstNodeInList.Value;
            Node checkMaxOrMinNode = firstNodeInList;
            Head = firstNodeInList.Next;
            if (checkMaxOrMinNode.Value == maxNode.Value)
            {
                maxNode = UpdateMaxNode();
            }
            else if (checkMaxOrMinNode.Value == minNode.Value)
            {
                minNode = UpdateMinNode();
            }
            return firstInList;
        }

        public IEnumerator<int> ToList()
        {
            Node nodesInTheList = Head;
            while (nodesInTheList != null)
            {
                yield return nodesInTheList.Value;
                nodesInTheList = nodesInTheList.Next;
            }
        }

        public bool IsCircular()
        {
            Node nodesInTheList = Head;
            Node firstNodeInList = Head;
            while (nodesInTheList!= null)
            {
                if (nodesInTheList.Next == firstNodeInList)
                    return true;
                nodesInTheList = nodesInTheList.Next;
            }
            return false;
        }

        public void Sort()
        {
            Node nodesInTheList = Head; 
            Node nextNode; 
            int tempSortValue;
            if (nodesInTheList == null)
                return;
            while (nodesInTheList != null)
            {
                nextNode = nodesInTheList.Next;
                while(nextNode != null)
                {
                    if(nodesInTheList.Value > nextNode.Value)
                    {
                        tempSortValue = nodesInTheList.Value;
                        nodesInTheList.Value = nextNode.Value;
                        nextNode.Value = tempSortValue;
                    }
                    nextNode = nextNode.Next;
                }
                nodesInTheList = nodesInTheList.Next;
            }
        }

        public Node GetMaxNode()
        {
            return maxNode;
        }

        public Node GetMinNode()
        {
            return minNode;
        }
    }
}