using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Abstract;

namespace BL.Model
{
    public class ModelProduct : AbstractModel<ModelProduct>
    {
        private string _Id;
        private string _Name;
        private double _Price;
        private int _Count;

        

        public string Id
        {
            get { return _Id; }
            set
            {
                if (value == _Id) return;
                _Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == _Name) return;
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Price
        {
            get { return _Price; }
            set
            {
                if (value == _Price) return;
                _Price = value;
                OnPropertyChanged("Price");
            }
        }

        public int Count
        {
            get { return _Count; }
            set
            {
                if (value == _Count) return;
                _Count = value;
                OnPropertyChanged("Count");
            }
        }

        public override ModelProduct GetDeepCopy()
        {
            var result = new ModelProduct
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Count = Count
            };
            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
