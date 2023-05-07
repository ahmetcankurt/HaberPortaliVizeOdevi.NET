using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberPortali.ViewModels
{
    public class YorumModel
    {
        public int YorumId { get; set; }
        public string YorumIcerik { get; set; }
        public int UyeId { get; set; }
        public int HaberId { get; set; }
        public string Tarih { get; set; }

        public string UyeAdi { get; set; }
        public UyeModel UyeBilgisi { get; set; }
        public string HaberAdi { get; set; }
        public HaberModel HaberBilgisi { get; set; }
    }
}