﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Voyage
    {
        private float depenseTot;

        public float DepenseTot
        {
            get { return depenseTot; }
            set { depenseTot = value; }
        }


        public void refreshListeDepense()
        {
            listeDepense.Clear();
            ManagerSql.SelectDivers(this);
            ManagerSql.SelectActivites(this);
            ManagerSql.SelectLogements(this);
            ManagerSql.SelectNourritures(this);
            ManagerSql.SelectTransports(this);
            ManagerSql.SelectDepenseTot(this);
        }

        private int id_Voyage;

        public int Id_Voyage
        {
            get { return id_Voyage; }
            set { id_Voyage = value; }
        }

        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private DateTime debut;
        public DateTime Debut
        {
            get { return debut; }
            set { debut = value; }
        }

        private DateTime fin;
        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

       private ObservableCollection<Depense> listeDepense = new ObservableCollection<Depense>();
       public ObservableCollection<Depense> ListeDepense
        {
            get { return listeDepense; }
            set { listeDepense = value; }
        }



        public Voyage()
        {

        }
        public Voyage(int id,string nom, DateTime debut, DateTime fin,float depenseTot)
        {
            this.id_Voyage = id;
            this.nom = nom;
            this.debut = debut;
            this.fin = fin;
            this.depenseTot = depenseTot;
        }
        public void Hydrate(int id, string nom, DateTime debut, DateTime fin, float depenseTot)
        {
            this.id_Voyage = id;
            this.nom = nom;
            this.debut = debut;
            this.fin = fin;
            this.depenseTot = depenseTot;
        }
        public void AddDepense(Depense depense)
        {
            ListeDepense.Add(depense);
        }
        
    }
}
