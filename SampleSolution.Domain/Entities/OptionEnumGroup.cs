using System.Collections.Generic;

namespace SampleSolution.Domain.Entities
{
    public class OptionEnumGroup : BaseEntity
    {
        public List<OptionEnumItem> EnumItems { get; set; }
    }
}