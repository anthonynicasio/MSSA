namespace _6._3
{
    internal class Program
    {
        static void Main()
        {
            var callQueue = new LinkedQueue<Caller>();

            // Enqueue callers
            callQueue.Enqueue(new Caller(101, "Ava Martinez", "Billing question"));
            callQueue.Enqueue(new Caller(102, "Ben Chen", "Account locked"));
            callQueue.Enqueue(new Caller(103, "Priya Singh", "Technical support"));
            callQueue.Enqueue(new Caller(104, "Liam Johnson", "Cancel service"));

            Console.WriteLine("Current queue (front to back):");
            foreach (var caller in callQueue)
            {
                Console.WriteLine("  " + caller);
            }

            Console.WriteLine();

            // Peek at the next caller
            Console.WriteLine("Next to be served: " + callQueue.Peek());

            // Dequeue a couple of callers
            var served1 = callQueue.Dequeue();
            Console.WriteLine("Served: " + served1);

            var served2 = callQueue.Dequeue();
            Console.WriteLine("Served: " + served2);

            Console.WriteLine();

            Console.WriteLine("Queue after serving two callers:");
            foreach (var caller in callQueue)
            {
                Console.WriteLine("  " + caller);
            }

            Console.WriteLine();
            Console.WriteLine($"Remaining in queue: {callQueue.Count}");
        }
    }
}
