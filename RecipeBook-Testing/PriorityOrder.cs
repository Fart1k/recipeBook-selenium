using Xunit.Abstractions;
using Xunit.Sdk;

namespace RecipeBook_Testing
{
    public class PriorityOrder : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            return testCases.OrderBy(test =>
            {
                var method = test.TestMethod.Method.GetCustomAttributes(typeof(OrderAttribute)).FirstOrDefault();

                if (method == null)
                {
                    return int.MaxValue;
                }
                else
                {
                    return method.GetNamedArgument<int>(nameof(OrderAttribute.Value));
                }
            }).ToList();
        }
    }
}