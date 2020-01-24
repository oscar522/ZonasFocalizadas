using System;
using System.Collections.Generic;

namespace AspNetIdentity.WebApi.Reports.Parts
{
    public class ReportParts
    {
        public HeaderPart headerPart { get; set; }
        public List<BodyPart> bodyParts { get; set; }
    }

    public class HeaderPart
    {
        public string Test { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string CoverPageImage { get; set; }
    }

    public class BodyPart
    {
        public int Id_Test { get; set; }
        public List<SectionParts> sectionParts { get; set; }
    }

    public class SectionParts
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Dictionary<string,int> Color { get; set; }
        public float Value { get; set; }
        public List<SectionParts> SubSections { get; set; }
    }
}