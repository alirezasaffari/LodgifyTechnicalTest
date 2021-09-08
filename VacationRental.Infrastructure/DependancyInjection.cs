using Microsoft.Extensions.DependencyInjection;
using VacationRental.Infrastructure.Extensions;

namespace VacationRental.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddBookingService();
            services.AddCalendarService();
            services.AddRentalService();
            return services;
        }
    }
}
