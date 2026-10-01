using System;

namespace Object_OrientedOOP.Part2_HotelReservationSystem.src
{
    public class Reservation
    {
        private const int MinimumValidId = 1;

        public int ReservationId { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public Room Room { get; }
        public ReservationStatus Status { get; private set; }

        public Reservation(
            int reservationId,
            DateTime checkIn,
            DateTime checkOut,
            Room room)
        {
            if (reservationId < MinimumValidId)
            {
                throw new ArgumentException(
                    $"Reservation Id must be at least {MinimumValidId}.");
            }

            if (checkOut <= checkIn)
            {
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");
            }

            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            ReservationId = reservationId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Room = room;
            Status = ReservationStatus.Pending;
        }

        public void Confirm()
        {
            EnsureStatus(ReservationStatus.Pending);

            Status = ReservationStatus.Confirmed;
        }

        public void CheckInGuest()
        {
            EnsureStatus(ReservationStatus.Confirmed);

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOutGuest()
        {
            EnsureStatus(ReservationStatus.CheckedIn);

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "Only pending or confirmed reservations can be cancelled.");
            }

            Status = ReservationStatus.Cancelled;
        }

        public decimal CalculateTotalCost()
        {
            int numberOfNights = (CheckOut - CheckIn).Days;

            return numberOfNights * Room.NightlyRate;
        }

        private void EnsureStatus(ReservationStatus expectedStatus)
        {
            if (Status != expectedStatus)
            {
                throw new InvalidOperationException(
                    $"Reservation must be {expectedStatus}.");
            }
        }
    }
}