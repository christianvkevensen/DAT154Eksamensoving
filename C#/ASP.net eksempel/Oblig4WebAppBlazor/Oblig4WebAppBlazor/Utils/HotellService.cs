using Oblig4WebAppBlazor.Data;
using Oblig4WebAppBlazor.Models;

namespace Oblig4WebAppBlazor.Utils
{
    public class HotellService
    {
        private readonly Oblig4Context _context;
        public HotellService(Oblig4Context context)
        {
            this._context = context;
        }

        public List<Room> getRooms(int numberOfBeds, int quality, DateTime startDate, DateTime endDate)
        {
            List<Room> rooms = new List<Room>();
            var potentialRooms= _context.rooms.Where(r => r.Quality == quality && r.NumberOfBeds == numberOfBeds).ToList();

            rooms = getRoomsCheck(startDate, endDate, potentialRooms);
            return rooms;
            
        }

        public List<Room> getRoomsCheck(DateTime from, DateTime to, List<Room> availableRooms)
        {

            List<Room> choosenRooms = new List<Room>();
            foreach (Room r in availableRooms)
            {
                bool isAvailable = true;
                foreach (Reservation res in r.Reservations)
                {
                    if (IsBetweenTwoDates(from, res.startDate, res.endDate) || IsBetweenTwoDates(to, res.startDate, res.endDate))
                    {
                        isAvailable = false;
                        break;

                    }
                }
                if (isAvailable)
                {
                    choosenRooms.Add(r);
                }

            }
            return choosenRooms;

        }

        public bool IsBetweenTwoDates(DateTime date,DateTime startDate, DateTime endDate)
        {
            Console.WriteLine((date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks));
            return (date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks);
        }

        
        public void bookRoom(Room r, string username, DateTime startDate, DateTime endDate)
        {
            Reservation reservation = new Reservation();
            reservation.startDate = startDate;
            reservation.endDate = endDate;
            reservation.room = r;
            User user;
            user = _context.users.Find(username);
            
            if(user == null)
            {
                user = new User();
                user.UserName = username;
                _context.users.Add(user);
            }

            reservation.user = user;
            _context.reservations.Add(reservation);
            _context.SaveChanges();

        }

        public List<Reservation> searchUser(string username)
        {
            List<Reservation> reservations = _context.reservations.Where(r=>r.user.UserName == username).ToList();
            return reservations;
        }
        

    }
}
