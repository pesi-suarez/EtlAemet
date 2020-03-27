using System;

namespace EtlAemet.Model
{
    public class StationData
    {
        public string idema { get; set; }
        public double lon { get; set; }
        public DateTime fint { get; set; }
        public double prec { get; set; }
        public double alt { get; set; }
        public double vmax { get; set; }
        public double vv { get; set; }
        public double dv { get; set; }
        public double lat { get; set; }
        public double dmax { get; set; }
        public string ubi { get; set; }
        public double pres { get; set; }
        public double hr { get; set; }
        public double stdvv { get; set; }
        public double ts { get; set; }
        public double pres_nmar { get; set; }
        public double tamin { get; set; }
        public double ta { get; set; }
        public double tamax { get; set; }
        public double tpr { get; set; }
        public double stddv { get; set; }
        public double inso { get; set; }
    }

}
