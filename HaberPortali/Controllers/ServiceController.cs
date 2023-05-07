using HaberPortali.Models;
using HaberPortali.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HaberPortali.Controllers
{
    public class ServiceController : ApiController
    {
        HaberPortaliEntities1 db = new HaberPortaliEntities1();
        SonucModel sonuc = new SonucModel();


        ////////////////////////////////////////////////////////////////////////*    Uye    */////////////////////

        #region Uye
        [HttpGet]
        [Route("api/uyelistele")]
        public List<UyeModel> UyeListele()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                UyeId = x.UyeId,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Email = x.Email,
                Sifre = x.Sifre,
                kullaniciAdi = x.kullaniciAdi,
                Yetki = x.Yetki

            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]
        public UyeModel UyeById(int UyeId)
        {
            UyeModel kayit = db.Uye.Where(s => s.UyeId == UyeId).Select(x => new UyeModel()
            {
                UyeId = x.UyeId,
                Adi = x.Adi,
                Soyadi = x.Soyadi,
                Email = x.Email,
                Sifre = x.Sifre,
                kullaniciAdi = x.kullaniciAdi,
                Yetki = x.Yetki

            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s => s.kullaniciAdi == model.kullaniciAdi && s.Email == model.Email) > 0)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Uye Kayıtlıdır";
                return sonuc;
            }
            Uye yeni = new Uye();
            yeni.Adi = model.Adi;
            yeni.Soyadi = model.Soyadi;
            yeni.Email = model.Email;
            yeni.Sifre = model.Sifre;
            yeni.kullaniciAdi = model.kullaniciAdi;
            yeni.Yetki = model.Yetki;
            db.Uye.Add(yeni);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Yeni Uye Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.UyeId == model.UyeId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Uye Bulunamadı";
                return sonuc;
            }
            kayit.Adi = model.Adi;
            kayit.Soyadi = model.Soyadi;
            kayit.Email = model.Email;
            kayit.Sifre = model.Sifre;
            kayit.kullaniciAdi = model.kullaniciAdi;
            kayit.Yetki = model.Yetki;
            sonuc.Islem = true;
            sonuc.Mesaj = "Uye Güncellendi";
            db.SaveChanges();

            return sonuc;
        }

        [HttpDelete]
        [Route("api/uyesil/{uyeId}")]

        public SonucModel UyeSil(int uyeId)
        {
            Uye kayit = db.Uye.Where(s => s.UyeId == uyeId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Uye Bulunamadı";
                return sonuc;
            }
            if (db.Haber.Count(s => s.UyeId == uyeId) > 0)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Bu üyeye kayıtlı haber olduğu için silinemez";
                return sonuc;
            }
            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Uye Silindi";
            return sonuc;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////*    Kategori    */////////////////////
        #region Kategori
        [HttpGet]
        [Route("api/kategorilistele")]
        public List<KategoriModel> KategoriListele()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                KategoriId = x.KategoriId,
                KategoriAdi = x.KategoriAdi,

            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{kategoriId}")]
        public KategoriModel KategoriById(int KategoriId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.KategoriId == KategoriId).Select(x => new KategoriModel()
            {
                KategoriId = x.KategoriId,
                KategoriAdi = x.KategoriAdi,

            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s => s.KategoriAdi == model.KategoriAdi) > 0)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kategori Kayıtlıdır";
                return sonuc;
            }
            Kategori yeni = new Kategori();
            yeni.KategoriAdi = model.KategoriAdi;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Yeni Kategori Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.KategoriId == model.KategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kategori Bulunamadı";
                return sonuc;
            }
            kayit.KategoriAdi = model.KategoriAdi;
            sonuc.Islem = true;
            sonuc.Mesaj = "Kategori Güncellendi";
            db.SaveChanges();

            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{kategoriId}")]

        public SonucModel KategoriSil(int kategoriId)
        {
            Kategori kayit = db.Kategori.Where(s => s.KategoriId == kategoriId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Kategori Bulunamadı";
                return sonuc;
            }
            if (db.Haber.Count(s => s.KategoriId == kategoriId) > 0)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Bu üyeye kayıtlı haber olduğu için silinemez";
                return sonuc;
            }
            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Kategori Silindi";
            return sonuc;
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////*    Haber    */////////////////////
        #region Haber
        [HttpGet]
        [Route("api/haberlistele")]
        public List<HaberModel> HaberListele()
        {
            List<HaberModel> liste = db.Haber.Select(x => new HaberModel()
            {
                HaberId = x.HaberId,
                HaberBasligi = x.HaberBasligi,
                HaberManseti = x.HaberManseti,
                HaberYazisi = x.HaberYazisi,
                HaberKayitTarihi = x.HaberYazisi,
                HaberResim = x.HaberYazisi,
                UyeId = x.UyeId,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.KategoriAdi,
                UyeAdi = x.Uye.Adi,


            }).ToList();
            
            return liste;
        }

        [HttpGet]
        [Route("api/haberbyid/{haberId}")]
        public HaberModel HaberById(int HaberId)
        {
            HaberModel kayit = db.Haber.Where(s => s.HaberId == HaberId).Select(x => new HaberModel()
            {
                HaberId = x.HaberId,
                HaberBasligi = x.HaberBasligi,
                HaberManseti = x.HaberManseti,
                HaberYazisi = x.HaberYazisi,
                HaberKayitTarihi = x.HaberYazisi,
                HaberResim = x.HaberYazisi,
                KategoriAdi = x.Kategori.KategoriAdi,
                UyeAdi = x.Uye.Adi,

                UyeId = x.UyeId,
                KategoriId = x.KategoriId,


            }).FirstOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/haberekle")]
        public SonucModel HaberEkle(HaberModel model)
        {
            ////// Cumhurbaşkanı bu senede gelebilir gelecek senede gelebilir kontrol yapmak mantıklı değil
            Haber yeni = new Haber();
            yeni.HaberBasligi = model.HaberBasligi;
            yeni.HaberManseti = model.HaberManseti;
            yeni.HaberYazisi = model.HaberYazisi;
            yeni.HaberKayitTarihi = model.HaberKayitTarihi;
            yeni.HaberResim = model.HaberResim;
            yeni.KategoriId = model.KategoriId;
            yeni.UyeId = model.UyeId;

            db.Haber.Add(yeni);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Yeni Haber Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/haberduzenle")]
        public SonucModel HaberDuzenle(HaberModel model)
        {
            Haber kayit = db.Haber.Where(s => s.HaberId == model.HaberId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Haber Bulunamadı";
                return sonuc;
            }
            kayit.HaberBasligi = model.HaberBasligi;
            kayit.HaberManseti = model.HaberManseti;
            kayit.HaberYazisi = model.HaberYazisi;
            kayit.HaberKayitTarihi = model.HaberKayitTarihi;
            kayit.HaberResim = model.HaberResim;
            kayit.KategoriId = model.KategoriId;
            kayit.UyeId = model.UyeId;

            sonuc.Islem = true;
            sonuc.Mesaj = "Haber Güncellendi";
            db.SaveChanges();

            return sonuc;
        }

        [HttpDelete]
        [Route("api/habersil/{haberId}")]

        public SonucModel HaberSil(int haberId)
        {
            /////haber silinecekse yorumlar varsa kontrol etmenin mantığı yok yorumlarda silinmesi gerekiyor aşşağıda yazdım zaten;
            Haber kayit = db.Haber.Where(s => s.HaberId == haberId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Haber Bulunamadı";
                return sonuc;
            }
            //if (db.Haber.Count(s => s.HaberId == haberId) > 0)
            //{
            //    sonuc.Islem = false;
            //    sonuc.Mesaj = "Bu habere kayıtlı yorum olduğu için silinemez";
            //    return sonuc;
            //}
            db.Haber.Remove(kayit);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Haber Silindi";
            return sonuc;
        }
        #endregion


        /////////////////////////////////////////////////////////////////////////*    Yorum    */////////////////////

        #region Yorum
        [HttpGet]
        [Route("api/yorumlistele")]
        public List<YorumModel> YorumListele()
        {
            List<YorumModel> liste = db.Yorum.Select(x => new YorumModel()
            {
                YorumId = x.YorumId,
                YorumIcerik = x.YorumIcerik,
                UyeId = x.UyeId,
                HaberId = x.HaberId,
                Tarih = x.Tarih,
                UyeAdi = x.Uye.Adi,
                HaberAdi = x.Haber.HaberBasligi,
                
            }).ToList();

            foreach (var kayit in liste)
            {
                kayit.HaberBilgisi = HaberById(kayit.HaberId);
                kayit.UyeBilgisi = UyeById(kayit.UyeId);
            }
            return liste;
        }

        [HttpGet]
        [Route("api/yorumbyid/{yorumId}")]
        public YorumModel YorumById(int yorumId)
        {
            YorumModel kayit = db.Yorum.Where(s => s.YorumId == yorumId).Select(x => new YorumModel()
            {
                YorumId = x.YorumId,
                YorumIcerik = x.YorumIcerik,
                UyeId = x.UyeId,
                HaberId = x.HaberId,
                Tarih = x.Tarih,
                UyeAdi = x.Uye.Adi,
                HaberAdi = x.Haber.HaberBasligi,
                HaberBilgisi = new HaberModel()
                {
                    HaberId = x.Haber.HaberId,
                    HaberBasligi = x.Haber.HaberBasligi,
                    HaberManseti = x.Haber.HaberManseti,
                    HaberYazisi = x.Haber.HaberYazisi,
                    HaberKayitTarihi = x.Haber.HaberYazisi,
                    HaberResim = x.Haber.HaberYazisi,
                    KategoriAdi = x.Haber.Kategori.KategoriAdi,
                    UyeAdi = x.Uye.Adi,
                    UyeId = x.UyeId,
                    KategoriId = x.Haber.KategoriId,
                },
                UyeBilgisi = new UyeModel
                {
                    UyeId = x.Uye.UyeId,
                    Adi = x.Uye.Adi,
                    Soyadi = x.Uye.Soyadi,
                    Email = x.Uye.Email,
                    Sifre = x.Uye.Sifre,
                    kullaniciAdi = x.Uye.kullaniciAdi,
                    Yetki = x.Uye.Yetki
                }
            }).FirstOrDefault();

            return kayit;
        }


        [HttpPost]
        [Route("api/yorumekle")]
        public SonucModel YorumEkle(YorumModel model)
        {
            Yorum yeni = new Yorum();
            yeni.YorumIcerik = model.YorumIcerik;
            yeni.UyeId = model.UyeId;
            yeni.HaberId = model.HaberId;
            yeni.Tarih = model.Tarih;

            db.Yorum.Add(yeni);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Yeni Yorum Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/yorumduzenle")]
        public SonucModel YorumDuzenle(YorumModel model)
        {
            Yorum kayit = db.Yorum.Where(s => s.YorumId == model.YorumId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Yorum Bulunamadı";
                return sonuc;
            }

            kayit.YorumIcerik = model.YorumIcerik;
            kayit.UyeId = model.UyeId;
            kayit.HaberId = model.HaberId;
            kayit.Tarih = model.Tarih;

            sonuc.Islem = true;
            sonuc.Mesaj = "Yorum Güncellendi";
            db.SaveChanges();

            return sonuc;
        }

        [HttpDelete]
        [Route("api/yorumsil/{yorumId}")]

        public SonucModel YorumSil(int yorumId)
        {
            Yorum kayit = db.Yorum.Where(s => s.YorumId == yorumId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.Islem = false;
                sonuc.Mesaj = "Yorum Bulunamadı";
                return sonuc;
            }
            db.Yorum.Remove(kayit);
            db.SaveChanges();
            sonuc.Islem = true;
            sonuc.Mesaj = "Yorum Silindi";
            return sonuc;
        }
        #endregion

    }
}
