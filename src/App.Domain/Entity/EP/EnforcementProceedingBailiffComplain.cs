using App.Domain.Abstraction.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace App.Domain.Entity.EP
{
    /// <summary>
    /// Жалобы направленные в ССП
    /// </summary>
    public class EnforcementProceedingBailiffComplain : IIdentityEntity, IEnforcementProceedingChildCollection/*, IModelDetailConvertorSupport<EnforcementProceedingBailiffComplain>*/
    {
        public int Id { get; set; }

        public int EnforcementProceedingId { get; set; }

        /// <summary>
        /// Дата направления
        /// </summary>
        public DateTime SendingDate { get; set; }

        /// <summary>
        /// Должностное лицо
        /// </summary>
        public string Executive { get; set; }

        /// <summary>
        /// Текст жалобы
        /// </summary>

        public string TextComplain { get; set; }


        #region Navigation

        public virtual EnforcementProceeding EnforcementProceeding { get; set; }

        #endregion


        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }


        public DateTime ChangeDate { get; set; }

        #endregion

        public Expression<Func<EnforcementProceedingBailiffComplain, bool>> ByParentSelectorImpl(int parentId)
        {
            Expression<Func<EnforcementProceedingBailiffComplain, bool>> filter = x => x.EnforcementProceedingId == parentId;
            return filter;
        }

        [NotMapped]
        public int ParentId { get => EnforcementProceedingId; set => EnforcementProceedingId = value; }
    }
}
