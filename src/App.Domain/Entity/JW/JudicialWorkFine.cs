using App.Domain.Abstraction.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entity.JW
{
    public class JudicialWorkFine : IIdentityEntity //, IJudicalFineSupport
    {
        public int Id { get; set; }

        public int JudicialWorkPremiseAccountId { get; set; }

        public int PeriodId { get; set; }

        public decimal DebtSum { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DaysCount { get; set; }

        public decimal Rate { get; set; }

        public decimal Pays { get; set; }

        public decimal Fine { get; set; }

        public bool HasPays { get; set; }

        public DateTime? PayDate { get; set; }

        #region NavigationProperty

        public virtual JudicialWorkPremiseAccount JudicialWorkPremiseAccount { get; set; }


        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion


        [NotMapped]
        public bool IsCalculated { get; set; }

        /// <summary>
        /// !Внимание!!!! Not Mapped Field
        /// </summary>
        [NotMapped]
        public int PremiseAccountId { get; set; }

        /// <summary>
        /// Billing field
        /// </summary>
        public decimal PenaltyCoeficient { get; set; }

        public int? RecalculationPeriodId { get; set; }

        public int? PenaltyBasisPeriodId { get; set; }

        public int? PenaltyBasisRootPeriodId { get; set; }
    }
}
