using Microsoft.Extensions.DependencyInjection;

namespace Gabfest.Data;

public static class Register
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
    }

}
