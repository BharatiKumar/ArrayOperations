using ArrayOperations.Implementation;
using ArrayOperations.Interfaces;
using ArrayOperations.Utilities;
using System;
using System.Text;
using System.Web.Http;

namespace ArrayOperations.Controllers
{
    [RoutePrefix("api/arraycalc")]
    public class ArrayOperationsController : ApiController
    {
        private readonly IArrayOperations arrayOpsImplementation;

        public ArrayOperationsController()
        {
            this.arrayOpsImplementation = WindsorContainerConfiguration.IocResolve<IArrayOperations>(); 
        }

        [Route("reverse")]
        [HttpGet]
        public string ReverseElements([FromUri]string[] productIds)
        {
            if (productIds != null)
            {
                var reversedArray = this.arrayOpsImplementation.ReverseElements(productIds);
                var formattedOutput =RenderAsString(reversedArray);
                return formattedOutput;
            }
            return  "Input is missing. Tip:Product Ids"  ;
        }

        [Route("deletepart")]
        [HttpGet]
        public string DeleteElement([FromUri]int position,[FromUri] string[] productIds)
        {
            if (position != 0 && productIds != null)
            {
                var outputArray = this.arrayOpsImplementation.DeleteElement(position, productIds);
                var formattedOutput = RenderAsString(outputArray);
                return formattedOutput;
            }
            return "Missing either position or product Ids";
        }

        private string RenderAsString(string[] input)
        {
            var renderedText = new StringBuilder();
            renderedText.Append("[");
            for (var index = 0; index < input.Length; index++)
            {
                renderedText.Append(input[index]);
                renderedText.Append(index < input.Length - 1 ? "," : string.Empty);
            }
            renderedText.Append("]");
            return renderedText.ToString();
        }         
    }
}
