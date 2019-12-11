using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MenuApp.ViewModels
{
    public class ComposeMenuViewModel : BaseViewModel
    {
        public List<Day> ScolarDaysList { get; set; }

        public Calendar myCalendar { get; set; } = CultureInfo.InvariantCulture.Calendar;

        public int selectedCategorie;
        public int SelectedCategorie
        {
            get { return selectedCategorie; }
            set
            {
                SetProperty(ref selectedCategorie, value);
                NumberChoices = SetNumberChoices(selectedCategorie);
            }
        }

        public int numberChoices = 3;
        public int NumberChoices
        {
            get { return numberChoices; }
            set
            {
                SetProperty(ref numberChoices, value);
            }
        }

        public int SetNumberChoices(int selectedCategorie)
        {
            switch (selectedCategorie)
            {
                case 0:
                    return 3;
                case 1:
                    return 1;
                case 2:
                    return 3;
                case 3:
                    return 2;
                default:
                    return 0;
            }
        }

        public ComposeMenuViewModel()
        {
            //Test with a choosen date
            DateTime mydate = new DateTime(2019, 2, 28);
            ScolarDaysList = SetWeekScolarDays(GetFirstDayOfWeek(DateTime.Today));
        }

        public DateTime GetFirstDayOfWeek(DateTime day)
        {
            int dayToSubstract = (int)myCalendar.GetDayOfWeek(day) - 1;
            DateTime firstDayOfWeek = myCalendar.AddDays(day, -dayToSubstract);
            return firstDayOfWeek;
        }

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
