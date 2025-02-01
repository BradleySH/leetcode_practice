public class DesignLinkedList
{
    public class MyLinkedList
    {
        private ListNode? head;
        private ListNode? tail;
        private int size;

        public MyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        // Get the value of the index-th node (0-based). If index is invalid, return -1
        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;

            ListNode? current = GetNode(index);
            return current?.val ?? -1;
        }

        public void AddAtHead(int val)
        {
            ListNode newNode = new ListNode(val, null, head);
            if (head != null)
                head.prev = newNode;

            head = newNode;
            if (tail == null)
                tail = newNode;

            size++;
        }

        public void AddAtTail(int val)
        {
            if (tail == null)
            {
                AddAtHead(val);
                return;
            }

            ListNode newNode = new ListNode(val, tail, null);
            tail.next = newNode;
            tail = newNode;
            size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > size) return;

            if (index == 0) { AddAtHead(val); return; }
            if (index == size) { AddAtTail(val); return; }

            ListNode? prevNode = GetNode(index - 1);
            if (prevNode == null) return;

            ListNode? nextNode = prevNode.next;
            ListNode newNode = new ListNode(val, prevNode, nextNode);

            prevNode.next = newNode;
            if (nextNode != null)
                nextNode.prev = newNode;

            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size) return;

            if (index == 0) // Delete head
            {
                head = head?.next;
                if (head != null)
                    head.prev = null;
                else
                    tail = null;
            }
            else if (index == size - 1) // Delete tail
            {
                tail = tail?.prev;
                if (tail != null)
                    tail.next = null;
            }
            else
            {
                ListNode? nodeToDelete = GetNode(index);
                if (nodeToDelete == null) return;

                ListNode? prevNode = nodeToDelete.prev;
                ListNode? nextNode = nodeToDelete.next;

                if (prevNode != null) prevNode.next = nextNode;
                if (nextNode != null) nextNode.prev = prevNode;
            }

            size--;
        }

        private ListNode? GetNode(int index)
        {
            if (index < 0 || index >= size) return null;

            ListNode? current;
            if (index < size / 2) // start from head
            {
                current = head;
                for (int i = 0; i < index; i++)
                    current = current?.next;
            }
            else // start from tail
            {
                current = tail;
                for (int i = size - 1; i > index; i--)
                    current = current?.prev;
            }

            return current;
        }

        public void PrintList()
        {
            ListNode? current = head;
            while (current != null)
            {
                Console.Write(current.val + " <-> ");
                current = current.next;
            }
            Console.WriteLine("null");
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode? prev;
        public ListNode? next;

        public ListNode(int val)
        {
            this.val = val;
            this.prev = null;
            this.next = null;
        }

        public ListNode(int val = 0, ListNode prev = null, ListNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }



}