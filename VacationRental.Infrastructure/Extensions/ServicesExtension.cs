using Microsoft.Extensions.DependencyInjection;
using VacationRental.Domain.Services;
using VacationRental.Infrastructure.Services;

namespace VacationRental.Infrastructure.Extensions
{
    public static class ServicesExtension
    {
        public static void AddBookingService(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
        }
        public static void AddCalendarService(this IServiceCollection services)
        {
            services.AddScoped<ICalendarService, CalendarService>();
        }
        public static void AddRentalService(this IServiceCollection services)
        {
            services.AddScoped<IRentalService, RentalService>();
        }
    }
}
