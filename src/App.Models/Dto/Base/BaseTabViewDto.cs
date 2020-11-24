using System.Collections.Generic;

namespace App.Models.Dto.Base
{
    /// <summary>
    /// Базовый объект для табличных представлений
    /// </summary>
    public class BaseTabViewDto
    {
        /// <summary>
        /// Общее количество записей
        /// </summary>
        public int RecordCount { get; set; }
    }

    /// <summary>
    /// <inheritdoc cref="BaseTabViewDto"/>
    /// </summary>
    public class BaseTabViewDto<T> 
    {
        /// <summary>
        /// Общее количество записей
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// Элементы табличного представления
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
