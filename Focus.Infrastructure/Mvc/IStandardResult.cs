namespace Focus.Infrastructure.Mvc
{
    public interface IStandardResult
    {
        bool State { get; set; }

        string Message { get; set; }

        void Succeed();

        void Fail();

        void Succeed(string message);

        void Fail(string message);
    }

    public interface IStandardResult<T> : IStandardResult
    {
        T Data { get; set; }
    }
}
