using Otelyeniden.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelyeniden.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        DbOtelYeniEntities db=new DbOtelYeniEntities();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman
                                                         select new
                                                         {
                                                             x.DepartmanId,
                                                             x.DepartmanAd
                                                         }).ToList();
            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev
                                                         select new
                                                         {
                                                             x.GorevId,
                                                             x.GorevAd
                                                         }).ToList();

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            TxtAdres.Text = PictureEditKimlikOn.GetLoadedImageLocation();
        }
    }
}
