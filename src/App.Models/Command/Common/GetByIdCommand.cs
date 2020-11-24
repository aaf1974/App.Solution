namespace App.Models.Command.Common
{
    /// <summary>
    /// Команда получения объекта по идентификатору
    /// </summary>
    public class GetByIdCommand
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public int Id { set; get; }
    }
}
