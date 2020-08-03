using System.Collections.Concurrent;

namespace SokolovskiyClinicService.Lockers
{
    public class Locker
    {
        public ConcurrentDictionary<int, object> ReservationLocker;

        public Locker()
        {
            ReservationLocker = new ConcurrentDictionary<int, object>();
        }
        public object GetOrAdd(int doctorId)
        {
            return ReservationLocker.GetOrAdd(doctorId, new object());
        }
        
    }
}