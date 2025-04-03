﻿using Arguments.Arguments.Enum;
using Infrastructure.Persistence.EFCore.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence.EFCore.Entity.Registration.Node
{
    public class FineNode : BaseEntity
    {
        [Required]
        public string Code { get; set; }
        public string? NodeConsultation { get; private set; } = string.Empty;
        public string? Node { get; private set; } = "Multa";
        public string? Type { get; private set; } = string.Empty;
        public double? Value { get; private set; } = 0.0;
        public string? Article { get; private set; } = string.Empty;
        public EnumSeverityType? Severity { get; private set; }

        public FineNode(string code, string nodeConsultation)
        {
            Code = code;
            NodeConsultation = nodeConsultation;
        }

        public FineNode(string code, string? node, string? type, double? value, string? article, EnumSeverityType? severity)
        {
            Code = code;
            Node = node;
            Type = type;
            Value = value;
            Article = article;
            Severity = severity;
        }
    }
}