using App.Domain.Abstraction.Models;
using App.Domain.Entity.EP;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace App.Domain.Entity
{
    /// <summary>
    /// Взыскания
    /// </summary>
    public class EnforcementProceedingPenalties : IEnforcementProceedingChildCollection, IIdentityEntity//, IModelDetailConvertorSupport<EnforcementProceedingPenalties>
    {
        public int Id { get; set; }

        public int EnforcementProceedingId { get; set; }

        public DateTime PerformanceDate { get; set; }

        public decimal IndebtednessSum { get; set; }

        public decimal StateDutySum { get; set; }

        public decimal FineSum { get; set; }


        #region Navigation Properties

        public virtual EnforcementProceeding EnforcementProceeding { get; set; }

        #endregion


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion

        public Expression<Func<EnforcementProceedingPenalties, bool>> ByParentSelectorImpl(int parentId)
        {
            Expression<Func<EnforcementProceedingPenalties, bool>> filter = x => x.EnforcementProceedingId == parentId;
            return filter;
        }

        [NotMapped]
        public int ParentId { get => EnforcementProceedingId; set => EnforcementProceedingId = value; }
    }
}
