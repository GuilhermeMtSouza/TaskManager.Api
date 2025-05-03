namespace TaskManager.Infrastructure.Repositories
{
    public class BaseRepository
    {
        public AppDbContext context { get; }
        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

    }
}
