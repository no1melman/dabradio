namespace DabRadio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DabFunctionCoordinator : IDabFunctionCoordinator
    {
        IEnumerable<IDabFunctionStrategy> dabFunctionStrategies;

        public DabFunctionCoordinator(
            IEnumerable<IDabFunctionStrategy> dabFunctionStrategies)
        {
            this.dabFunctionStrategies = dabFunctionStrategies;
        }

        public void Run(string functionName)
        {
            var dabFunctionStrategy = dabFunctionStrategies.FirstOrDefault(x => x.CanHandle(functionName));

            if (dabFunctionStrategy == null)
            {
                throw new NotImplementedException(string.Format("No strategry implemented for {0}", functionName));
            }

            dabFunctionStrategy.Run();
        }
    }
}
