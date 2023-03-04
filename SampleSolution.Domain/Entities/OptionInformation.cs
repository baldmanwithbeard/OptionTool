namespace SampleSolution.Domain.Entities
{
    public class OptionInformation : BaseEntity
    {
        public string OptionId { get; set; }
        public string OptionSequence { get; set; }
        public string Label { get; set; }
        public long? TranslationId { get; set; }
        public ValueType ValueType { get; set; }
        public ValueLookupObject ValueLookupObject { get; set; }
        public ValueEnumGroup ValueEnumGroup { get; set; }
        public OptionTree OptionTree { get; set; }
    }
}