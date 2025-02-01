using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerChipEqualizerLib
{
    public static class ListExtensions
    {
        public static int MyIndex(this IList<int> list, int index)
        {
            if (index >= list.Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index >= 0)
            {
                return list[index];
            }

            return list[index + list.Count];
        }
    }
}
