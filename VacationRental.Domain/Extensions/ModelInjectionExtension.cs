using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Models;

namespace VacationRental.Domain.Extensions
{
    public static class ModelInjectionExtension
    {
        public static void AddRentalViewModel(this IServiceCollection services)
        {
            services.AddSingleton<IDictionary<int, RentalViewModel>>(new Dictionary<int, RentalViewModel>());
        }
        public static void AddBookingViewModel(this IServiceCollection services)
        {
            services.AddSingleton<IDictionary<int, BookingViewModel>>(new Dictionary<int, BookingViewModel>());
        }
    }
}
