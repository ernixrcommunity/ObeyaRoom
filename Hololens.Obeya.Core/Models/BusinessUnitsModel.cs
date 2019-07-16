namespace Hololens.Obeya.Core.Models
{
    using System.Collections.Generic;

    public class BusinessUnitModel
    {
        public string Title { get; set; }

        public string ShortName { get; set; }

        public double Availability { get; set; }

        public IList<BusinessUnitModel> ChildrenBUs { get; set; }

        public IList<GenericDateValueModel> AvailabilityHistoric { get; set; }
    }
}
