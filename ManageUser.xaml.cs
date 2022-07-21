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
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Window
    {

        
        public ManageUser()
        {
            InitializeComponent();
            // appel de la fonction 
            displayUser();

            // appel de la fonction qui charge les noms des superviseurs
            LoadAgentSup();
            
        }
       

        private void dg_listAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dg = sender as DataGrid;
            DataRowView drow = dg.SelectedItem as DataRowView;
            if (drow != null)
            {
                txt_user.Text=drow["ID_Utilisateur"].ToString();
                txt_lastname.Text = drow["Prenom"].ToString();
                txt_name.Text = drow["Nom"].ToString();
                txt_password.Password = drow["Mot_Passe"].ToString();
               // cb_identifiant.SelectedValue = drow["Identifiant"].ToString();


                int superviseur = Convert.ToInt32(drow["id_superviseur"].ToString());

                cb_supervisor.SelectedIndex = superviseur;
                
                
               // cb_supervisor.SelectedValue = drow["id_superviseur"].ToString();

                

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }




        private void LoadAgentSup()
        {
            try
            {

                // déclaration d'un objet connexion
                //namespace sont l'equivalent de library dans R car il faut importer la ibrairie 
                // il s'agit du meme cas; on appelle la reference qui permet de gerer les systemes de connexion car il ne connait pas par defaut le SqlConnection

                SqlConnection con = new SqlConnection();

                //ou

                // System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

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

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire

                    //int idCategorie = Convert.ToInt32(cb_categorieproduit.SelectedValue.ToString());
                    //string nomProd = txt_nomProd.Text;

                    cmd.CommandText = "select*from IPPI_superviseur where id_superviseur<98 order by nom_superviseur";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeSupervisor= new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

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
        private void displayUser()
        {
            try
            {

                // déclaration d'un objet connexion
                //namespace sont l'equivalent de library dans R car il faut importer la ibrairie 
                // il s'agit du meme cas; on appelle la reference qui permet de gerer les systemes de connexion car il ne connait pas par defaut le SqlConnection

                SqlConnection con = new SqlConnection();

                //ou

                // System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

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

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire

                    //int idCategorie = Convert.ToInt32(cb_categorieproduit.SelectedValue.ToString());
                    //string nomProd = txt_nomProd.Text;

                    cmd.CommandText = "select*from IPPI_Utilisateur  where id_superviseur<98 order by ID_utilisateur desc";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listUser = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listUser.Load(dr);

                    dg_listAgent.ItemsSource = listUser.DefaultView;

                    //charger les données lues par le DataAdapter

                    //ad.Fill(listUser);

                    // lier la Datatable au datagrid

                    //dg_listAgent.DataContext = listUser;




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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void add_btnClick(object sender, RoutedEventArgs e)
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
                    //MessageBox.Show("Connexion ok");

                    SqlCommand cmd = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd.Connection = con;

                    SqlCommand cmd2 = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    cmd2.Connection = con;

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire
                    int iduser = Convert.ToInt32(txt_user.Text.ToString());
                    String prenom = txt_lastname.Text.ToString();
                    String nom = txt_name.Text.ToString();
                    String password = txt_password.Password.ToString();
                   // string ident = cb_identifiant.SelectedValue.ToString();
                   // string ident = "Agent";
                    int superviseur = Convert.ToInt32(cb_supervisor.SelectedValue.ToString());

                    cmd2.CommandText = "SET IDENTITY_INSERT IPPI_Utilisateur ON";

                    cmd.CommandText = "insert into IPPI_Utilisateur(ID_utilisateur,Prenom,Nom,Mot_Passe,Identifiant,id_superviseur) values('"+iduser+"','"+prenom + "','" + nom + "','" + password + "','Agent','" + superviseur + "')";

                    cmd2.ExecuteNonQuery();

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                   
                    if(resultat > 0) 
                    {
                        MessageBox.Show("Utilisateur bien ajouté");
                        //LoadProduit();


                        // reinitialiser le formulaire d'ajout
                        txt_user.Text = "";
                        txt_lastname.Text = "";
                        txt_name.Text = "";
                        txt_password.Password = "";
                        // cb_identifiant.SelectedIndex = -1;
                        cb_supervisor.SelectedIndex = -1;
                        displayUser();
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

        private void cb_supervisor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void update_btnClick(object sender, RoutedEventArgs e)
        {

            try
            {

                // déclaration d'un objet connexion
                //namespace sont l'equivalent de library dans R car il faut importer la ibrairie 
                // il s'agit du meme cas; on appelle la reference qui permet de gerer les systemes de connexion car il ne connait pas par defaut le SqlConnection

                SqlConnection con = new SqlConnection();

                //ou

                // System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

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

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire
                    int id = Convert.ToInt32(txt_user.Text.ToString());
                    String prenom = txt_lastname.Text.ToString();
                    String nom = txt_name.Text.ToString();
                    String password = txt_password.Password.ToString();
                    //string ident = cb_identifiant.SelectedValue.ToString();
                    string ident = "Agent";
                    int superviseur = Convert.ToInt32(cb_supervisor.SelectedValue.ToString());

                    cmd.CommandText = "update IPPI_utilisateur set Prenom='" + prenom + "', Nom='" + nom + "', Mot_passe='" + password + "', Identifiant='" + ident + "', id_superviseur='"+superviseur +"' where ID_utilisateur=" + id + "";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Utilisateur bien mis à jour");
                        //LoadProduit();

                        // reinitialiser le formulaire d'ajout

                        txt_user.Text = "";
                        txt_lastname.Text = "";
                        txt_name.Text = "";
                        txt_password.Password = "";
                        //cb_identifiant.SelectedIndex = -1;
                        cb_supervisor.SelectedIndex = -1;
                        displayUser();
                        add_btn.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("erreur de connexion");
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

        private void del_btnClick(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Voulez vous vraiment supprimer cet enregistrement?", "Message", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {

                    // déclaration d'un objet connexion
                    //namespace sont l'equivalent de library dans R car il faut importer la ibrairie 
                    // il s'agit du meme cas; on appelle la reference qui permet de gerer les systemes de connexion car il ne connait pas par defaut le SqlConnection

                    SqlConnection con = new SqlConnection();

                    //ou

                    // System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();

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

                        // indiquer à la commande la requete à executer

                        //recuperer des valeurs du formulaire
                        int id = Convert.ToInt32(txt_user.Text.ToString());




                        cmd.CommandText = "delete from IPPI_utilisateur where ID_utilisateur =" + id + "";

                        // execution de la commande

                        int resultat = cmd.ExecuteNonQuery();
                        if (resultat > 0)
                        {
                            MessageBox.Show("Utilisateur bien supprimé");
                            

                            // reinitialiser le formulaire d'ajout

                            txt_user.Text = "";
                            txt_lastname.Text = "";
                            txt_name.Text = "";
                            txt_password.Password = "";

                            cb_supervisor.SelectedIndex = -1;
                            displayUser();
                            add_btn.IsEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("erreur de connexion");
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }


}
