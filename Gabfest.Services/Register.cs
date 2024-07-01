using Microsoft.Extensions.DependencyInjection;

namespace Gabfest.Services;

public static class Register
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IGroupService, GroupService>();
    }

}
