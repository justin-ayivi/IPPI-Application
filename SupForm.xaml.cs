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
    /// Interaction logic for SupForm.xaml
    /// </summary>
    public partial class SupForm : Window
    {
        public SupForm()
        {
            InitializeComponent();
            displaysup();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void displaysup()
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


                    cmd.CommandText = "select*from IPPI_superviseur order by id_superviseur";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listUser = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listUser.Load(dr);

                    dg_listsup.ItemsSource = listUser.DefaultView;

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
        private void add_btnClick(object sender, RoutedEventArgs e)
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
                    int id_sup = Convert.ToInt32(txt_sup.Text.ToString());
                    String nom_sup = txt_namesup.Text.ToString();
                    

                    cmd.CommandText = "insert into IPPI_superviseur(id_superviseur,nom_superviseur) values('" + id_sup + "','" + nom_sup + "')";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Utilisateur bien ajouté");
                        //LoadProduit();

                        // reinitialiser le formulaire d'ajout

                        txt_sup.Text = "";
                        txt_namesup.Text = "";
                        displaysup();
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
                
                MessageBox.Show(" Erreur : " + ex.Message);
            }

        }

        private void update_btnClick(object sender, RoutedEventArgs e)
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

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire
                    int id_sup = Convert.ToInt32(txt_sup.Text.ToString());
                    String nom_sup = txt_namesup.Text.ToString();

                    cmd.CommandText = "update IPPI_superviseur set nom_superviseur='"+nom_sup +"' where id_superviseur=" + id_sup + "";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Utilisateur bien mis à jour");

                        txt_sup.Text = "";
                        txt_namesup.Text = "";
                        displaysup();
                       
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
                //On peut avoir la meme erreur pour plusieurs executions. 

                MessageBox.Show(" Erreur : " + ex.Message);
            }

        
        }

        private void del_btnClick(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Voulez vous vraiment supprimer cet enregistrement?", "Message", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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

                        // indiquer à la commande la requete à executer

                        //recuperer des valeurs du formulaire
                        int id_sup = Convert.ToInt32(txt_sup.Text.ToString());
                        



                        cmd.CommandText = "delete from IPPI_superviseur where id_superviseur =" + id_sup + "";

                        // execution de la commande

                        int resultat = cmd.ExecuteNonQuery();
                        if (resultat > 0)
                        {
                            MessageBox.Show("Utilisateur bien supprimé");

                            txt_sup.Text = "";
                            txt_namesup.Text = "";
                            displaysup();

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

        private void dg_listsup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView drow = dg.SelectedItem as DataRowView;
            if (drow != null)
            {
                txt_sup.Text = drow["id_superviseur"].ToString();
                txt_namesup.Text = drow["nom_superviseur"].ToString();
               


                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
