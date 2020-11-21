using App.Domain.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace App.Domain.Entity.JW
{
    public class JudicialWorkPremiseAccount : IIdentityEntity//, IModelDetailConvertorSupport<JudicialWorkPremiseAccount>
    {
        public int Id { get; set; }

        public int JudicialWorkId { get; set; }

        public int? BillingPersonalAccountId { get; set; }

        #region Navigation Properies

        public virtual JudicialWork JudicialWork { get; set; }

        public virtual ICollection<JudicialWorkFine> JudicialWorkFines { get; set; }

        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion

        [NotMapped]
        public int ParentId { get => JudicialWorkId; set => JudicialWorkId = value; }

        public Expression<Func<JudicialWorkPremiseAccount, bool>> ByParentSelectorImpl(int parentId)
        {
            Expression<Func<JudicialWorkPremiseAccount, bool>> filter = x => x.JudicialWorkId == parentId;
            return filter;
        }
    }
}
