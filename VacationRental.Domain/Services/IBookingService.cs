using VacationRental.Domain.Models;

namespace VacationRental.Domain.Services
{
    public interface IBookingService
    {
        BookingViewModel Get(int bookingId);
        ResourceIdViewModel Add(BookingBindingModel model);
    }
}