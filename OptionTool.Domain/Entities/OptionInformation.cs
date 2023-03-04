namespace OptionTool.Domain.Entities
{
    public class OptionInformation : BaseEntity
    {
        public string OptionId { get; set; }
        public string OptionSequence { get; set; }
        public string Label { get; set; }
        public decimal? TranslationId { get; set; }
        public OptionValueType OptionValueType { get; set; }
        public ValueLookupObject ValueLookupObject { get; set; }
        public ValueEnumGroup ValueEnumGroup { get; set; }
        public OptionTree OptionTree { get; set; }
    }
}