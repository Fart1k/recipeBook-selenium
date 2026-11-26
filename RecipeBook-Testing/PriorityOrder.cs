using Xunit.Abstractions;
using Xunit.Sdk;

namespace RecipeBook_Testing
{
    //Xunit järjesti mis implementeerib ItestCaseOrderer loodese, ja sealt
    // "OrderTestCases" meetodi, ning testid, nende käivitamise hetkel
    // järjestatakse vastavalt "Order" omadusele.
    public class PriorityOrder : ITestCaseOrderer
    {

        //Meetod võtab sisse kõik testid
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            //Ja tagastab nad järjstuna arendaja defineeritud järjesti järgi.
            return testCases.OrderBy(test =>
            {
                //Leitakse omadus
                var method = test.TestMethod.Method.GetCustomAttributes(typeof(OrderAttribute)).FirstOrDefault();
                //Kui ei leita
                if (method == null)
                {
                    //Antakse testile suurim võimalik täisarv
                    return int.MaxValue;
                }
                
                else
                {
                    //Vastasel juhul tagastatakse omaduse order väärtus
                    return method.GetNamedArgument<int>(nameof(OrderAttribute.Value));
                }
            }).ToList(); //Takitatakse loend sorteeritud testidest
        }
    }
}