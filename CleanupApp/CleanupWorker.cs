namespace CleanupApp
{
    public class CleanupWorker
    {
        private readonly IRepository _repository;

        public CleanupWorker(IRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string identifier)
        {
            // As this is clean up task we can do it without awaiting
            // It can be like execute and forget.
            // We use this kind of approach for archieving the records.
            this._repository.Cleanup(identifier);
        }
    }
}
