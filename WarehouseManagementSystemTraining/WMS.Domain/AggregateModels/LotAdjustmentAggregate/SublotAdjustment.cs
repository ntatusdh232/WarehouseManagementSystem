using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.AggregateModels.EmployeeAggregate;

namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class SublotAdjustment : IAggregateRoot
    {
        public string LocationId { get; private set; }
        public double BeforeQuantityPerLocation { get; private set; }
        public double AfterQuantityPerLocation { get; private set; }

#pragma warning disable CS8618
        private SublotAdjustment() { }

        public SublotAdjustment(string locationId, double beforeQuantityPerLocation, double afterQuantityPerLocation)
        {
            LocationId = locationId;
            BeforeQuantityPerLocation = beforeQuantityPerLocation;
            AfterQuantityPerLocation = afterQuantityPerLocation;
        }



#pragma warning restore CS8618

    }
}
