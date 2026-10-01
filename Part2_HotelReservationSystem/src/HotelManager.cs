using System;
using System.Collections.Generic;

namespace Object_OrientedOOP.Part2_HotelReservationSystem.src
{
    public class HotelManager
    {
        private readonly List<Guest> _guests = new();
        private readonly List<Room> _rooms = new();
        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Guest> Guests => _guests;
        public IReadOnlyList<Room> Rooms => _rooms;
        public IReadOnlyList<Reservation> Reservations => _reservations;

        public void AddGuest(Guest guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest));

            if (FindGuest(guest.GuestId) != null)
                throw new ArgumentException("Guest ID already exists.");

            _guests.Add(guest);
        }

        public void AddRoom(Room room)
        {
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            if (FindRoom(room.RoomNumber) != null)
                throw new ArgumentException("Room number already exists.");

            _rooms.Add(room);
        }

        public void AddReservation(
            Guest guest,
            Reservation reservation)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest));

            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            if (!_guests.Contains(guest))
                throw new InvalidOperationException(
                    "Guest does not belong to this hotel.");

            if (FindReservation(reservation.ReservationId) != null)
                throw new ArgumentException(
                    "Reservation ID already exists.");

            if (!_rooms.Contains(reservation.Room))
                throw new InvalidOperationException(
                    "Room does not belong to this hotel.");

            CheckRoomAvailability(reservation);

            guest.AddReservation(reservation);
            _reservations.Add(reservation);
        }

        public Guest FindGuest(int guestId)
        {
            for (int i = 0; i < _guests.Count; i++)
            {
                if (_guests[i].GuestId == guestId)
                    return _guests[i];
            }

            return null;
        }

        public Room FindRoom(int roomNumber)
        {
            for (int i = 0; i < _rooms.Count; i++)
            {
                if (_rooms[i].RoomNumber == roomNumber)
                    return _rooms[i];
            }

            return null;
        }

        public Reservation FindReservation(int reservationId)
        {
            for (int i = 0; i < _reservations.Count; i++)
            {
                if (_reservations[i].ReservationId == reservationId)
                    return _reservations[i];
            }

            return null;
        }

        private void CheckRoomAvailability(Reservation reservation)
        {
            if (reservation.Room.IsUnderMaintenance)
            {
                throw new InvalidOperationException(
                    "Cannot reserve a room under maintenance.");
            }

            for (int i = 0; i < _reservations.Count; i++)
            {
                Reservation existing = _reservations[i];

                if (existing.Room == reservation.Room &&
                    IsActive(existing) &&
                    DatesOverlap(existing, reservation))
                {
                    throw new InvalidOperationException(
                        "Room is already booked for these dates.");
                }
            }
        }

        private bool IsActive(Reservation reservation)
        {
            return reservation.Status != ReservationStatus.Cancelled &&
                   reservation.Status != ReservationStatus.CheckedOut;
        }

        private bool DatesOverlap(
            Reservation first,
            Reservation second)
        {
            return first.CheckIn < second.CheckOut &&
                   second.CheckIn < first.CheckOut;
        }
    }
}