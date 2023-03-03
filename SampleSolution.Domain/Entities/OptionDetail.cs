namespace SampleSolution.Domain.Entities
{
    public class OptionDetail : BaseEntity
    {
        public string OptionId { get; set; }
        public string OptionSequence { get; set; }
        public string Label { get; set; }
        public long? TranslationId { get; set; }
        public OptionType OptionType { get; set; }
        public OptionLookup Lookup { get; set; }
        public OptionEnumGroup EnumGroup { get; set; }
        public OptionGrouping Grouping { get; set; }
    }
}