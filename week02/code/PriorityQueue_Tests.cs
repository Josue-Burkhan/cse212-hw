using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and remove one.
    // Expected Result: The item with the highest priority should be returned.
    // Defect(s) Found: Dequeue removed last inserted with highest priority instead of first.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        string result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The item that was inserted first among them should be returned.
    // Defect(s) Found: Dequeue returned the last matching priority instead of the first.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 10);
        pq.Enqueue("Y", 10);
        pq.Enqueue("Z", 1);

        string result = pq.Dequeue();

        Assert.AreEqual("X", result); // FIFO tie-breaker
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: InvalidOperationException should be thrown.
    // Defect(s) Found: None.
    public void TestPriorityQueue_EmptyDequeue()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items, dequeue all, ensure they are returned in correct order.
    // Expected Result: Returned values should respect priority and FIFO among ties.
    // Defect(s) Found: Dequeue incorrectly returns last matching priority in ties.
    public void TestPriorityQueue_DequeueAll()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 2);

        Assert.AreEqual("B", pq.Dequeue()); // 5 - B before C
        Assert.AreEqual("C", pq.Dequeue()); // 5 - C
        Assert.AreEqual("A", pq.Dequeue()); // 3
        Assert.AreEqual("D", pq.Dequeue()); // 2
    }
}
