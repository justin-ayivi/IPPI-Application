using System;
using System.Data;
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
using System.Data.SqlClient;
using System.Configuration;

namespace IPPI_projet
{
    /// <summary>
    /// Interaction logic for SaisieAgentIdentification.xaml
    /// </summary>
    static class Global
    {
        public static string nom;
        public static string pass;
    }

    public partial class SaisieAgentIdentification : Window
    {
        int ent_checked;
        public SaisieAgentIdentification(string username, string pass)
        {
            InitializeComponent();
            Global.nom = username;
            Global.pass = pass;
            //MessageBox.Show("nom est " + Global.nom);
            //MessageBox.Show("passe est " + Global.pass);

            // appel de la fonction qui charge les noms des entreprises
            LoadEntreprise();
            
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

                    string sql = "select ID_utilisateur from IPPI_utilisateur where Prenom='" + Global.nom + "' and Mot_Passe = '" + Global.pass + "'";

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

        private void btnNextI_Click(object sender, RoutedEventArgs e)
        {

            // Code pour l'insertion de la saisie de l'agent pour la partie Identification 

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

                    //SqlCommand cmd2 = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    //cmd2.Connection = con;

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire
                    // int id_entreprise = Convert.ToInt32(txt_idEnt.Text.ToString());
                    String sigent = cb_entreprise.SelectedValue.ToString();
                    ent_checked = cb_entreprise.SelectedIndex;
                    String name= txt_name.Text.ToString();
                    String fonction = txt_fonction.Text.ToString();
                    String tel = txt_tel_rep.Text.ToString();
                    String mail = txt_mail.Text.ToString();
                   


                    //cmd2.CommandText = "SET IDENTITY_INSERT IPPI_Entreprise ON";

                    cmd.CommandText = "update IPPI_Entreprise set nom_repondant='" + name + "', fonction_repondant ='" + fonction + "', tel_repondant='" + tel + "', email_repondant='" + mail +"' where sigle='" + sigent + "'";

                    //cmd2.ExecuteNonQuery();

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        
                        // reinitialisation du formulaire
                        
                        txt_name.Text = "";
                        txt_fonction.Text = "";
                        txt_tel_rep.Text = "";
                        txt_mail.Text = "";
                        cb_entreprise.SelectedIndex = -1;

                        // ouverture de la page suivante 
                        SaisieAgentSectionCDF mo2 = new SaisieAgentSectionCDF(ent_checked);
                        mo2.Show();

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
                //On peut avoir la meme erreur pour plusieurs executions.

                MessageBox.Show(" Erreur : " + ex.Message);
            }

            
          
        }

        
    }
}
