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

        public List<Room> getRooms(int numberOfBeds, int quality)
        {
            List<Room> rooms = new List<Room>();
            rooms= _context.rooms.Where(r => r.Quality == quality && r.NumberOfBeds == numberOfBeds).ToList();
            return rooms;
            
        }

        /*
        public bool bookRoom(Room r, string usernam)
        {

        }
        */

    }
}
