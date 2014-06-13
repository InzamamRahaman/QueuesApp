using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace App7.ViewModels
{
    class BankingQueueListing : MyViewModel
    {
        public ObservableCollection<BankingQueueViewModel> Queues;
        private Dictionary<int, BankingQueueViewModel> listing;
        private static BankingQueueListing Instance;

        public static BankingQueueListing GetInstance()
        {
            if(Instance == null)
            {
                Instance = new BankingQueueListing();
            }

            return Instance;
        }

        private BankingQueueListing()
        {
            Queues = new ObservableCollection<BankingQueueViewModel>();
            listing = new Dictionary<int, BankingQueueViewModel>();
            LoadData();
        }

        private void LoadData()
        {
            AddQueue(new BankingQueueViewModel(1324, "Republic Bank", 25.34,23));
            AddQueue(new BankingQueueViewModel(34, "First Citizens Bank", 13.4, 5));
            AddQueue(new BankingQueueViewModel(254317, "Scotia Bank", 89.7, 3));
            AddQueue(new BankingQueueViewModel(134, "Royal Bank of Canada", 120, 15));
        }

        public void DecrementAll()
        {
            foreach(BankingQueueViewModel Q in Queues)
            {
                Q.DecrementTime();
            }
        }

        public void AddQueue(BankingQueueViewModel model)
        {
            if(!listing.ContainsKey(model.ID))
            {
                Queues.Add(model);
                listing.Add(model.ID, model);
                this.OnPropertyChanged("Queues");
            }
        }

        public void RemoveQueue(int id)
        {
            BankingQueueViewModel Q = null;
            listing.TryGetValue(id, out Q);
            if(Q != null)
            {
                listing.Remove(id);
                Queues.Remove(Q);
                this.OnPropertyChanged("Queues");
            }
        }

        public void UseSwap(int id)
        {
            BankingQueueViewModel Q = null;
            listing.TryGetValue(id, out Q);
            if (Q != null)
            {
                Q.UseSwap();
                this.OnPropertyChanged("Queues");
            }
        }




    }
}
