﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;
using DataAccessLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtSehir.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            ent.Gorev = txtGorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(txtId.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(txtId.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtSehir.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            ent.Gorev = txtGorev.Text;
            LogicPersonel.LLPersonelGuncelle(ent);
        }
    }
}
