using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace HRApplication.Model
{
    [Serializable]
    [XmlRoot("employee")]
    public class EmployeeMetaModel
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("division")]
        public string Division { get; set; }

        [XmlElement("building")]
        public string Building { get; set; }

        [XmlElement("room")]
        public string Room { get; set; }
    }

    [MetadataType(typeof(EmployeeMetaModel))]
    public partial class EmployeeImport : EmployeeMetaModel
    {
    }
}