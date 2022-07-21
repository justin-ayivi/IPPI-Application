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
    /// Interaction logic for ProduitUnite.xaml
    /// </summary>
    public partial class ProduitUnite : Window
    {
        int idprod;
        public ProduitUnite()
        {
            InitializeComponent();

            txt_nomAssocier.Text = txt_nomProd.Text;

            // appel de la fonction qui charge les catégories de produits
            LoadCategorieProduit();

            // appel de la fonction qui charge les unités dans le combobox
            LoadUnite();

            // fonction qui permet d'afficher les produits

            displayProd();

            // fonction qui permet d'afficher les unités

            displayUnite();

        }

        private void displayUnite()
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


                    cmd.CommandText = "select*from IPPI_unite";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listUnite = new DataTable();

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listUnite.Load(dr);

                    dg_unite.ItemsSource = listUnite.DefaultView;


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


        private void displayProd()
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


                    cmd.CommandText = "select id_produit, Nom_produit, IPPI_CategorieProduit.id_categorie, categorie from IPPI_Produit inner join IPPI_CategorieProduit on IPPI_Produit.id_categorie = IPPI_CategorieProduit.id_categorie order by id_produit desc";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listUniteProd = new DataTable();

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    listUniteProd.Load(dr);

                    dg_listUniteProd.ItemsSource = listUniteProd.DefaultView;


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

        //creation d'une fonction pour ajouter un produit

        private void AddProduit()
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

                    int idCategorie = Convert.ToInt32(cb_categorieproduit.SelectedValue.ToString());
                    string nomProd = txt_nomProd.Text.ToString();

                    cmd.CommandText = "insert into IPPI_produit(id_categorie, Nom_produit) values (' " + idCategorie + "', ' " + nomProd + "')";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Produit bien ajouté");
                        displayProd();

                        // reinitialiser le formulaire d'ajout

                        txt_nomProd.Text = "";
                        cb_categorieproduit.SelectedIndex = -1;
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

                MessageBox.Show("AddProduit - Erreur =" + ex.Message);
            }
        }

        // extraction de la liste des catégories produit. 

        private void LoadCategorieProduit()
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

                    cmd.CommandText = "select*from IPPI_CategorieProduit";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeCateg = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeCateg);

                    // lier la Datatable au combobox

                    cb_categorieproduit.DataContext = listeCateg;

                    //indiquer la coonne à afficher 

                    cb_categorieproduit.DisplayMemberPath = "categorie";

                    //indiquer la colonne qui rprésente la valeur de chaque element 

                    cb_categorieproduit.SelectedValuePath = "id_categorie";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. Ce qui justifie l'ajout de AddProduit

                MessageBox.Show(" Erreur =" + ex.Message);
            }
        }

       
        private void bt_ajouter_Click(object sender, RoutedEventArgs e)
        {
            //appel de la fonction addProduit()

            AddProduit();
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


                    String nomprod = txt_nomProd.Text.ToString();
                    int catprod = Convert.ToInt32(cb_categorieproduit.SelectedValue.ToString());


                    cmd.CommandText = "update IPPI_Produit set Nom_produit='" + nomprod + "', id_categorie = '"+catprod +"' where id_produit=" + idprod + "";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Produit bien modifié");


                        // reinitialiser le formulaire d'ajout
                        txt_nomProd.Text = "";
                        txt_nomAssocier.Text = "";
                        cb_categorieproduit.SelectedIndex = -1;
                        displayProd();
                        bt_ajouter.IsEnabled = true;
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

                        cmd.CommandText = "delete from IPPI_Produit where id_produit =" + idprod + "";

                        // execution de la commande

                        int resultat = cmd.ExecuteNonQuery();
                        if (resultat > 0)
                        {
                            MessageBox.Show("Produit bien supprimé");


                            // reinitialiser le formulaire d'ajout

                            txt_nomProd.Text = "";
                            cb_categorieproduit.SelectedIndex = -1;
                            displayProd();
                            bt_ajouter.IsEnabled = true;
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
        private void cb_categorieproduit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
     

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Application.Current.Shutdown();
        }

        private void dg_listUniteProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView drow = dg.SelectedItem as DataRowView;
            if (drow != null)
            {

                idprod= Convert.ToInt32(drow["id_produit"].ToString());
                txt_nomProd.Text = drow["Nom_produit"].ToString();

                int cat = Convert.ToInt32(drow["id_categorie"].ToString());

                cb_categorieproduit.SelectedIndex = cat-1;

                txt_nomAssocier.Text = drow["Nom_produit"].ToString();

                bt_ajouter.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }


        private void LoadUnite()
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

                    cmd.CommandText = "select*from IPPI_unite";
                    // execution de la commande

                    SqlDataAdapter ad = new SqlDataAdapter();

                    // lier l'objet adapteur à la commande à executer 
                    ad.SelectCommand = cmd;

                    //declaration d'un objet de type DataTable pour récupérer les données

                    DataTable listeunite = new DataTable(); // il faudra ajouter après au niveau du préambule using system data. 

                    //charger les données lues par le DataAdapter

                    ad.Fill(listeunite);

                    // lier la Datatable au combobox

                    cbuniteproduit.DataContext = listeunite;

                    //indiquer la coonne à afficher 

                    cbuniteproduit.DisplayMemberPath = "unite";

                    //indiquer la colonne qui rprésente la valeur de chaque element 

                    cbuniteproduit.SelectedValuePath = "id_unite";



                }
                else
                {
                    MessageBox.Show("erreur de connexion");
                }

            }

            catch (Exception ex)
            {
                //On peut avoir la meme erreur pour plusieurs executions. Ce qui justifie l'ajout de AddProduit

                MessageBox.Show(" Erreur =" + ex.Message);
            }
        }

        private void bt_affect_click(object sender, RoutedEventArgs e)
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

                    int idunite = Convert.ToInt32(cbuniteproduit.SelectedValue.ToString());
                    string nomProd = txt_nomAssocier.Text.ToString();

                    cmd.CommandText = "insert into IPPI_ProduitUnite(id_produit, id_unite) values (' " + idprod + "', ' " + idunite + "')";

                    // execution de la commande

                    int resultat = cmd.ExecuteNonQuery();
                    if (resultat > 0)
                    {
                        MessageBox.Show("Produit bien affecté à son unité");
                        displayProd();

                        // reinitialiser le formulaire d'ajout

                        txt_nomAssocier.Text = "";
                        cbuniteproduit.SelectedIndex = -1;
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

                MessageBox.Show("AddProduit - Erreur =" + ex.Message);
            }
        }

        
    }

        
}
