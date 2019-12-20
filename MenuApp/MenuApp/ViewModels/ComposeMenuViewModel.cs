using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace MenuApp.ViewModels
{
    public class ComposeMenuViewModel : BaseViewModel
    {
        /// <summary>
        /// liste des jours d'école
        /// </summary>
        public List<Day> ScolarDaysList { get; set; }

        /// <summary>
        /// Calendrier 
        /// </summary>
        public Calendar myCalendar { get; set; } = CultureInfo.InvariantCulture.Calendar;

        /// <summary>
        /// reference au view model du manager
        /// </summary>
        public ManagerViewModel Manager
        {
            get; set;
        }

        /// <summary>
        /// grid pour la selection des aliments
        /// </summary>
        public Grid gridChoices;
        public Grid GridChoices
        {
            get { return gridChoices; }
            set
            {
                SetProperty(ref gridChoices, value);
            }
        }

        /// <summary>
        /// la catégorie du menu séléctionnée
        /// </summary>
        public int selectedCategorie;
        public int SelectedCategorie
        {
            get { return selectedCategorie; }
            set
            {
                SetProperty(ref selectedCategorie, value);
                SetChoices(selectedCategorie);
                ListAliments = SetListAliments(selectedCategorie);
            }
        }

        /// <summary>
        /// la liste des choix d'aliments pour la catégorie
        /// </summary>
        public List<string> listChoices;
        public List<string> ListChoices
        {
            get { return listChoices; }
            set
            {
                SetProperty(ref listChoices, value);
            }
        }

        /// <summary>
        /// liste de tous les aliments disponibles pour la catégorie
        /// </summary>
        public List<Aliments> listAliments;
        public List<Aliments> ListAliments
        {
            get { return listAliments; }
            set
            {
                SetProperty(ref listAliments, value);
            }
        }

        /// <summary>
        /// appelle la fonction de création du grid pour la selection des aliments en fonction de la catégorie choisie
        /// </summary>
        /// <param name="selectedCategorie">catégorie du menu sélectionnée</param>
        public void SetChoices(int selectedCategorie)
        {
            switch (selectedCategorie)
            {
                case 0:
                     SetChoicesList(3);
                    break;
                case 1:
                     SetChoicesList(1);
                    break;
                case 2:
                     SetChoicesList(3);
                    break;
                case 3:
                     SetChoicesList(2);
                    break;
                default:
                     SetChoicesList(3);
                    break;
            }
        }

        /// <summary>
        /// création du grid dedié à la selection des aliments
        /// </summary>
        /// <param name="number">le nombre d'aliments selectionnables</param>
        public void SetChoicesList(int number)
        {
            GridChoices.ColumnDefinitions.Clear();
            GridChoices.Children.Clear();
            for(int i=0; i<number; i++)
            {
                var colDef = new ColumnDefinition();
                GridChoices.ColumnDefinitions.Add(new ColumnDefinition());
                var img = new Image();
                img.Source = "croix.jpg";
                img.HeightRequest = 10;
                img.WidthRequest = 10;
                Grid.SetColumn(img, i);
                GridChoices.Children.Add(img);
            }
        }

        /// <summary>
        /// récupére la liste des aliments pour une catégorie
        /// </summary>
        /// <param name="cate">identifiant de la catégorie du menu</param>
        /// <returns>liste d'aliments</returns>
        public List<Aliments> SetListAliments(int cate)
        {
            return Manager.GetAlimentsByCategory(cate);
        }

        /// <summary>
        /// initialise une nouvelle instance de la classe ComposeMenuViewModel
        /// </summary>
        /// <param name="ManagerVM">le manager</param>
        public ComposeMenuViewModel(ManagerViewModel ManagerVM, Grid myGrid) : base()
        {
            Manager = ManagerVM;
            gridChoices = myGrid;

            SelectedCategorie = 0;

            //Test with a choosen date
            DateTime mydate = new DateTime(2019, 2, 28);
            ScolarDaysList = SetWeekScolarDays(GetFirstDayOfWeek(DateTime.Today));
        }

        /// <summary>
        /// calcul le premier jour d'une semaine
        /// </summary>
        /// <param name="day">date</param>
        /// <returns>le premier jour de la semaine correspondante à la date en param</returns>
        public DateTime GetFirstDayOfWeek(DateTime day)
        {
            int dayToSubstract = (int)myCalendar.GetDayOfWeek(day) - 1;
            DateTime firstDayOfWeek = myCalendar.AddDays(day, -dayToSubstract);
            return firstDayOfWeek;
        }

        /// <summary>
        /// crée la liste des jours d'école pour une semaine donnée
        /// </summary>
        /// <param name="firstDay">date : le premier jour d'une semaine</param>
        /// <returns>liste de jours (du lundi au vendredi pour la semaine choisie)</returns>
        public List<Day> SetWeekScolarDays(DateTime firstDay)
        {
            List<Day> myList = new List<Day>();

            for(int i=0; i<5; i++)
            {
                myList.Add(new Day()
                {
                    Date = myCalendar.AddDays(firstDay, i),
                    Name = myCalendar.GetDayOfWeek(myCalendar.AddDays(firstDay, i)).ToString(),
                    FullDate = myCalendar.AddDays(firstDay, i).ToString("dddd dd/MM")
                });
            }
            return myList;
        }
    }
}
