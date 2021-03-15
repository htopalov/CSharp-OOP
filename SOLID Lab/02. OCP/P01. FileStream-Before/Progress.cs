namespace P01._FileStream_Before
{
    public class Progress
    {
        private readonly ISentable item;

        public Progress(ISentable item)
        {
            this.item = item;
        }

        public int CurrentPercent()
        {
            return this.item.Sent * 100 / this.item.Length;
        }
    }
}
