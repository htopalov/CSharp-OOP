namespace P02._Worker_Before
{
    public class Manager
    {
        public Manager(IWorker worker)
        {
            worker.Work();
        }
    }
}
