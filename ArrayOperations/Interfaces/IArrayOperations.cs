using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations.Interfaces
{
    public interface IArrayOperations
    {
        string[] ReverseElements(string[] input);
        string[] DeleteElement(int position, string[] input );
    }
}
