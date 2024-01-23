internal class CircularLinkedList
{
    public Node head;

    public CircularLinkedList()
    {
        head = null;
    }

    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            head.Next = head;
            head.Previous = head;
        }
        else
        {
            Node lastNode = head.Previous;

            newNode.Next = head;
            newNode.Previous = lastNode;

            lastNode.Next = newNode;
            head.Previous = newNode;
        }
    }

    public int Forward()
    {
        if (head == null)
        {
            Debug.LogError("Circular Linked List is empty!");
            return 0;
        }

        Node current = head;
        current = current.Next;
        head = current;
        return current.Data;
    }

    public int Backward()
    {
        if (head == null)
        {
            Debug.LogError("Circular Linked List is empty!");
            return 0;
        }

        Node current = head.Previous;
        do
        {
            current = current.Previous;
        } while (current != head.Previous);

        head = current;
        return current.Data;
    }

}

public record Node(int Data)
{
    public int Data { get; set; } = Data;
    public Node Next { get; set; } = null;
    public Node Previous { get; set; } = null;
}