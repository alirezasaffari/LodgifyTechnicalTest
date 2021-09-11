using NSubstitute;
using System;
using System.Collections.Generic;
using FluentAssertions;
using VacationRental.Domain.Enums;
using VacationRental.Domain.Exceptions;
using VacationRental.Domain.Models;
using VacationRental.Infrastructure.Services;
using Xunit;

namespace VacationRental.Unit.Test
{
    public class BookingTest
    {
        [Fact]
        public void Get_ThrowBookingNotFoundException_When_BookingNotFound()
        {
            //arrange
            var booking = Substitute.For<IDictionary<int, BookingViewModel>>();
            var rental = Substitute.For<IDictionary<int, RentalViewModel>>();

            var bookingService = new BookingService(booking, rental);

            //act
            Func<BookingViewModel> get = () => bookingService.Get(1);

            //assert
            get.Should().Throw<BookingNotFoundException>();
        }
        [Fact]
        public void Get_Success_When_BookingFound()
        {
            //arrange
            var booking = new Dictionary<int, BookingViewModel>();
            var rental = Substitute.For<IDictionary<int, RentalViewModel>>();

            var book = new BookingViewModel(BookingTypeEnum.Booking)
            {
                Id = 1,
                Nights = 1,
                Start = Convert.ToDateTime("2021-01-20"),
                Unit = 1,
                RentalId = 1
            };

            booking.Add(1, book);

            var bookingService = new BookingService(booking, rental);

            //act
            var result = bookingService.Get(1);

            //assert
            result.Should().Be(book);
        }

        [Fact]
        public void Add_ThrowException_When_NotAvailableRental()
        {
            //arrange
            var booking = new Dictionary<int, BookingViewModel>();
            var rental = new Dictionary<int, RentalViewModel>();

            var rent = new RentalViewModel()
            {
                Id = 1,
                Units = 1,
                PreparationTimeInDays = 0
            };

            var book = new BookingViewModel(BookingTypeEnum.Booking)
            {
                Id = 1,
                Nights = 1,
                Start = Convert.ToDateTime("2021-01-20"),
                Unit = 1,
                RentalId = 1
            };

            var book2 = new BookingBindingModel
            {
                Nights = 1,
                Start = Convert.ToDateTime("2021-01-20"),
                RentalId = 1
            };

            rental.Add(1, rent);
            booking.Add(1, book);

            var bookingService = new BookingService(booking, rental);

            //act
            Func<ResourceIdViewModel> create = () => bookingService.Add(book2);

            //assert
            create.Should().Throw<ApplicationException>();
        }

        [Fact]
        public void Add_Success_When_AvailableRental()
        {
            //arrange
            var booking = new Dictionary<int, BookingViewModel>();
            var rental = new Dictionary<int, RentalViewModel>();
            var expected = new ResourceIdViewModel
            {
                Id = 2
            };

            var rent = new RentalViewModel
            {
                Id = 1,
                Units = 2,
                PreparationTimeInDays = 0
            };

            var book1 = new BookingBindingModel
            {
                Nights = 1,
                Start = Convert.ToDateTime("2021-01-20"),
                RentalId = 1
            };

            var book2 = new BookingBindingModel
            {
                Nights = 1,
                Start = Convert.ToDateTime("2021-01-20"),
                RentalId = 1
            };

            rental.Add(1, rent);

            var bookingService = new BookingService(booking, rental);
            bookingService.Add(book1);

            //act
            var result = bookingService.Add(book2);

            //assert
            result.Equals(expected);
        }
    }
}
