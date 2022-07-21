using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace IPPI_projet
{
    /// <summary>
    /// Interaction logic for SaisieAgentSectionCDF.xaml
    /// </summary>
    public partial class SaisieAgentSectionCDF : Window
    {
        String SigleEntreprise;
        int prod;
        public SaisieAgentSectionCDF(int val_cb_index)
        {
            InitializeComponent();

            // Affecter la valeur par défaut au combobox
            cb_entreprise.SelectedIndex = val_cb_index;

            // Desactiver l'usage du bouton 
            cb_entreprise.IsEnabled = false;

            //MessageBox.Show("nom est " + Global.nom);
            //MessageBox.Show("passe est " + Global.pass);

            // appel de la fonction qui charge les noms des entreprises
            LoadEntreprise();
            // appel de la fonction qui charge les noms des produits
            LoadProduit();
            // appel de la fonction qui charge les unités des produits correspondants
            LoadUniteProd();
            //appel de la fonction qui charge les noms des sections
            LoadSection();
        }
        private void cb_entreprise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // appel de la fonction qui charge les noms des Produits
            SigleEntreprise = cb_entreprise.SelectedValue.ToString();
            LoadProduit();
        }
        private void cb_nom_produit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // appel de la fonction qui charge les noms des unites
            prod =Convert.ToInt32(cb_nom_produit.SelectedValue.ToString());
            LoadUniteProd();
        }
        private void LoadEntreprise()
        {
            try
            {



                SqlConnection con = new SqlConnection();



                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;

                // ouverture de la connexion

                con.Open();

                // tester si la connexion est établie 
                if (con.State == System.Data.ConnectionState.Open)
                {

                    string sql = "select ID_utilisateur from IPPI_utilisateur where Prenom='"+Global.nom+"' and Mot_Passe = '"+Global.pass+"'";

                    SqlCommand cmd2 = new SqlCommand(sql, con);

                    int idread = (Int32)cmd2.ExecuteScalar();

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;

                    cmd.CommandText = "select  DISTINCT sigle from IPPI_Entreprise where ID_utilisateur=" + idread + "";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeEnt = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeEnt);

                    // lier la Datatable au combobox

                    cb_entreprise.DataContext = listeEnt;

                    //indiquer la colonne à afficher 

                    cb_entreprise.DisplayMemberPath = "sigle";

                    //indiquer la colonne qui rprésente la valeur de chaque element 

                    cb_entreprise.SelectedValuePath = "sigle";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. 

                MessageBox.Show(" Erreur =" + ex.Message);
            }
        }

        private void LoadProduit()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;

                // ouverture de la connexion

                con.Open();

                // tester si la connexion est établie 
                if (con.State == System.Data.ConnectionState.Open)
                {



                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;

                    // on fait la jointure avant d'afficher le nom des produits

                    cmd.CommandText = "select IPPI_Entreprise.id_produit, IPPI_Produit.Nom_produit from IPPI_Entreprise inner join IPPI_Produit on IPPI_Produit.id_produit = IPPI_Entreprise.id_produit where sigle ='" + SigleEntreprise + "'";

                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeProd = new DataTable();

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeProd);

                    // lier la Datatable au combobox

                    cb_nom_produit.DataContext = listeProd;

                    //indiquer la colonne à afficher 

                    cb_nom_produit.DisplayMemberPath = "Nom_produit";

                    //indiquer la colonne qui représente la valeur de chaque element 

                    cb_nom_produit.SelectedValuePath = "id_produit";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. 

                MessageBox.Show(" Erreur :" + ex.Message);
            }
        }

        private void LoadUniteProd()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;

                // ouverture de la connexion

                con.Open();

                // tester si la connexion est établie 
                if (con.State == System.Data.ConnectionState.Open)
                {



                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;

                    // on fait la jointure avant d'afficher le nom des produits

                    cmd.CommandText = "select IPPI_ProduitUnite.id_unite, IPPI_Unite.unite from IPPI_ProduitUnite INNER JOIN IPPI_Unite on IPPI_ProduitUnite.id_unite = IPPI_Unite.id_unite where id_produit = " + prod + "";

                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeUnite = new DataTable();

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeUnite);

                    // lier la Datatable au combobox

                    cb_nom_unite.DataContext = listeUnite;

                    //indiquer la colonne à afficher 

                    cb_nom_unite.DisplayMemberPath = "unite";

                    //indiquer la colonne qui représente la valeur de chaque element 

                    cb_nom_unite.SelectedValuePath = "id_unite";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. 

                MessageBox.Show(" Erreur :" + ex.Message);
            }
        }

        private void LoadSection()
        {
           

            try
            {



                SqlConnection con = new SqlConnection();



                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;

                // ouverture de la connexion

                con.Open();

                // tester si la connexion est établie 
                if (con.State == System.Data.ConnectionState.Open)
                {
                    // MessageBox.Show("Connexion ok");

                    //declaration d'un objet de commande SqlCommande

                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;



                    cmd.CommandText = "select*from IPPI_Section";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeSection = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeSection);

                    // lier la Datatable au combobox

                    cb_nom_section.DataContext = listeSection;

                    //indiquer la colonne à afficher 

                    cb_nom_section.DisplayMemberPath = "nom_section";

                    //indiquer la colonne qui rprésente la valeur de chaque element 

                    cb_nom_section.SelectedValuePath = "id_section";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. 

                MessageBox.Show(" Erreur =" + ex.Message);
            }
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_section.Visibility = Visibility.Collapsed;
                tt_sectionF.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_section.Visibility = Visibility.Visible;
                tt_sectionF.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.2;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.2;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNextII_Click(object sender, RoutedEventArgs e)
        {
            // Code pour l'insertion de la saisie de l'agent pour la partie Section CDE

            try
            {
                SqlConnection con = new SqlConnection();

                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;

                // ouverture de la connexion

                con.Open();

                // tester si la connexion est établie 
                if (con.State == System.Data.ConnectionState.Open)
                {

                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;



                    String SigleEnt = cb_entreprise.SelectedValue.ToString();
                    String idsection = cb_nom_section.SelectedValue.ToString();
                    int idproduct = Convert.ToInt32(cb_nom_produit.SelectedValue.ToString());
                    int idunite = Convert.ToInt32(cb_nom_unite.SelectedValue.ToString());

                    // Requete pour avoir l'identifiant de l'entreprise

                    string query = "select id_Entreprise from IPPI_Entreprise where sigle='" + SigleEnt + "' and id_produit = '" + idproduct + "'";

                    SqlCommand cmd2 = new SqlCommand(query, con);

                    int idEntRead = (Int32)cmd2.ExecuteScalar();

                    // Requete pour avoir le nom de la section correspondante

                    string query_bis = "select nom_section from IPPI_section where id_section = '" + idsection + "'";

                    SqlCommand cmd_bis = new SqlCommand(query_bis, con);

                    String namesection = (String)cmd_bis.ExecuteScalar();

                    // conversion en float 

                    string pvv = txt_prixvalvente.Text.ToString();
                    float prix_val_vente = float.Parse(pvv);

                    int mois = Convert.ToInt32(cb_mois.SelectedValue.ToString());
                    int annee = Convert.ToInt32(cb_annee.SelectedValue.ToString());

                    // pour avoir l'id d'infos section 

                    string str = idproduct + idsection;
                    
                    cmd.CommandText = "insert into IPPI_infos_section(id_infos_section, IPPI_Entreprise_id_Entreprise,IPPI_section_id_section, IPPI_unite_id_unite,IPPI_Produit_id_produit, nom_section, prix_val_vente, mois, annee) values('"+str+"','" + idEntRead + "','" + idsection + "','" + idunite + "','" + idproduct + "','" + namesection + "','" + prix_val_vente + "','" + mois + "','" + annee + "')";


                    int resultat = cmd.ExecuteNonQuery();

                    if (resultat > 0) {
                        //MessageBox.Show("ok" + prix_val_vente);

                        if (System.Windows.Forms.MessageBox.Show("Voulez vous choisir un autre produit et saisir pour ce produit?", "Message", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Reinitialisation directe du formulaire

                            txt_prixvalvente.Text = "";

                           //cb_nom_produit.SelectedIndex = -1;
                            cb_nom_unite.SelectedIndex = -1;
                            cb_nom_section.SelectedIndex = -1;

                            cb_mois.SelectedIndex = -1;
                            cb_annee.SelectedIndex = -1;
                        }
                        else
                        {

                            // Ouverture de la page suivante 

                            SaisieAgentSectionF mo3 = new SaisieAgentSectionF();
                            mo3.Show();

                            this.Visibility = Visibility.Hidden;
                        }
                 
                    }
                    else
                    {
                        MessageBox.Show("erreur d'execution");
                    }
                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }
            }
            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. Ce qui justifie l'ajout de AddProduit

                MessageBox.Show(" Erreur : " + ex.Message);
            }
           
            
        }

        

       

        
    }
}
