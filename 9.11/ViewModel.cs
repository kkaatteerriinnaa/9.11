using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _9._11.Model;

namespace _9._11
{
    internal class ViewModel
    {
        public class PersonViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Person> _people;
            public ObservableCollection<Person> People
            {
                get { return _people; }
                set
                {
                    _people = value;
                    OnPropertyChanged("People");
                }
            }

            public PersonViewModel()
            {
                People = new ObservableCollection<Person>();
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void AddPerson(Person person)
            {
                People.Add(person);
            }

            public void RemovePerson(Person person)
            {
                People.Remove(person);
            }

            public void EditPerson(Person person, string fullName, string address, string phoneNumber)
            {
                person.FullName = fullName;
                person.Address = address;
                person.PhoneNumber = phoneNumber;
            }

            public void SaveToFile(string filename)
            {
                using (StreamWriter file = new StreamWriter(filename))
                {
                    foreach (Person person in People)
                    {
                        file.WriteLine($"{person.FullName},{person.Address},{person.PhoneNumber}");
                    }
                }
            }

            public void LoadFromFile(string filename)
            {
                People.Clear();
                using (StreamReader file = new StreamReader(filename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        People.Add(new Person { FullName = parts[0], Address = parts[1], PhoneNumber = parts[2] });
                    }
                }
            }
        }
    }
}
