using App.Domain.Abstraction.Models;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.JW
{
    /// <summary>
    /// Вид суда
    /// </summary>
    public class CourthouseType : IIdentityEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Код типа
        /// </summary>
        public string Code { get; set; }

        #region Navigation

        public virtual ICollection<Courthouse> Courthouses { get; set; }


        #endregion

        #region Implementation of IIdentityEntity

        public bool IsDeleted { get; set; }

        public int WorkerChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        #endregion
    }
}
