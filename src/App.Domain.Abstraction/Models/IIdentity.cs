namespace App.Domain.Abstraction.Models
{
    public interface IIdentity<T>
    {
        public T Id { get; set; }
    }
}
