using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportShellDTO
    {
        [JsonProperty(nameof(ShellWeight))]
        public double ShellWeight { get; set; }

        [JsonProperty(nameof(Caliber))]
        public string Caliber { get; set; }


        [JsonProperty(nameof(Guns))]
        public ExportGunJsonDto[] Guns { get; set; }
    }
}
