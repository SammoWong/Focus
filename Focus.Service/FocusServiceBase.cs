using Focus.Domain;

namespace Focus.Service
{
    public abstract class FocusServiceBase
    {
        protected FocusDbContext NewDbContext() => new FocusDbContext();
    }
}
