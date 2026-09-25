namespace Object_OrientedOOP.Part2_HotelReservationSystem.src
{
    public class Program
    {
        public static void Main()
        {
            HotelManager hotel = new HotelManager();

            // Create Guest
            Guest guest = new Guest(
                1,
                "Ahmad Ali",
                "0591234567");

            hotel.AddGuest(guest);

            // Create Room
            Room room = new Room(
                101,
                RoomType.Single,
                100m);

            hotel.AddRoom(room);

            // Create Reservation
            Reservation reservation = new Reservation(
                1,
                new DateTime(2026, 10, 1),
                new DateTime(2026, 10, 4),
                room);

            hotel.AddReservation(guest, reservation);

            Console.WriteLine("Reservation created successfully.");
            Console.WriteLine($"Guest: {guest.FullName}");
            Console.WriteLine($"Room: {room.RoomNumber}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Total: {reservation.CalculateTotalCost()}");

            // Change status
            reservation.Confirm();
            Console.WriteLine($"Status after confirm: {reservation.Status}");

            reservation.CheckInGuest();
            Console.WriteLine($"Status after check-in: {reservation.Status}");

            reservation.CheckOutGuest();
            Console.WriteLine($"Status after check-out: {reservation.Status}");
        }
    }
}