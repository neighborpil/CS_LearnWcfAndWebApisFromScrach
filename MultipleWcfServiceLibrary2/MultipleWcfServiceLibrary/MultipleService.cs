using System.ServiceModel.Activation;

namespace MultipleWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MultipleService" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MultipleService : IMultipleService
    {
        public int Multiple(int a, int b)
        {
            return a * b;
        }

    }
}
