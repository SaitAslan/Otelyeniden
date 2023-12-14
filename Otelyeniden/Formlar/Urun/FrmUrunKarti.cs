using DevExpress.XtraEditors;
using Otelyeniden.Entity;
using Otelyeniden.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelyeniden.Formlar.Urun
{
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db = new DbOtelYeniEntities();
        Repository<TblUrun> repo = new Repository<TblUrun>();
        TblUrun t = new TblUrun();
        public int id;
        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            





            //Ürün Grup Listesi

            lookUpEditUrunGrup.Properties.DataSource = (from x in db.TblUrunGrup
                                                    select new
                                                    {
                                                        x.UrunGrupId,
                                                        x.UrunGrupAd
                                                    }).ToList();
            //Birim Listesi

            lookUpEditBirim.Properties.DataSource = (from x in db.TblBirim
                                                    select new
                                                    {
                                                        x.BirimId,
                                                        x.BirimAd
                                                    }).ToList();
            //Durum Listesi

            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum
                                                    select new
                                                    {
                                                        x.DurumId,
                                                        x.DurumAd
                                                    }).ToList();
            //ÜRün güncelleme alanı
            if (id != 0)
            {
                var urun = repo.Find(x => x.UrunId == id);
                TxtAd.Text = urun.UrunAd;
                lookUpEditUrunGrup.EditValue = urun.UrunGrup;
                lookUpEditBirim.EditValue = urun.Birim;
                TxtFiyat.Text = urun.Fiyat.ToString();
                TxtToplam.Text = urun.Toplam.ToString();
                TxtKdv.Text = urun.Kdv.ToString();
                lookUpEditDurum.EditValue=urun.Durum;

            }



        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
           
            t.UrunAd = TxtAd.Text;
            t.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            t.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            t.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            t.Fiyat=decimal.Parse(TxtFiyat.Text);
            t.Toplam=decimal.Parse(TxtToplam.Text);
            t.Kdv=byte.Parse(TxtKdv.Text);
            repo.TAdd(t);
            XtraMessageBox.Show("Ürün başarılı bir şekilde veri tabanına kayıt edildi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            var urundeger = repo.Find(x => x.UrunId == id);
            urundeger.UrunAd = TxtAd.Text;
            urundeger.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
            urundeger.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
            urundeger.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
            urundeger.Fiyat=decimal.Parse(TxtFiyat.Text);
            urundeger.Toplam=decimal.Parse(TxtToplam.Text);
            urundeger.Kdv=byte.Parse(TxtKdv.Text);
            repo.TUpdate(urundeger);
            XtraMessageBox.Show("Ürün başarılı bir şekilde güncellendi");
        }
    }
}
