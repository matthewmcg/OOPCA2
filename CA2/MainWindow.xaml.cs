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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create lists
        List<Activities> allActivities = new List<Activities>();
        List<Activities> selectedActivities = new List<Activities>();
        List<Activities> filteredActivities = new List<Activities>();
        decimal totalCost;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //create some activity objects
            Activities aActivity = new Activities("Kayaking", new DateTime(2019, 06, 01), Type.Water, "Half day Lakeland kayak with island picnic.", 40);
            Activities bActivity = new Activities("Trekking", new DateTime(2019, 06, 01), Type.Land, "Instructor led group trek through local mountains.", 20);
            Activities cActivity = new Activities("Parachuting", new DateTime(2019, 06, 01), Type.Air, "Experience the thrill of free fall while you tandem jump from an airplane.", 100);
            Activities dActivity = new Activities("Surfing", new DateTime(2019, 06, 02), Type.Water, "2 hour surf lesson on the wild Atlantic way", 25);
            Activities eActivity = new Activities("Mountain Biking", new DateTime(2019, 06, 02), Type.Land, "Instructor led half day mountain biking.  All equipment provided.", 30);
            Activities fActivity = new Activities("Hang Gliding", new DateTime(2019, 06, 02), Type.Air, "Soar on hot air currents and enjoy spectacular views of the coastal region.", 80);
            Activities gActivity = new Activities("Abseiling", new DateTime(2019, 06, 03), Type.Land, "Experience the rush of adrenaline as you descend cliff faces from 10-500m.", 40);
            Activities hActivity = new Activities("Sailing", new DateTime(2019, 06, 03), Type.Water, "Full day Lakeland kayak with island picnic.", 50);
            Activities iActivity = new Activities("Helicopter Tour", new DateTime(2019, 06, 03), Type.Air, "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", 200);

            //add to list
            allActivities.Add(aActivity);
            allActivities.Add(bActivity);
            allActivities.Add(cActivity);
            allActivities.Add(dActivity);
            allActivities.Add(eActivity);
            allActivities.Add(fActivity);
            allActivities.Add(gActivity);
            allActivities.Add(hActivity);
            allActivities.Add(iActivity);

            selectedActivities.Sort();
            allActivities.Sort();
            filteredActivities.Sort();

            //display in listbox
            lbxAllactivities.ItemsSource = allActivities;

            totalCost = 0;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            //figure out what item is selected
            Activities selectedActivity = lbxAllactivities.SelectedItem as Activities; //get selected item

            //null check
            //displays message if no activity is selected
            if (selectedActivity == null)
            {

                MessageBox.Show("You have not selected an activity", "Alert");

            }

            if (selectedActivity != null)
            {

                //move from left listbox to right listbox
                allActivities.Remove(selectedActivity);
                selectedActivities.Add(selectedActivity);

                selectedActivities.Sort();
                allActivities.Sort();
                filteredActivities.Sort();

                //adds prices and displays total price when add button is clicked
                

                totalCost += selectedActivity.Cost;

                txtTotal.Text = string.Format($"{totalCost:C}");

                //refresh the screen
                RefreshScreen();

            }

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

            //figure out what item is selected
            Activities selectedActivity = lbxCart.SelectedItem as Activities; //get selected item

            //displays message if no activity is selected
            if (selectedActivity == null)
            {

                MessageBox.Show("You have not selected an activity", "Alert");

            }

            if (selectedActivity != null)
            {

                //move from left listbox to right listbox
                allActivities.Add(selectedActivity);
                selectedActivities.Remove(selectedActivity);

                selectedActivities.Sort();
                allActivities.Sort();
                filteredActivities.Sort();

                //refresh the screen
                RefreshScreen();

            }

            //subtracts prices and displays total price when activity is removed
            totalCost -= selectedActivity.Cost;

            txtTotal.Text = string.Format($"{totalCost:C}");
        }

        private void RefreshScreen()
        {
            lbxAllactivities.ItemsSource = null;
            lbxAllactivities.ItemsSource = allActivities;

            lbxCart.ItemsSource = null;
            lbxCart.ItemsSource = selectedActivities;
        }

        //handles all radio button clicks

        private void RbAll_Click(object sender, RoutedEventArgs e)
        {

            filteredActivities.Clear();

            if (rbAll.IsChecked == true)
            {              
                allActivities.Sort();
                
                //show all activities
                RefreshScreen();

            }
            else if (rbLand.IsChecked == true)
            {
                //show land activities
                foreach (Activities activities in allActivities)
                {
                    if (activities.Type == Type.Land)
                    {

                        filteredActivities.Sort();

                        filteredActivities.Add(activities);
                        lbxAllactivities.ItemsSource = null;
                        lbxAllactivities.ItemsSource = filteredActivities;
                    }
                }

            }
            else if (rbWater.IsChecked == true)
            {
                //show water activities
                foreach (Activities activities in allActivities)
                {
                    if (activities.Type == Type.Water)
                    {

                        filteredActivities.Sort();

                        filteredActivities.Add(activities);
                        lbxAllactivities.ItemsSource = null;
                        lbxAllactivities.ItemsSource = filteredActivities;
                    }
                }

            }
            else if (rbAir.IsChecked == true)
            {
                //show air activities
                foreach (Activities activities in allActivities)
                {
                    if (activities.Type == Type.Air)
                    {

                        filteredActivities.Sort();

                        filteredActivities.Add(activities);
                        lbxAllactivities.ItemsSource = null;
                        lbxAllactivities.ItemsSource = filteredActivities;
                    }
                }

            }
        }

        //Display description in description box.
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string desc;

            Activities selectedActivity = lbxAllactivities.SelectedItem as Activities;

            if (selectedActivity == null)
            {

            }
            else
            {
                desc = string.Format($"{selectedActivity.Desc} - Cost: {selectedActivity.Cost:C}");
                tbxDescription.Text = null;
                tbxDescription.Text = desc;
            }
        }

        private void LbxCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string desc;

            Activities selectedActivity = lbxCart.SelectedItem as Activities;

            if (selectedActivity == null)
            {

            }
            else
            {
                desc = string.Format($"{selectedActivity.Desc} - Price: {selectedActivity.Cost:C}");
                tbxDescription.Text = null;
                tbxDescription.Text = desc;
            }
        }
    }
}


