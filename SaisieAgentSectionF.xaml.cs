using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for SaisieAgentSectionF.xaml
    /// </summary>
    public partial class SaisieAgentSectionF : Window
    {
        String valueradio = "";
        public SaisieAgentSectionF()
        {
            InitializeComponent();
            // appel de la fontion qui charge le nom des produits 
            LoadNameProduit();
            //appel de la fonction qui charge les noms des sections
            LoadSection();
            //MessageBox.Show("nom est " + Global.nom);
            //MessageBox.Show("passe est " + Global.pass);
        }
        private void LoadNameProduit()
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

                    cmd.CommandText = "select id_produit, nom_produit from IPPI_Produit";

                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeProd_bis = new DataTable();

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeProd_bis);

                    // lier la Datatable au combobox

                    cb_produit.DataContext = listeProd_bis;

                    //indiquer la colonne à afficher 

                    cb_produit.DisplayMemberPath = "nom_produit";

                    //indiquer la colonne qui représente la valeur de chaque element 

                    cb_produit.SelectedValuePath = "id_produit";



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



                    cmd.CommandText = "select*from IPPI_Section where id_section='F'";
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

    

        private void btnNextIII_Click(object sender, RoutedEventArgs e)
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
                    //MessageBox.Show("Connexion ok");

                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;

                    String idsection =cb_nom_section.SelectedValue.ToString();
                    int idproduct = Convert.ToInt32(cb_produit.SelectedValue.ToString());
                    int freqservice = Convert.ToInt32(cb_freqservice.SelectedValue.ToString());
                    String ntsrv = txt_natserv.Text.ToString();
                    String raisonsoc = txt_raisonsoc.Text.ToString();
                    String adress = txt_adress.Text.ToString();

                   // recuperation des valeurs du mois et de l'annee

                    int mois = Convert.ToInt32(cb_mois.SelectedValue.ToString());
                    int annee = Convert.ToInt32(cb_annee.SelectedValue.ToString());

                    // recuperation des valeurs du radio button 

                    String exist_contrat = valueradio;

                    //cmd2.CommandText = "SET IDENTITY_INSERT IPPI_IINFOS_SECTION_F ON";

                    cmd.CommandText = "insert into IPPI_IINFOS_SECTION_F(id_produit, nature_service, frequence_serv, existence_contrat,mois, annee, raison_soc, id_section, adresse) values('" + idproduct + "','" + ntsrv + "','" + freqservice + "','" + exist_contrat + "','" + mois + "','" + annee + "','"+raisonsoc +"','"+idsection+"','"+adress+ "')";

                    //cmd2.ExecuteNonQuery();

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        MessageBox.Show("La saisie a été bien enrégistrée");

                        // reinitialiser du formulaire
                        cb_nom_section.SelectedIndex = -1;
                        cb_produit.SelectedIndex = -1;
                        cb_freqservice.SelectedIndex = -1;
                        cb_mois.SelectedIndex = -1;
                        cb_annee.SelectedIndex = -1;


                        txt_natserv.Text = "";
                        txt_raisonsoc.Text = "";
                        txt_adress.Text = "";


                        // On revient à la page de début du questionnaire



                        SaisieAgentIdentification mo4 = new SaisieAgentIdentification(Global.nom, Global.pass);
                        mo4.Show();
                        MessageBox.Show("Afin de continuer, veuillez selectionner une autre entreprise à saisir, sinn pressez le bouton en haut à droite pour sortir de l'application ");

                        this.Visibility = Visibility.Hidden;
                      

                    }
                    else
                    {
                        MessageBox.Show("erreur de connexion -- Ajout");
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

        public void rb_oui_Checked(object sender, RoutedEventArgs e)
        {
            valueradio = "Oui";
        }

        public void rb_non_Checked(object sender, RoutedEventArgs e)
        {
            valueradio = "Non";
        }

       

       

      
    }
}
