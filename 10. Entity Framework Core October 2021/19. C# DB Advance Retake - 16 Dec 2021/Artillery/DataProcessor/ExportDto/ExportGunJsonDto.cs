using Newtonsoft.Json;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportGunJsonDto
    {
        [JsonProperty(nameof(GunType))]
        public string GunType { get; set; }

        [JsonProperty(nameof(GunWeight))]
        public int GunWeight { get; set; }

        [JsonProperty(nameof(BarrelLength))]
        public double BarrelLength { get; set; }

        [JsonProperty(nameof(Range))]
        public string Range { get; set; }


    }
}