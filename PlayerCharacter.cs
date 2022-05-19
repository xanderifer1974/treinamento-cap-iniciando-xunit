using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IniciandoXUnit
{
    public class PlayerCharacter: INotifyPropertyChanged
    {
        private int _helth = 100;

        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string  NickName { get; set; }
        public bool experiente { get; set; }

        public int Helth {
            get => _helth;
            set
            {
                _helth = value;
                OnPropertyChanged();

            }
        }

        public PlayerCharacter(string firstName)
        {
            this.FirstName = firstName;
            this.experiente = true;
            CreatingStartingWeapons();
        }

        public PlayerCharacter()
        {
            Random random = new Random();
            this.FirstName = $"PlayCharacter-{random.Next()}";
            this.experiente = true;
            CreatingStartingWeapons();
        }

        public bool IsNoob()  
        {          

            return experiente;
        }

        public event EventHandler<EventArgs> PlayerSlept;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> Weapons { get; set; }

        public void Sleep()
        {
            var healthIncrease =CalculateHealthIncrease();

            Helth += healthIncrease;

            OnPlayerSlept(EventArgs.Empty);

            
        }

        private int CalculateHealthIncrease()
        {
            var rnd = new Random();

            return rnd.Next(1, 101);
            
        }

        protected virtual void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void TakeDamage(int damage)
        {
            Helth = Math.Max(1,Helth -= damage);
        }

        private void CreatingStartingWeapons()
        {
            Weapons = new List<string>
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"                
            };
        }
    }
}
