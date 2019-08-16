using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Listas.Models;
using System.Collections.ObjectModel;

namespace Listas
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> _con;

        private ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>
            {
                new Contact{
                    Name="Juan",
                    ImageUrl= "https://placeimg.com/200/200/people/1",
                    Status="Hola, ¿como esta?"
                },
                new Contact{
                    Name="Lina",
                    ImageUrl= "https://placeimg.com/200/200/people/2",
                    Status="Terminar el trabajo"
                },
                new Contact{
                    Name="Jhon",
                    ImageUrl= "https://placeimg.com/200/200/people/3",
                    Status="JAJajajajJAJA"
                }
            };
        }
        public MainPage()
        {
            InitializeComponent();
            _con = GetContacts();
            listview1.ItemsSource = _con;
         
        }

        private void Llamar_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Contact contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Llamar", contact.Name, "Ok");
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Contact contact = menuItem.CommandParameter as Contact;
            _con.Remove(contact);
        }

        private void Listview1_Refreshing(object sender, EventArgs e)
        {
            _con = GetContacts();
            listview1.ItemsSource = _con;
            listview1.EndRefresh();
        }
    }
}
