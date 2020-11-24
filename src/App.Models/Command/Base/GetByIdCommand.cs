namespace App.Models.Command.Base
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
