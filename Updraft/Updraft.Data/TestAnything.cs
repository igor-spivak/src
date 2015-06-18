using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updraft.Data
{
    public class TestAnything
    {
        public TestAnything()
        { }

        public string GetSomeStr(string s)
        {
            s = string.Format("{0} - {1}", s, "new value");
            return string.Empty;
        }

        public Point TryModifyParam1(Point p)
        {
            var result = new Point(p.X, p.Y);

            p.X++;
            p.Y++;

            return p;
        }

        public void TryModifyParam2(Point p)
        {
            p.X++;
            p.Y++;
            p.Name = "new value";
        }

        public void TryModifyParam3(ref Point p)
        {
            p.X++;
            p.Y++;
            p.Name = "new value";

        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }




}
