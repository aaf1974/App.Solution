using App.Domain.Abstraction.Models;
using App.Domain.Entity.Dictionaries.PretensionWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace App.Domain.Entity.PW
{
    public class PretensionWork : IIdentityEntity
    {
        public int Id { get; set; }

        public DateTime DepartureDate { get; set; }

        [DefaultValue(0)]
        public decimal IndebtednessSum { get; set; }

        public DepartureMethodEnum DepartureMethodId { get; set; }

        public int IndebtednessPeriodId { get; set; }

        public virtual ICollection<PretensionWorkPremiseAccount> PretensionWorkPremiseAccounts { get; set; }

        public int? BillingPremiseAccountId { get; set; }

        public int? OwnerLegalEntityId { get; set; }

        public int? OwnerPhysicalPersonId { get; set; }

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
