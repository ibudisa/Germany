using DAL.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Novena
{
    public partial class AnketaNew : System.Web.UI.Page
    {
        private int pitanjeid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataManager dataManager = new DataManager();
                Anketa anketa = dataManager.GetLatest();
                dataManager.DeleteStatistika();
                lblPitanje.Text = anketa.Pitanjes.FirstOrDefault().TekstPitanja;
                var pitanje = anketa.Pitanjes.FirstOrDefault();
                Generate(pitanje);
                ViewState["pitanjeid"] = 0;
                
            }

            else
            {
                DataManager dataManager = new DataManager();
               string value = rbtnlistPitanja.SelectedItem.Text;
               string id = rbtnlistPitanja.SelectedValue;
                Odgovor odgovor = dataManager.GetOdgovor(int.Parse(id));
                Pitanje pitanje = odgovor.Pitanje;
                int idpitanja = pitanje.Id;
               StoreValue(id);
               StoreStatistika(id,idpitanja);
                //Application["pitanjeid"] = (int)Application["pitanjeid"] + 1;
                int pitanjeid = (int)ViewState["pitanjeid"];
                pitanjeid++;
                ViewState["pitanjeid"] = pitanjeid;
            }
            
            //ViewState["pitanjeid"] = 0;
        }

        private void Generate(Pitanje pt)
        {
            List<Odgovor> list = pt.Odgovors.ToList();
            lblPitanje.Text = pt.TekstPitanja;
            rbtnlistPitanja.DataSource = list;
            rbtnlistPitanja.DataBind();
             

        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {

            string value = string.Empty;
            string id = string.Empty;
            Anketa anketa = null;
            int pitanjeid = 0;
            string answer = "Završeno";
            Pitanje pitanje;

            //RadioButtonList RbxList = (RadioButtonList)Page.FindControl("rbtnlistPitanja");

            if(rbtnlistPitanja.DataSource==null)
            {
                DataManager dataManager = new DataManager();
                pitanje = dataManager.GetLatestPitanje();
                //pitanjeid =(int)ViewState["pitanjeid"];
                //pitanjeid++;
                //ViewState["pitanjeid"] = pitanjeid;
                if (pitanje!=null)
                {
                    //Pitanje p = anketa.Pitanjes.ToList()[pitanjeid];
                    Generate(pitanje);
                }
                else
                {
                    double val = dataManager.GetRezultat();
                    answer = val * 100 + "%";
                    Response.Redirect("RezultatAnkete.aspx?odgovor=" + answer);
                }
            }

            //for (int i = 0; i < rbtnlistPitanja.Items.Count; i++)
            //{
            //    if (rbtnlistPitanja.Items[i].Selected)
            //    {
            //value = rbtnlistPitanja.SelectedItem.Text;
            //id = rbtnlistPitanja.SelectedValue;
            ////    }
            ////}

            //StoreValue(id);

            

            rbtnlistPitanja.DataSource = null;
        }

        private void StoreValue(string data)
        {
            string answer = string.Empty;
            DataManager dataManager = new DataManager();
            Odgovor odgovor = dataManager.GetOdgovor(int.Parse(data));

            int? item = odgovor.BrojOdgovora;

            item++;

            odgovor.BrojOdgovora = item;
            dataManager.UpdateOdgovor(odgovor);

            //answer = "Netočan odgovor";

            //foreach(var item in anketa.Odgovors)
            //{
            //    if(item.TekstOdgovora.Equals(data))
            //    {
            //        if(item.Tocan==true)
            //        {
            //            answer = "Točan odgovor";
            //        }
            //    }
            //}

            
        }

        private void StoreStatistika(string id,int pitanjeid)
        {
            int odgid = int.Parse(id);
            Statistika statistika = new Statistika();
            statistika.IdOdgovora = odgid;
            statistika.IdPitanja = pitanjeid;
            DataManager manager = new DataManager();
            manager.AddRezultat(statistika);
        }
    }
}