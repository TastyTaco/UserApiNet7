namespace UserApiNet7.Services.UserService
{
	public interface IUserService
	{
        Task<List<User>> GetAllUsers();
		Task<User> GetUserById(int id);
		Task<User> CreateUser(User user);
	}
}
