using App.Domain.Abstraction.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace App.Domain.Entity.PW
{
    public class PretensionWorkPremiseAccount : IIdentityEntity//, IModelDetailConvertorSupport<PretensionWorkPremiseAccount>
    {
        public int Id { get; set; }
        public int PretensionWorkId { get; set; }

        public int BillingPersonalAccountId { get; set; }

        [DefaultValue(0)]
        public decimal IndebtednessSum { get; set; }

        public int IndebtednessPeriodId { get; set; }

        #region Navigation Properies

        public PretensionWork PretensionWork { get; set; }

        //public virtual CommonModel.Premise.PremiseAccount PremiseAccount { get; set; }
        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion

        public Expression<Func<PretensionWorkPremiseAccount, bool>> ByParentSelectorImpl(int parentId)
        {
            Expression<Func<PretensionWorkPremiseAccount, bool>> filter = x => x.PretensionWorkId == parentId;
            return filter;
        }

        [NotMapped]
        public int ParentId { get => PretensionWorkId; set => PretensionWorkId = value; }

        public static PretensionWorkPremiseAccount CreateNew(Tuple<int, decimal> accountIdList, int pretensionWorId, int indebtednessPeriodId)
        {
            PretensionWorkPremiseAccount PrWorkPremiseAccount = new PretensionWorkPremiseAccount()
            {
                BillingPersonalAccountId = accountIdList.Item1,
                PretensionWorkId = pretensionWorId,
                IndebtednessPeriodId = indebtednessPeriodId,
                IndebtednessSum = accountIdList.Item2 < 0 ? 0 : accountIdList.Item2
            };
            return PrWorkPremiseAccount;
        }


    }
}
