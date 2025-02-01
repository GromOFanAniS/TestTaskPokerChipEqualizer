using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerChipEqualizerLib
{
    public static class ListExtensions
    {
        public static int MyIndexValue(this IList<int> list, int index)

        public static int MyIndex(this IList<int> list, int index)
        {
            if (index >= list.Count)
            {
                return list.MyIndex(index - list.Count);
            }

            if (index >= 0)
            {
                return index;
            }

            return list.MyIndex(index + list.Count);
        }
    }
}
