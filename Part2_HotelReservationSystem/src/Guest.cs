using System;
using System.Collections.Generic;
using System.Linq;

namespace Object_OrientedOOP.Part2_HotelReservationSystem.src
{
    public class Guest
    {
        private const int MinimumValidId = 1;

        private readonly List<Reservation> _reservations = new();

        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Guest(
            int guestId,
            string fullName,
            string phoneNumber)
        {
            if (guestId < MinimumValidId)
            {
                throw new ArgumentException(
                    $"Id must be at least {MinimumValidId}.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException(
                    "Full name cannot be empty.");
            }

            ValidatePhoneNumber(phoneNumber);

            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        private static void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException(
                    "Phone number cannot be empty.");
            }

            if (phoneNumber.Length != 10)
            {
                throw new ArgumentException(
                    "Phone number must contain exactly 10 digits.");
            }

            if (!phoneNumber.All(c => c >= '0' && c <= '9'))
            {
                throw new ArgumentException(
                    "Phone number must contain digits only.");
            }
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }

            _reservations.Add(reservation);
        }
    }
}