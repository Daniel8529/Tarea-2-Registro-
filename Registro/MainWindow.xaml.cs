using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro
{
    // <summary>
    /// Interaction logic for MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var lista = RolesBLL.GetLista();
            Ventanaconsultar.ItemsSource = lista;
        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {


            Roles roles = new Roles(rolld.Text, descricion.Text, fecha.Text);

            if (!RolesBLL.Existes(rolld.Text))
            {
                if (!RolesBLL.Existe(descricion.Text))
                {
                    var paso = RolesBLL.Insertar(roles);

                    MessageBox.Show("Se ha agregado exitozamente");

                }
                else
                {
                    MessageBox.Show("La descripcion que ingreso ya existe");
                }
            }
            else
            {
                MessageBox.Show("El RolID que ingreso ya existe");
            }
            var lista = RolesBLL.GetLista();
            Ventanaconsultar.ItemsSource = lista;
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {

            Roles roles = new Roles(rolld.Text, descricion.Text, fecha.Text);


            var paso = RolesBLL.Existe(roles, rolld.Text);
            if (paso)
            {
                MessageBox.Show("Se ha Editado con exito");
            }
            else
            {

                MessageBox.Show("No se pudo Editar el rol");
            }


            var lista = RolesBLL.GetLista();
            Ventanaconsultar.ItemsSource = lista;

        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(rolld.Text))
            {

                MessageBox.Show("Registro Eliminado", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var lista = RolesBLL.GetLista();
            Ventanaconsultar.ItemsSource = lista;

        }

        private void validar_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
