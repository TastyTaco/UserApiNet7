using Serilog;

namespace UserApiNet7.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(UserDbContext dbContext, ILogger<UserService> logger)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                Log.Information("User has been created: {@user}", user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while creating a user");
                throw; 
            }

            return await GetUserById(user.UserId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users
                .Include(u => u.Address)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving users");
                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.UserId == id);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving user with id: {@Id}", id);
                throw;
            }
        }
    }
}
