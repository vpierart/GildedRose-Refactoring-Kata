using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BusinessRule
    {
        public string productName { get; set; }
        public int sellInDateRangeBottom { get; set; }
        public int sellInDateRangeTop { get; set; }
        public int dailyDelta { get; set; }
        public int minAllowedValue { get; set; }
        public int maxAllowedValue { get; set; }
        public bool isLegendary { get; set; }
        public bool isConjured { get; set; }

        /// <summary>
        /// Constructor to set default values
        /// </summary>
        /// <param name="beforeSellinDate">If the date is passed, the quality decrease is different. Please specify for default rule creation</param>
        public BusinessRule(bool beforeSellinDate = true)
        {
            productName = "default";
            sellInDateRangeTop = Int32.MaxValue;
            sellInDateRangeBottom = Int32.MinValue;
            dailyDelta = (beforeSellinDate ? -1 : -2);
            minAllowedValue = 0;
            maxAllowedValue = 50;
            isLegendary = false;
            isConjured = false;
        }
    }
}
