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
    /// Interaction logic for HomeSuperviseur.xaml
    /// </summary>

    static class Globalv2
    {
        public static string name;

    }
    public partial class HomeSuperviseur : Window
    {
        
        public HomeSuperviseur(string valnom2)
        {
            InitializeComponent();
            Globalv2.name = valnom2;

            txt_namesup.Text = valnom2;
        }

        private void Mn_rep_entr_Click(object sender, RoutedEventArgs e)
        {
            RepartitionEntreprise open = new RepartitionEntreprise();
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
