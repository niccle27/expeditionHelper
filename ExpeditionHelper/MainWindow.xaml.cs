﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ExpeditionHelper
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<Voyage> listeDeVoyage = new ObservableCollection<Voyage>();

        public void OnUtilisateurModification(Object sender, EventArgs e)
        {
            ReLoad();
           
        }
        public static void ResetListeDeVoyage()
        {
            listeDeVoyage.Clear();
        }

        public MainWindow()
        {
            Utilisateur.Modification += OnUtilisateurModification;// link OnUtilisateurModification à l'événement utilisateur

            
            InitializeComponent();
            ManagerSql.HydrateCategorie();//hydrater les categories
            listView_Voyage.ItemsSource = listeDeVoyage;
            listView_Voyage.SelectedIndex = 0;

        }

        public static void ReLoad()
        {
            ManagerSql.SelectVoyages(listeDeVoyage);// refresh automatique via observableCollection           
        }

        private void new_activities(object sender, RoutedEventArgs e)
        {
            Activite activite = new Activite();
            activite.M_datetime = DateTime.Now;
            WindowActivites tmp = new WindowActivites();
            tmp.DataContext = activite;
            tmp.ShowDialog();
        }

        private void new_meal(object sender, RoutedEventArgs e)
        {
            Nourriture nourriture = new Nourriture();
            nourriture.M_datetime = DateTime.Now;
            WindowNourriture tmp = new WindowNourriture();
            tmp.DataContext = nourriture;
            tmp.ShowDialog();
        }

        private void new_transport(object sender, RoutedEventArgs e)
        {
            Transport transport = new Transport();
            transport.M_datetime = DateTime.Now;
            WindowTransport tmp = new WindowTransport();
            tmp.DataContext = transport;
            tmp.ShowDialog();
        }
        private void new_logement(object sender, RoutedEventArgs e)
        {
            Logement logement = new Logement();
            logement.M_datetime = DateTime.Now;
            WindowLogement tmp = new WindowLogement();
            tmp.DataContext = logement;
            tmp.ShowDialog();
        }
        private void new_divers(object sender, RoutedEventArgs e)
        {
            Depense depense = new Depense();
            depense.M_datetime = DateTime.Now;
            WindowDivers tmp = new WindowDivers();
            tmp.DataContext = depense;
            tmp.ShowDialog();
        }

        private void MI_connection_Click(object sender, RoutedEventArgs e)
        {
            Window_connection tmp = new Window_connection();
            tmp.ShowDialog();
        }

        private void listView_Voyage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
                view1.GroupDescriptions.Clear();//artifice pour empêcher d'imbriquer des groupe en rapellant la fonction
                view1.SortDescriptions.Clear();
                Utilisateur.Instance.CurrentVoyage = (Voyage)listView_Voyage.SelectedItem;
                CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
                SortDescription sortDescription = new SortDescription("M_datetime", ListSortDirection.Ascending);
                view2.SortDescriptions.Add(sortDescription);
                PropertyGroupDescription groupDescription = new PropertyGroupDescription("Date");
                view2.GroupDescriptions.Add(groupDescription);
            }
            catch (Exception)
            {
                //ne rien faire c'est que la liste est vide
            } 
        }

        private void listView_Depense_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_update.Visibility = Visibility.Visible;
            edit_zone.Children.Clear();
            var tmp = ((ListView)sender).SelectedItem;
            if (tmp is Activite)
            {

                Activite tmp2 = tmp as Activite;
                UserControlActivite userControlActivite = new UserControlActivite();
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Logement)
            {
                Logement tmp2 = tmp as Logement;
                UserControlLogement userControlActivite = new UserControlLogement(tmp2);
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Transport)
            {
                Transport tmp2 = tmp as Transport;
                UserControlTransport userControlActivite = new UserControlTransport(tmp2);
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Nourriture)
            {
                Nourriture tmp2 = tmp as Nourriture;
                UserControlNourriture userControlActivite = new UserControlNourriture();
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Depense)
            {
                Depense tmp2 = tmp as Depense;
                //UserControlDepense userControlDepense = new UserControlDepense(tmp2);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            var tmp = listView_Depense.SelectedItem;
            if (tmp is Activite)
            {
                Activite tmp2 = tmp as Activite;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateActivity(tmp2);
            }
            else if (tmp is Logement)
            {
                Logement tmp2 = tmp as Logement;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateLogement(tmp2);
            }
            else if (tmp is Transport)
            {
                Transport tmp2 = tmp as Transport;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateTransport(tmp2);
            }
            else if (tmp is Nourriture)
            {
                Nourriture tmp2 = tmp as Nourriture;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateNourriture(tmp2);
            }
            else if (tmp is Depense)
            {
                Depense tmp2 = tmp as Depense;
                ManagerSql.UpdateDepense(tmp2);
            }
            ManagerSql.SelectDepenseTot((Voyage)listView_Voyage.SelectedItem);
            totalSpent_value.Content = ((Voyage)listView_Voyage.SelectedItem).DepenseTot;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContextMenuRemove_btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerSql.DeleteAnyDepense((Depense)listView_Depense.SelectedItem);
            ((Voyage)listView_Voyage.SelectedItem).refreshListeDepense();
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This software was develloped by Clément Nicolas");
        }

        private void MI_Disconnection_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur.resetInstance();
            ResetListeDeVoyage();
        }

        private void btn_new_trip_Click(object sender, RoutedEventArgs e)
        {
            Voyage voyage = new Voyage();
            voyage.Debut = DateTime.Now.Date;
            voyage.Fin= DateTime.Now.Date;
            WindowVoyage tmp = new WindowVoyage();
            tmp.DataContext = voyage;
            tmp.ShowDialog();
        }

        private void ContextMenuRemoveVoyage_btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerSql.DeleteVoyage((Voyage)listView_Voyage.SelectedItem);
            ReLoad();
        }

        private void btn_search_weatherCode_Click(object sender, RoutedEventArgs e)
        {
            WindowSearch tmp = new WindowSearch();
            tmp.ShowDialog();
        }

        private void ContextMenuShowGraphique_Click(object sender, RoutedEventArgs e)
        {
            WindowGraphique tmp = new WindowGraphique(((Voyage)listView_Voyage.SelectedItem).Id_Voyage);
            tmp.ShowDialog();
        }
    }
}
