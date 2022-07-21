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
    /// Interaction logic for Entreprise.xaml
    /// </summary>
    public partial class Entreprise : Window
    {
        int id;
        public Entreprise()
        {
            InitializeComponent();

            // fonction qui permet d'afficher les entreprises 
            
            displayent();
        }

    
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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


                    cmd.CommandText = "select id_Entreprise, ninea, raison_soc, sigle,adresse, telephone, ID_Utilisateur from IPPI_Entreprise";
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

                    //SqlCommand cmd2 = new SqlCommand();

                    //Indiquer à la commande la collection à utiliser

                    //cmd2.Connection = con;

                    // indiquer à la commande la requete à executer

                    //recuperer des valeurs du formulaire
                   // int id_entreprise = Convert.ToInt32(txt_idEnt.Text.ToString());
                    String ninea = txt_ninea.Text.ToString();
                    String raisoc = txt_raisonsoc.Text.ToString();
                    String sigle = txt_sigle.Text.ToString();
                    String adress = txt_adress.Text.ToString();
                    String tel = txt_telephone.Text.ToString();
                   

                    //cmd2.CommandText = "SET IDENTITY_INSERT IPPI_Entreprise ON";

                    cmd.CommandText = "insert into IPPI_Entreprise(ninea,raison_soc,sigle,adresse,telephone, Date_modification) values('" + ninea + "','" + raisoc + "','" + sigle + "','" + adress + "','" + tel + "',GETDATE())";

                    //cmd2.ExecuteNonQuery();

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        MessageBox.Show("Entreprise bien ajoutée");
                        //LoadProduit();


                        // reinitialiser le formulaire d'ajout
                        //txt_idEnt.Text = "";
                        txt_ninea.Text = "";
                        txt_raisonsoc.Text = "";
                        txt_sigle.Text = "";
                        txt_adress.Text = "";
                        txt_telephone.Text = "";
                        displayent();
                       
                        //displayUser();
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

        private void dg_listEnt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView drow = dg.SelectedItem as DataRowView;
            if (drow != null)
            {
                //txt_idEnt.Text = drow["id_Entreprise"].ToString();
                id = Convert.ToInt32(drow["id_Entreprise"].ToString());
                txt_ninea.Text = drow["ninea"].ToString();
                txt_raisonsoc.Text = drow["raison_soc"].ToString();
                txt_sigle.Text = drow["sigle"].ToString();
                txt_adress.Text = drow["adresse"].ToString();
                txt_telephone.Text = drow["telephone"].ToString();
                

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }
        #region UpdateDelete
            private void update_btnClick(object sender, RoutedEventArgs e)
        {
             try
            {

                 SqlConnection con = new SqlConnection();
                con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    //int id = Convert.ToInt32(txt_idEnt.Text.ToString());
                    String ninea = txt_ninea.Text.ToString();
                    String raison = txt_raisonsoc.Text.ToString();
                    String sigle = txt_sigle.Text.ToString();
                    String adress = txt_adress.Text.ToString();
                    String telephone = txt_telephone.Text.ToString();
                   
                    
                    cmd.CommandText = "update IPPI_Entreprise set ninea='" + ninea + "', raison_soc='" + raison + "', sigle='" + sigle + "', adresse='" + adress + "', telephone='"+telephone + "',Date_modification =GETDATE()"+" where id_Entreprise=" + id + "";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Données Entreprise bien mises à jour");
                        

                        // reinitialiser le formulaire d'ajout
                        //txt_idEnt.Text = "";
                        txt_ninea.Text = "";
                        txt_raisonsoc.Text = "";
                        txt_sigle.Text = "";
                        txt_adress.Text = "";
                        txt_telephone.Text = "";
                        displayent();
                        add_btn.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("erreur de connexion--Mis a jour");
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

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;
                    con.Open();

                   // tester si la connexion est établie 
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        //int id = Convert.ToInt32(txt_idEnt.Text.ToString());




                        cmd.CommandText = "delete from IPPI_Entreprise where id_Entreprise =" + id + "";

                        // execution de la commande

                        int resultat = cmd.ExecuteNonQuery();
                        if (resultat > 0)
                        {
                            MessageBox.Show("Entreprise bien supprimée");


                            // reinitialiser le formulaire d'ajout
                            //txt_idEnt.Text = "";
                            txt_ninea.Text = "";
                            txt_raisonsoc.Text = "";
                            txt_sigle.Text = "";
                            txt_adress.Text = "";
                            txt_telephone.Text = "";
                            displayent();
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
        #endregion

    }
}
