using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace App7.ViewModels
{
    class GeneralQueueListing : MyViewModel
    {

        public ObservableCollection<GeneralQueueViewModel> Queues;
        private Dictionary<int, GeneralQueueViewModel> listings;
        private static GeneralQueueListing Instance;

        public static GeneralQueueListing GetInstance()
        {
            if(Instance == null)
            {
                Instance = new GeneralQueueListing();
            }

            return Instance;
        }

        private GeneralQueueListing()
        {
            Queues = new ObservableCollection<GeneralQueueViewModel>();
            listings = new Dictionary<int, GeneralQueueViewModel>();
            LoadData();
        }

        public void DecrementAll()
        {
            foreach(GeneralQueueViewModel Q in Queues)
            {
                Q.DecrementTime();
            }
        }

        private void LoadData()
        {
            AddQueue(new GeneralQueueViewModel(1234, "Burger King", 23.5));
            AddQueue(new GeneralQueueViewModel(32423, "Marios", 15.6));
            AddQueue(new GeneralQueueViewModel(82989, "KFC", 89.4));
            AddQueue(new GeneralQueueViewModel(56427, "Royal Castle", 34.5));
        }

        public void AddQueue(GeneralQueueViewModel model)
        {
            if(!listings.ContainsKey(model.ID))
            {
                Queues.Add(model);
                listings.Add(model.ID, model);
                this.OnPropertyChanged("Queues");
            }
        }

        public void RemoveQueue(int id)
        {
            GeneralQueueViewModel model = null;
            listings.TryGetValue(id, out model);

            if(model != null)
            {
                listings.Remove(id);
                Queues.Remove(model);
                this.OnPropertyChanged("Queues");
            }

        }
    }
}
