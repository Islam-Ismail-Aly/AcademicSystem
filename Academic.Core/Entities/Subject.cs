using Academic.Core.Abstraction;

namespace Academic.Core.Entities
{
    public class Subject : BaseEntity
    {
        public double MinDegree { get; set; }
        public double MaxDegree { get; set; }
    }
}
