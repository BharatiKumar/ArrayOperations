using ArrayOperations.Controllers;
using Machine.Specifications;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations.Tests
{
    public class Given_a_reverse_request
    {
        public class When_valid_input_is_not_passed
        {
            Establish context = () =>
            {
                subject = GetArrayOperationsControllerForTest();
            };

            Because of = () => { result =   subject.ReverseElements(null); };

            It should_return_an_error = () => result.ShouldEqual("Input is missing. Tip:Product Ids");

            static ArrayOperationsController subject;
            static string result;
        }

        public class When_valid_input_is_passed
        {
            Establish context = () =>
            {
                subject = GetArrayOperationsControllerForTest();
                productIds = new string[4] { "1", "2", "3", "4" };    
            };

            Because of = () => { result = subject.ReverseElements(productIds); };

            It should_reverse_the_array = () => result.ShouldEqual("[4,3,2,1]");

            static ArrayOperationsController subject;
            static string[] productIds;
            static string result;
        }

        private static ArrayOperationsController GetArrayOperationsControllerForTest()
        {
            return new ArrayOperationsController();
        }
    }
}
