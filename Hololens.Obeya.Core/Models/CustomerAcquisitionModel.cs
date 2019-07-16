namespace Hololens.Obeya.Core.Models
{
    using System.Collections.Generic;

    public class CustomerAcquisitionModel
    {
        public IList<CurrentOfferModel> CurrentOffers { get; set; }

        public IList<string> Opportunities { get; set; }

        public IList<string> Requests { get; set; }

        public IList<string> KeyAccounts { get; set; }
    }
}
