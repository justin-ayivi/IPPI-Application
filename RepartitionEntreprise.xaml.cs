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
using System.Windows.Shapes;

namespace IPPI_projet
{
    /// <summary>
    /// Interaction logic for RepartitionEntreprise.xaml
    /// </summary>
    public partial class RepartitionEntreprise : Window
    {
        int idsup;
      
        public RepartitionEntreprise()
        {
            InitializeComponent();

           
            // fonction qui permet d'afficher les entreprises 
            displayent();
            // appel de la fonction qui charge les noms des superviseurs
            LoadAgentSup();

            // appel de la fonction qui charge les noms des agents
            LoadAgent();
        }

        private void cb_supervisor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // appel de la fonction qui charge les noms des agents
             idsup = Convert.ToInt32(cb_supervisor.SelectedValue.ToString());
             LoadAgent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void displayent()
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


                    cmd.Connection = con;


                    cmd.CommandText = "select raison_soc, sigle,adresse, telephone, ID_Utilisateur from IPPI_Entreprise";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listEnt = new DataTable(); 

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listEnt.Load(dr);

                    dg_listEnt.ItemsSource = listEnt.DefaultView;


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

        private void LoadAgentSup()
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



                    cmd.CommandText = "select*from IPPI_superviseur where id_superviseur<98 order by nom_superviseur";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeSupervisor = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeSupervisor);

                    // lier la Datatable au combobox

                    cb_supervisor.DataContext = listeSupervisor;

                    //indiquer la colonne à afficher 

                    cb_supervisor.DisplayMemberPath = "nom_superviseur";

                    //indiquer la colonne qui rprésente la valeur de chaque element 

                    cb_supervisor.SelectedValuePath = "id_superviseur";



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
        private void LoadAgent()
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

                   

                    cmd.CommandText = "select ID_utilisateur, prenom from IPPI_Utilisateur where id_superviseur ="+idsup+" and Identifiant <> 'Superviseur'";
 
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeAgent = new DataTable(); 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeAgent);

                    // lier la Datatable au combobox

                    cb_agent.DataContext = listeAgent;

                    //indiquer la colonne à afficher 

                    cb_agent.DisplayMemberPath = "prenom";

                    //indiquer la colonne qui représente la valeur de chaque element 

                    cb_agent.SelectedValuePath = "ID_utilisateur";



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

       

        private void cb_agent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void affect_btnClick(object sender, RoutedEventArgs e)
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

                    cmd.Connection = con;

                    //String nom_superviseur = cb_supervisor.SelectedValue.ToString();
                    String prenom_agent  = cb_agent.Text.ToString();
                    String sigle_entreprise = txt_nameCompany.Text.ToString();

                    string sql = "select ID_utilisateur from IPPI_utilisateur where prenom='"+prenom_agent+"' and Identifiant = 'Agent'";

                    SqlCommand cmd2 = new SqlCommand(sql, con);

                    int idread = (Int32)cmd2.ExecuteScalar();

                    //MessageBox.Show("message - " + idread);
                    cmd.CommandText = "update IPPI_Entreprise set ID_utilisateur =" + idread + " where sigle ='" + sigle_entreprise + "'";
                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Entreprise bien affecté ");
                        //LoadProduit();

                        // reinitialiser le formulaire d'affecté

                        txt_nameCompany.Text = "";
                        displayent();


                    }
                    else
                    {
                        MessageBox.Show("Erreur de connexion: Veuillez selectionner une entreprise dans la liste à droite");
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

  

        private void dg_listEnt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView drow = dg.SelectedItem as DataRowView;
            if (drow != null)
            {
               
                txt_nameCompany.Text = drow["sigle"].ToString();

            }
        }

        private void search_btnClick(object sender, RoutedEventArgs e)
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


                    cmd.Connection = con;


                    cmd.CommandText = "select raison_soc, sigle,adresse, telephone, ID_Utilisateur from IPPI_Entreprise where sigle like'%" + txt_search.Text.ToString() + "%'";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listsearch = new DataTable();

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listsearch.Load(dr);

                    dg_listEnt.ItemsSource = listsearch.DefaultView;


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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

       

       
    }
}
