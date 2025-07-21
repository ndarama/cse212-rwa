using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue ("A", 2), ("B", 5), ("C", 3). Dequeue all.
    // Expected Result: "B", "C", "A"
    // Defect(s) Found: None
    public void TestPriorityQueue_PriorityOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue ("X", 2), ("Y", 2), ("Z", 1). Dequeue all. [FIFO for ties]
    // Expected Result: "X", "Y", "Z"
    // Defect(s) Found: None
    public void TestPriorityQueue_FIFOOnTies()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 2);
        pq.Enqueue("Y", 2);
        pq.Enqueue("Z", 1);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyDequeueThrows()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}