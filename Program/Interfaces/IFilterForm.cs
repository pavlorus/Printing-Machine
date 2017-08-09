using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Interfaces
{
    interface IFilterForm
    {
        List<int> SelectedElements(List<int> L);
    }
}
