using App.Domain.Abstraction.Models;

namespace App.Domain.Entity
{
    public class SampleModel : IIdentityEntity<int>
    {
        public int Id { get; set; }

        public string SomeProperty { get; set; }

        public string SecontProp { get; set; }
    }
}
