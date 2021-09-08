using System;
using VacationRental.Domain.Enums;

namespace VacationRental.Domain.Models
{
    public class BookingViewModel
    {
        public BookingViewModel(BookingTypeEnum bookingType)
        {
            BookingType = bookingType;
        }
        
        public int Id { get; set; }
        public BookingTypeEnum BookingType { get; }
        public int RentalId { get; set; }
        public DateTime Start { get; set; }
        public int Nights { get; set; }
        public int UnitNo { get; set; }

    }
}
