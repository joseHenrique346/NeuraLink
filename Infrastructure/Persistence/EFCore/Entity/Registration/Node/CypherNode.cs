using Infrastructure.Persistence.EFCore.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.Node
{
    public class CypherNode : BaseEntity
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string? NodeConsultation { get; private set; }
        public string? Node { get; private set; }
        public string? Type { get; private set; }
        public double? Value { get; private set; }
        public string? Article { get; private set; }
        public string? Severity { get; private set; }

        public CypherNode(string nodeConsultation)
        {
            NodeConsultation = nodeConsultation;
        }
    }
}