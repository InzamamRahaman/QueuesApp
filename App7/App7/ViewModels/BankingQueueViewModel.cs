using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7.ViewModels
{
    class BankingQueueViewModel : GeneralQueueViewModel
    {

        private int _swapsLeft;
        private int _position;
        private string _color;

        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
                this.OnPropertyChanged("Color");
            }
        }

        public BankingQueueViewModel(int id, string owner, double estimated, int position) : 
            base(id, owner, estimated)
        {
            _swapsLeft = 3;
            _position = position;
            _color = "White";
        }

        public void UseSwap()
        {
            if (_swapsLeft > 0)
                _swapsLeft -= 1;
        }

        public int SwapsLeft
        {
            get
            {
                return _swapsLeft;
            }
        }

        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                this.OnPropertyChanged("Position");
                this.OnPropertyChanged("Representation");
            }
        }

        public void MovePosition(int displacement)
        {
            Position = Position + displacement;
        }

        public  string Representation
        {
            get
            {
                string repr = _queueOwner + "\n" + "Estimated Time: " + _estimatedTime + " miuntes\n";
                repr = repr + "Position: " + _position;
                return repr;
            }
        }

    }
}
