namespace App.Domain.Abstraction.Models
{
    public interface IIdentityEntity : IIdentityEntity<int>, IChangeDate, IIsDeletedSupport, IChangedBySupport
    {

    }

    public interface IIdentityEntity<T> : IIdentity<T>
    {
        public new T Id { get; set; }
    }

    public interface IIdentity<T>
    {
        public T Id { get; set; }
    }
}
