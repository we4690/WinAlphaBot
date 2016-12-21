using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLib
{
    public enum TrackerSensorStatus
    {
        Active,
        Inactive
    }
    public sealed class TrackerSensorEvent
    {
        public TrackerSensorStatus Status { get; private set; }


        public TrackerSensorEvent(TrackerSensorStatus status)
        {
            Status = status;
        }
    }


    public interface ITrackerSensor : IDisposable
    {
        void Initialize();
        void UnInitialize();
        TrackerSensorStatus DetectStatus();

        event EventHandler<TrackerSensorEvent> InterruptHandler;
    }
}
