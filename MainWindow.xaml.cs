using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public MainWindow()
        {
            InitializeComponent();
            con.ConnectionString = IPPI_projet.Properties.Settings.Default.ChaineConnexion;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                
            }
            if (VerifyUser(txtUsername.Text, txtPassword.Password, "Agent"))
            {
                // MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

                // Ouverture de la page d'accueil

                SaisieAgent OpenAgent = new SaisieAgent();
                OpenAgent.Show();

                // Cacher l'ancienne 

                //this.Visibility = Visibility.Hidden;
            }
            else
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();

                }
               
                if (VerifyUser(txtUsername.Text, txtPassword.Password, "Admin"))
                {
                    // MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Ouverture de la page d'accueil

                    home open = new home(txtUsername.Text);
                    open.Show();

                    // Cacher l'ancienne 

                    //this.Visibility = Visibility.Hidden;
                }
                else
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();

                    }
                    if (VerifyUser(txtUsername.Text, txtPassword.Password, "Superviseur"))
                    {
                        // MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Ouverture de la page d'accueil

                        HomeSuperviseur OpenSup = new HomeSuperviseur(txtUsername.Text);
                        OpenSup.Show();

                        // Cacher l'ancienne 

                        //this.Visibility = Visibility.Hidden;
                    }
                    else
                    {

                        MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
            }

           
           
           
            
        }
        private bool VerifyUser(string username, string password, string ident)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "select ID_utilisateur from IPPI_Utilisateur where Prenom='" + username + "' and Mot_Passe='" + password + "' and Identifiant='"+ident+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                if(Convert.ToBoolean(dr["ID_utilisateur"]) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
