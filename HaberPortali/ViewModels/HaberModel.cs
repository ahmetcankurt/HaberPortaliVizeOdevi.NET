using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberPortali.ViewModels
{
    public class HaberModel
    {

        public int HaberId { get; set; }
        public string HaberBasligi { get; set; }
        public int UyeId { get; set; }
        public int KategoriId { get; set; }
        public string HaberManseti { get; set; }
        public string HaberYazisi { get; set; }
        public string HaberKayitTarihi { get; set; }
        public string HaberResim { get; set; }

        public string UyeAdi { get; set; }
        public string KategoriAdi { get; set; }
        public object HaberIcerik { get; internal set; }
    }
}