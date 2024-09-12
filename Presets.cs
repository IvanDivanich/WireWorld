using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WireworldForms
{
    internal class Presets
    {
        Size ORsize = new Size(7, 5);
        List<Point> ORpreset = new List<Point>() { new Point(0, 1), new Point(1, 1), new Point(2, 0), new Point(3, 0),
                                                   new Point(4, 1), new Point(4, 2), new Point(4, 3), new Point(3, 2),
                                                   new Point(5, 2), new Point(3, 4), new Point(2, 4), new Point(1, 3),
                                                   new Point(0, 3), new Point(6, 2)};

        Size ANDsize = new Size(13, 8);
        List<Point> ANDpreset = new List<Point>() { new Point(0, 1), new Point(1, 0), new Point(2, 0), new Point(3, 0),
                                                   new Point(4, 0), new Point(5, 0), new Point(6, 0), new Point(7, 0),
                                                   new Point(8, 1), new Point(9, 1), new Point(10, 1), new Point(11, 2),
                                                   new Point(11, 3), new Point(11, 4), new Point(10, 5), new Point(9, 5),
                                                   new Point(8, 5), new Point(9, 4), new Point(9, 6), new Point(7, 4),
                                                   new Point(7, 2), new Point(6, 3), new Point(5, 3), new Point(4, 3),
                                                   new Point(5, 2), new Point(5, 4), new Point(0, 3), new Point(1, 4),
                                                   new Point(1, 5), new Point(1, 6), new Point(2, 7), new Point(3, 6),
                                                   new Point(3, 5), new Point(3, 4), new Point(11, 6), new Point(12, 6)};


        public List<Point> GetOR { get => ORpreset; }
        public Size GetOrSize {  get => ORsize; }
        public List<Point> GetAND { get => ANDpreset; }
        public Size GetAndSize { get => ANDsize; }

        public Presets() { }
    }
}
