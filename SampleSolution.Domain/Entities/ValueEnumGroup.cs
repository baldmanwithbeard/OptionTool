using System.Collections.Generic;

namespace SampleSolution.Domain.Entities
{
    public class ValueEnumGroup : BaseEntity
    {
        public List<ValueEnumItem> EnumItems { get; set; }
    }
}