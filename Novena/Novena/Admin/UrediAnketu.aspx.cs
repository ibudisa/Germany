using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.Repositorys;

namespace Novena.Admin
{
    public partial class UrediAnketu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();


        }

        private void Bind()
        {
            DataManager datalist = new DataManager();
            var griddata = datalist.GetAnkete();
            GridViewAnketa.DataSource = griddata;
            GridViewAnketa.DataBind();
        }

        private void BindPitanja(int id)
        {
            DataManager dataManager = new DataManager();

            var data = dataManager.GetPitanja(id);

            GridViewPitanja.DataSource = data;
            GridViewPitanja.DataBind();
        }

        private void BindOdgovori(int pitanjeid)
        {
            DataManager dataManager = new DataManager();

            var data = dataManager.GetOdgovori(pitanjeid);
            GridViewOdgovori.DataSource = data;
            GridViewOdgovori.DataBind();
        }

        public List<Anketa> GetListAnketa()
        {
            return new List<Anketa>();
        }

        public List<Odgovor> GetListOdgovora()
        {
            return new List<Odgovor>();
        }

        public List<Pitanje> GetListPitanja()
        {
            return new List<Pitanje>();
        }

        private void Generate(int id)
        {

            //int i = 1;
            //DataManager data = new DataManager();
            //var anketa = data.GetJednaAnketa(id);

            //txtDatum.Text = anketa.Datum.ToString();
            //txtPitanje.Text = anketa.Pitanje;

            //myLiteral.Text = "<table>";

            //foreach (var a in anketa.Odgovors)
            //{
            //    myLiteral.Text += "<tr>" + "<td>" + i + ".odgovor" + "</td>" + "<td>" + a.TekstOdgovora + "</td>" +
            //                   "</tr>";
            //    i++;
            //}

            //myLiteral.Text += "</table>";

            //ViewState["ID"] = id;
        }

        protected void GridViewAnketa_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            PanelDetalji.Visible = true;

            string idw = GridViewAnketa.Rows[e.NewSelectedIndex].Cells[1].Text;
            int id = int.Parse(idw);

            BindPitanja(id);

            ViewState["ID"] = id;


        }



        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            //string odgovordata = txtOdgovor.Text;
            //int id = (int)ViewState["ID"];
            ////bool datummijenjan = (bool)ViewState["DatumPromijenjen"];
            ////bool pitanjemijenjano = (bool)ViewState["PitanjePromijenjeno"];
            //DataManager dataManager = new DataManager();
            //var anketa = dataManager.GetJednaAnketa(id);

            //anketa.Datum =  DateTime.Parse(txtDatum.Text);
            //anketa.Pitanje = txtPitanje.Text;
            //if ((!String.IsNullOrEmpty(odgovordata))|| (!String.IsNullOrWhiteSpace(odgovordata)))
            //{
            //    Odgovor odgovor = new Odgovor();
            //    odgovor.Anketa = anketa;
            //    odgovor.AnketaId = id;
            //    odgovor.TekstOdgovora = odgovordata;
            //    odgovor.Aktivan = true;
            //    odgovor.Tocan = false;
            //    anketa.Odgovors.Add(odgovor);
            //}



            //dataManager.Izmjeni(anketa);

            //Bind();
            //Generate(id);

        }

        protected void txtPitanje_TextChanged(object sender, EventArgs e)
        {
            ViewState["PitanjePromijenjeno"] = true;
        }

        protected void txtDatum_TextChanged(object sender, EventArgs e)
        {
            ViewState["DatumPromijenjen"] = true;
        }

        protected void GridViewPitanja_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            pnlOdgovori.Visible = true;

            string idw = GridViewPitanja.Rows[e.NewSelectedIndex].Cells[1].Text;
            int id = int.Parse(idw);

            BindOdgovori(id);

            ViewState["PitanjeID"] = id;
        }

        protected void GridViewPitanja_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("ADD_NEW_ROW"))
            {
                TextBox txt_anketaId = GridViewPitanja.FooterRow.FindControl("txtAnketaId") as TextBox;
                TextBox txt_tekstpitanja = GridViewPitanja.FooterRow.FindControl("txtTekstPitanja") as TextBox;

                Pitanje ptanje = new Pitanje();

                ptanje.AnketaId = int.Parse(txt_anketaId.Text);
                ptanje.TekstPitanja = txt_tekstpitanja.Text;

                DataManager manager = new DataManager();

                manager.AddPitanje(ptanje);
            }

            int id = (int)ViewState["ID"];

            BindPitanja(id);
        }

        protected void GridViewOdgovori_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewOdgovori.EditIndex = e.NewEditIndex;
            int id = (int)ViewState["PitanjeID"];
            BindOdgovori(id);
        }

        protected void GridViewOdgovori_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string id = GridViewOdgovori.Rows[e.RowIndex].Cells[1].Text;
            int IdOdg = Convert.ToInt32(GridViewOdgovori.DataKeys[e.RowIndex].Value);
            //TextBox txt_pitanjeId = GridViewOdgovori.Rows[e.RowIndex].FindControl("txtPitanjeId") as TextBox;
            //TextBox txt_tekstodgovora = GridViewOdgovori.Rows[e.RowIndex].FindControl("txtTekstOdgovora") as TextBox;
            //CheckBox checkBoxAktivan = GridViewOdgovori.Rows[e.RowIndex].FindControl("chkAktivan") as CheckBox;
            //CheckBox checkBoxTocan = GridViewOdgovori.Rows[e.RowIndex].FindControl("chkTocan") as CheckBox;
            string pitanjeid = e.NewValues["PitanjeId"].ToString();
            string tekstodgovora = e.NewValues["TekstOdgovora"].ToString();
            bool Aktivan = (bool)e.NewValues["Aktivan"];
            bool Tocan = (bool)e.NewValues["Tocan"];
            Odgovor odgovor = new Odgovor();
            odgovor.Id = IdOdg;
            odgovor.PitanjeId = int.Parse(pitanjeid);
            odgovor.TekstOdgovora = tekstodgovora;
            odgovor.Aktivan = Aktivan;
            odgovor.Tocan = Tocan;

            DataManager dataManager = new DataManager();

            dataManager.UpdateOdgovor(odgovor);

            GridViewOdgovori.EditIndex = -1;

            int arg = (int)ViewState["PitanjeID"];
            BindOdgovori(arg);

        }

        protected void GridViewOdgovori_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewOdgovori.EditIndex = -1;
            int id = (int)ViewState["PitanjeID"];
            BindOdgovori(id);
        }

        protected void GridViewOdgovori_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewOdgovori_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int IdOdg = Convert.ToInt32(GridViewOdgovori.DataKeys[e.RowIndex].Value);
            DataManager dataManager = new DataManager();
            dataManager.DeleteOdgovor(IdOdg);

            int arg = (int)ViewState["PitanjeID"];
            BindOdgovori(arg);
        }

        protected void GridViewOdgovori_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("ADD_NEW"))
            {
                TextBox txt_pitanjeId = GridViewOdgovori.FooterRow.FindControl("txtPitanjeId1") as TextBox;
                TextBox txt_tekstodgovora = GridViewOdgovori.FooterRow.FindControl("txtTekstOdgovora1") as TextBox;
                CheckBox chkAktivan = GridViewOdgovori.FooterRow.FindControl("chkAktivan1") as CheckBox;
                CheckBox chkTocan = GridViewOdgovori.FooterRow.FindControl("chkTocan1") as CheckBox;

                Odgovor odgovor = new Odgovor();

                odgovor.Aktivan = chkAktivan.Checked;
                odgovor.PitanjeId = int.Parse(txt_pitanjeId.Text);
                odgovor.TekstOdgovora = txt_tekstodgovora.Text;
                odgovor.Tocan = chkTocan.Checked;

                DataManager manager = new DataManager();

                manager.AddOdgovor(odgovor);


            }

            int id = (int)ViewState["PitanjeID"];
            BindOdgovori(id);
        }

         
    }
}