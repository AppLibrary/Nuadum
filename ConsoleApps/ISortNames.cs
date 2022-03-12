using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuadum
{
    public interface ISortNames
    {
        void Write(string fileOne);
        void RandomSort(string fileOne, string fileTwo);
    }
}
