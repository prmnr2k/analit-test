using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Abstract;

namespace BL.Model
{
    public class ModelCheckPosition : AbstractModel<ModelCheckPosition>
    {
        private ModelProduct _Product;
        private int _Count;

        public ModelProduct Product
        {
            get { return _Product; }
            set
            {
                if (value == _Product) return;
                _Product = value;
                OnPropertyChanged("Product");
                OnPropertyChanged("Price");
            }
        }

        public int Count
        {
            get { return _Count; }
            set
            {
                if (value == _Count || value < 0) return;
                _Count = (value <= Product.Count)? value : Product.Count;
                OnPropertyChanged("Count");
                OnPropertyChanged("Price");
            }
        }

        public double Price => Product.Price * Count;

        public ModelCheckPosition()
        {
            Product = new ModelProduct();
            Count = 1;
        }

        public override ModelCheckPosition GetDeepCopy()
        {
            var result = new ModelCheckPosition
            {
                Product = Product,
                Count = Count
            };
            return result;
        }
    }
}
