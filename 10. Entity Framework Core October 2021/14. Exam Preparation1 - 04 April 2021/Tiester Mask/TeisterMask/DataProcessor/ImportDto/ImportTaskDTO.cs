namespace TeisterMask.DataProcessor.ImportDto
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Task")]
    public class ImportTaskDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(EntityConstants.TASK_NAME_MIN_LENGTH)]
        [MaxLength(EntityConstants.TASK_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        [Range(EntityConstants.TASK_EXECITION_TYPE_MIN_VALUE, EntityConstants.TASK_EXECITION_TYPE_MAX_VALUE)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        [Range(EntityConstants.TASK_LABEL_TYPE_MIN_VALUE, EntityConstants.TASK_LABEL_TYPE_MAX_VALUE)]
        public int LabelType { get; set; }

    }
}
