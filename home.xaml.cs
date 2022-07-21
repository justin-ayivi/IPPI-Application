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
using System.Windows.Shapes;

namespace IPPI_projet
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>

    static class Globalv1
    {
        public static string name;
        
    }
    public partial class home : Window
    {
        public home(string valnom)
        {
            InitializeComponent();

            Globalv1.name = valnom;

            txt_name.Text = valnom;
        }

        private void Mn_produit_click(object sender, RoutedEventArgs e)
        {
              ProduitUnite open = new ProduitUnite();
                    // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
                
        }

        private void Mn_entreprise_click(object sender, RoutedEventArgs e)
        {
            Entreprise open = new Entreprise();
            // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
        }

        private void Mn_agent_click(object sender, RoutedEventArgs e)
        {
            ManageUser open = new ManageUser();
            // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
        }

        private void Mn_superviseur_click(object sender, RoutedEventArgs e)
        {
            SupForm open = new SupForm();
            // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
        }

        private void Mn_entrep_click(object sender, RoutedEventArgs e)
        {
            RepartitionEntreprise open = new RepartitionEntreprise();
            // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
        }

        private void Mn_saisieAgentClick(object sender, RoutedEventArgs e)
        {
            SaisieAgent open = new SaisieAgent();
            // afficher la fenetre Accueil
            open.Show();

            //this.Visibility = Visibility.Hidden;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
