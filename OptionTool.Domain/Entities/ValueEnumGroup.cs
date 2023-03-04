using System.Collections.Generic;

namespace OptionTool.Domain.Entities
{
    public class ValueEnumGroup : BaseEntity
    {
        public List<ValueEnumItem> EnumItems { get; set; }
    }
}