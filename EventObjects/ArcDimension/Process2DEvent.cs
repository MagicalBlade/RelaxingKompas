using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.EventObjects.ArcDimension
{
    internal class Process2DEvent : BaseEvent, ksProcess2DNotify
    {
        public List<double[]> coordinat = new List<double[]>();
        int i = 0;
        IProcess2D _process2D = null;

        public Process2DEvent(IProcess2D process2D) :
            base(process2D, typeof(ksProcess2DNotify).GUID)
        {
            Advise();
            _process2D = process2D;
        }

        public bool PlacementChange(double X, double Y, double Angle, bool Dynamic)
        {
            coordinat.Add(new double[] {X, Y });
            i++;
            if (i > 2) ((IProcess)_process2D).Stop();
            return true;
        }

        public bool ExecuteCommand(int Command)
        {
            return true;
        }

        public bool Run()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }

        public bool Activate()
        {
            return true;
        }

        public bool Deactivate()
        {
            return true;
        }

        public bool EndProcess()
        {
            return true;
        }

        public bool GetMouseEnterLeavePoint(object Control, int BtnID, int PointIndex, object Parameters)
        {
            return true;
        }

        public bool AbortProcess()
        {
            return true;
        }
    }
}
