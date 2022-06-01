using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Rules
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (result.Status == false)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
