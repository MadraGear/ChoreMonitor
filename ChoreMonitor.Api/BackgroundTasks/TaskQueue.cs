namespace ChoreMonitor.Api.BackgroundTasks
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public interface ITaskQueue
    {
        void Enqueue(string item);
        IEnumerable<string> GetConsumingEnumerable();
    }
    public class TaskQueue : ITaskQueue
    {
        private readonly BlockingCollection<string> _blockingCollection = new BlockingCollection<string>();

        public void Enqueue(string item)
        {
            _blockingCollection.Add(item);
        }

        public IEnumerable<string> GetConsumingEnumerable()
        {
            return _blockingCollection.GetConsumingEnumerable();
        }
    }
}