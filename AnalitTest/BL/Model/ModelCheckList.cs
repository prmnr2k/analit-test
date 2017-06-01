using BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model
{
    class ModelCheckList : AbstractModel<ModelCheckList>
    {
        private string _Id;
        private List<ModelCheckPosition> _CheckList;

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

        public List<ModelCheckPosition> CheckList
        {
            get { return _CheckList; }
            set
            {
                if (value == _CheckList) return;
                _CheckList = value;
                OnPropertyChanged("CheckList");
                OnPropertyChanged("CheckSumm");
            }
        }

        public double CheckSumm
        {
            get
            {
                double result = 0;
                foreach (var iter in CheckList)
                    result += iter.Price;
                return result;
            }
        }

        public override ModelCheckList GetDeepCopy()
        {
            var result = new ModelCheckList
            {
                Id = Id,
                CheckList = CheckList
            };
            return result;
        }
    }
}
