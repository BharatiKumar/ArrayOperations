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
    class Given_a_delete_element_request
    {
        public class When_position_is_not_passed
        {
            Establish context = () =>
            {
                subject = GetArrayOperationsControllerForTest();
                productIds = new string[4] { "1", "2", "3", "4" };
            };

            Because of = () => { result = subject.DeleteElement(0,productIds); };

            It should_return_an_error = () => result.ShouldEqual("Missing either position or product Ids");

            static ArrayOperationsController subject;
            static string[] productIds;
            static string result;
        }
        public class When_product_Ids_are_not_passed
        {
            Establish context = () =>
            {
                subject = GetArrayOperationsControllerForTest();              
            };

            Because of = () => { result = subject.DeleteElement(1,null); };

            It should_return_an_error = () => result.ShouldEqual("Missing either position or product Ids");

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

            Because of = () => { result = subject.DeleteElement(1,productIds); };

            It should_reverse_the_array = () => result.ShouldEqual("[2,3,4]");

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
