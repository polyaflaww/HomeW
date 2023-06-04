using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ShiftDownTransformer : ITransformer<ShiftDownParameters>
    {
        double shiftPercent { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, ShiftDownParameters parameters)
        {
            shiftPercent = parameters.ShiftPercent/100;
            ResultSize = size;
        }

        public Point? MapPoint(Point point)
        {
            int y;
            if (point.Y < (int)(ResultSize.Height * shiftPercent))
                y = (int)(point.Y + ResultSize.Height - ResultSize.Height * shiftPercent);
            else
                y = (int)(point.Y - ResultSize.Height * shiftPercent);

            return new Point(point.X, y);
        }
    }
}
