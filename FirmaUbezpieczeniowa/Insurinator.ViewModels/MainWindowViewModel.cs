using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Insurinator.Interfaces.Services;
using Insurinator.Models.Entities;
using Insurinator.DataAccess.Services;

namespace Insurinator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand Clients_Click { get; }
        public ICommand AddEvent_Click { get; }
        public ICommand Insurinces_Click { get; }
        public ObservableCollection<Client> ClientsList { get; set; }

        public MainWindowViewModel()
        {
            ClientsService cs = new ClientsService();
          
            foreach (Client client in cs.GetAllAsync().Result)
            {
                ClientsList.Add(client);
            }
           
            /*   Clients_Click = new DelegateCommand(openClientsWindow);
               AddEvent_Click = new DelegateCommand(Browse);
               Insurinces_Click = new DelegateCommand(serialize);*/

        }
        private void openClientsWindow()
        {
           
       //  Insurence ind = new Insurence();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion
    }
}
