namespace Artillery.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Artillery.Common;
    using Artillery.Data.Models.Enums;

    public class ImportGunDTO
    {
        [Required]
        [JsonProperty(nameof(ManufacturerId))]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(EntityConstants.Gun_GunWeight_Min_Value, EntityConstants.Gun_GunWeight_Max_Value)]
        [JsonProperty(nameof(GunWeight))]
        public int GunWeight { get; set; }

        [Required]
        [Range(EntityConstants.Gun_BarrelLength_Min_Value, EntityConstants.Gun_BarrelLength_Max_Value)]
        [JsonProperty(nameof(BarrelLength))]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(EntityConstants.Gun_Range_Min_Value, EntityConstants.Gun_Range_Max_Value)]
        [JsonProperty(nameof(Range))]
        public int Range { get; set; }

        [Required]
        [EnumDataType(typeof(GunType))]
        [JsonProperty(nameof(GunType))]
        public string GunType { get; set; }

        [Required]
        [JsonProperty(nameof(ShellId))]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public ICollection<ImportCountryIdDTO> CountriesId { get; set; }

    }

}
   

