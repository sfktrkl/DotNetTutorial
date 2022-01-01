namespace Tutorial.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}