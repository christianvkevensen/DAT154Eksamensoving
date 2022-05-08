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

namespace Oblig4FrontDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities entities = new Entities();
        public MainWindow()
        {
            InitializeComponent();
            List<rooms> rooms = entities.rooms.ToList();
            List<reservations> reservations = entities.reservations.ToList();

            datagridRooms.ItemsSource = rooms;

            datagridReservation.ItemsSource = reservations;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page1 page1 = new Page1();
            this.Content = page1;
        }


        private void datagridReservation_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            reservations reservation = new reservations();

            if (reservation != null)
            {
                //rooms room = entities.rooms.Find();
                //reservation.rooms = room;
            }

            Console.WriteLine(reservation.UserName);

            entities.reservations.Add(reservation);
            entities.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            reservations reservation = new reservations();
            users user = entities.users.Find(textBoxName.Text);
            rooms room = entities.rooms.Find(int.Parse(textBoxRN.Text));
            if (user == null)
            {
                user = new users();
                user.UserName = textBoxName.Text;
                entities.users.Add(user);
                
            } if (room == null)
            {
                room = new rooms();
                room.RoomNumber = int.Parse(textBoxName.Text);
                room.Quality = 2;
                room.NumberOfBeds = 2;
                entities.rooms.Add(room);
                
            }
            reservation.UserName = textBoxName.Text;
            reservation.RoomNumber = int.Parse(textBoxRN.Text);
            

            DateTime dateNow = DateTime.Now;
            DateTime dateEnd = dateNow.AddDays(int.Parse(textBoxED.Text));
            reservation.startDate = dateNow;
            reservation.endDate = dateEnd;
            entities.reservations.Add((reservation));
            entities.SaveChanges();

            datagridReservation.ItemsSource = entities.reservations.ToList();
            datagridReservation.Items.Refresh();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(textBoxId.Text);
            reservations reservation = entities.reservations.Find(id);
            if(reservation != null)
            {
                entities.reservations.Remove(reservation);
                entities.SaveChanges();
                datagridReservation.ItemsSource = entities.reservations.ToList();
                datagridReservation.Items.Refresh();
            }

        }
    }
}
