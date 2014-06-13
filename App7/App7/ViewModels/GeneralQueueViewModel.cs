using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7.ViewModels
{
    class GeneralQueueViewModel : MyViewModel
    {

        protected int _id;
        protected string _queueOwner;
        protected int _estimatedTime;
       
        public GeneralQueueViewModel(int id, string owner, double estimation)
        {
            this._id = id;
            this._queueOwner = owner;
            this._estimatedTime = (int)Math.Ceiling(estimation);
        }

        public void DecrementTime()
        {
            if(_estimatedTime > 0)
            {
                _estimatedTime -= 1;
                this.OnPropertyChanged("Representation");
            }
        }

        public string Representation
        {
            get
            {
                return this.ToString();
            }

        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public void AddTime(double est)
        {
            _estimatedTime += (int)Math.Ceiling(est);
        }

        public void ResetTime(double est)
        {
            _estimatedTime = (int)Math.Ceiling(est);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override string ToString()
        {
            string repr = _queueOwner + "\n";
            repr = repr + "Estimated Time: " + _estimatedTime + " minutes";
            return repr;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            GeneralQueueViewModel gen = obj as GeneralQueueViewModel;

            if (gen == null)
            {
                return false;
            }

            return this._id == gen._id;
        }
       

    }
}
