using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSensorLib
{
    public enum TrackingSensorStatus
    {
        Active,
        Inactive
    }

    public sealed class TrackingSensorEventArgs
    {
        public TrackingSensorStatus Status { get; private set; }

        public TrackingSensorEventArgs(TrackingSensorStatus status)
        {
            Status = status;
        }
    }


    public interface ITrackingSensor : IDisposable
    {
        void Initialize();
        void UnInitialize();

        int PinNumber { get; }

        TrackingSensorStatus DetectStatus();

        event EventHandler<TrackingSensorEventArgs> InterruptHandler;
    }
}
