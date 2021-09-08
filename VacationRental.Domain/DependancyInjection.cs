using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Extensions;

namespace VacationRental.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddRentalViewModel();
            services.AddBookingViewModel();
            return services;
        }
    }
}
