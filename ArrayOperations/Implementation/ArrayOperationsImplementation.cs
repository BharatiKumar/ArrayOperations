using ArrayOperations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayOperations.Implementation
{
    public class ArrayOperationsImplementation : IArrayOperations
    {
        public string[] ReverseElements(string[] input)
        {
            string[] output = new string[input.Length];
            var outputIndex = 0;

            for (int index = input.Length-1; index >=0; index-- )
            {
                output[outputIndex++] = input[index];
            }
            return output;
        }

        public string[] DeleteElement(int position, string[] input)
        {
            string[] output = new string[input.Length - 1];
            var outputIndex = 0;

            for (int index = 0; index < input.Length; index++)
            {
                if (index == position-1)
                    continue;
                output[outputIndex++] = input[index];
            }
            return output;
        }       
    }
}