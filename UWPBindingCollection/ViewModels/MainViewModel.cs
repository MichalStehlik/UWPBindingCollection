using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPBindingCollection.Models;

namespace UWPBindingCollection.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        private int? _selectedIndex;
        private Student _selectedStudent;

        public ObservableCollection<Student> Students { get { return _students; } set { _students = value; NotifyPropertyChanged(); } }
        public int? SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; NotifyPropertyChanged(); } }
        public Student SelectedStudent { get { return _selectedStudent; } set { _selectedStudent = value; NotifyPropertyChanged(); } }

        public IEnumerable<Gender> Genders{ get { return Enum.GetValues(typeof(Gender)).Cast<Gender>(); } }

        public RelayCommand AddPredefined { get; set; }
        public RelayCommand BalanceAverage { get; set; }

        public MainViewModel()
        {
            _students.Add(new Student { Firstname = "Adam", Lastname="Novák", Average=2.05, Gender=Gender.Male, Examined=false});
            _students.Add(new Student { Firstname = "Beáta", Lastname = "Pokorná", Average = 1, Gender = Gender.Female, Examined = false });
            _students.Add(new Student { Firstname = "Cyril", Lastname = "Vomáčka", Average = 4, Gender = Gender.Male, Examined = true });
            AddPredefined = new RelayCommand(
                () => Students.Add(new Student { Firstname = "Xaver", Lastname="Fiala", Gender=Gender.Unknown, Average=3, Examined=true}),
                () => true
            );
            BalanceAverage = new RelayCommand(
                () => { foreach (var s in Students) { s.Average = 5; }; },
                () => true
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
