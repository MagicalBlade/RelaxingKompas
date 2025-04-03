using DocumentFormat.OpenXml.Wordprocessing;
using Kompas6Constants;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Classes
{
    class CircleTransform : ICircle
    {


        double xcTransf;
        double ycTransf;
        public double XcTransf { get => xcTransf; set => xcTransf = value; }
        public double YcTransf { get => ycTransf; set => ycTransf = value; }

        public CircleTransform(IMacroObject macroObject, ICircle circle)
        {
            xcTransf = circle.Xc;
            ycTransf = circle.Yc;
            macroObject.TransformPointToView(ref xcTransf, ref ycTransf);
        }

        #region Наследуемое
        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public IKompasAPIObject Parent => throw new NotImplementedException();

        public IApplication Application => throw new NotImplementedException();

        public KompasAPIObjectTypeEnum Type => throw new NotImplementedException();

        public int Reference => throw new NotImplementedException();

        public DrawingObjectTypeEnum DrawingObjectType => throw new NotImplementedException();

        public int LayerNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Temp => throw new NotImplementedException();

        public bool Valid => throw new NotImplementedException();

        public ksDrawingObjectParamTypeEnum DrawingObjectParamType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Xc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Yc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Radius { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Style { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
    }
}
