namespace App.Domain.Abstraction.Models
{
    public interface IIdentityEntity : IIdentityEntity<int>, IChangeDate, IIsDeletedSupport, IChangedBySupport
    {

    }

    public interface IIdentityEntity<T>
    {
        public T Id { get; set; }
    }
}
