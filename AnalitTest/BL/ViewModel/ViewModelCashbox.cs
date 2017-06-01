using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Abstract;
using BL.Bridge;
using BL.Model;
using System.Collections.ObjectModel;

namespace BL.ViewModel
{

    public class ViewModelCashbox : AbstractNotifyPropertyChanged
    {
        private DataSource _dataSource = new DataSource();

        private string _Id;
        private ObservableCollection<ModelCheckPosition> _CheckList = new ObservableCollection<ModelCheckPosition>();
        private List<ModelProduct> _ProductList = new List<ModelProduct>();
        private ModelCheckPosition _CurrentPosition;

        public int PositionCount => _CheckList.Where(obj => obj.Count > 0).ToList().Count;

        public bool CanCloseCheck => Cash >= CheckSumm && Cash > 0;

        public Command ClearCommand { get; set; }

        public Command CloseCheckCommand { get; set; }

        private double _Cash = 0;
        public double Cash
        {
            get { return _Cash; }
            set
            {
                if (value == _Cash) return;
                _Cash = value;
                OnPropertyChanged("Cash");
                OnPropertyChanged("CanCloseCheck");
                OnPropertyChanged("Change");
                OnPropertyChanged("CheckSumm");
            }
        }

        public double Change => (CanCloseCheck) ? Cash - CheckSumm : 0;

        public ModelCheckPosition CurrentPosition
        {
            get { return _CurrentPosition; }
            set
            {
                if (value == _CurrentPosition) return;
                _CurrentPosition = value;
                OnPropertyChanged("CurrentPosition");
                OnPropertyChanged("CheckSumm");
                OnPropertyChanged("PositionCount");
                OnPropertyChanged("Cash");
                OnPropertyChanged("CanCloseCheck");
                OnPropertyChanged("Change");
            }
        }

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

        public ObservableCollection<ModelCheckPosition> CheckList
        {
            get { return _CheckList; }
            set
            {
                if (value == _CheckList) return;
                _CheckList = value;
                OnPropertyChanged("CheckList");
                OnPropertyChanged("CheckSumm");
                OnPropertyChanged("PositionCount");
                OnPropertyChanged("Cash");
                OnPropertyChanged("CanCloseCheck");
                OnPropertyChanged("Change");
            }
        }

        public List<ModelProduct> ProductList
        {
            get { return _ProductList; }
            set
            {
                if (value == _ProductList) return;
                _ProductList = value;
                OnPropertyChanged("ProductList");
                OnPropertyChanged("Cash");
                OnPropertyChanged("CanCloseCheck");
                OnPropertyChanged("Change");
                OnPropertyChanged("CheckSumm");
            }
        }

        public double CheckSumm
        {
            get
            {
                double result = 0;
                foreach (var iter in _CheckList)
                    result += iter.Price;
                return result;
            }
        }

        public ViewModelCashbox()
        {
            ProductList = _dataSource.GetListProduct();
            Id = System.Guid.NewGuid().ToString();
            CheckList.Add(new ModelCheckPosition { Product = ProductList[0],Count = 1 });
            CheckList.Add(new ModelCheckPosition { Product = ProductList[2], Count = 2 });
            CheckList.Add(new ModelCheckPosition { Product = ProductList[3], Count = 4 });
            CheckList.Add(new ModelCheckPosition { Product = ProductList[5], Count = 1 });
            ClearCommand = new Command(obj => Clear());
            CloseCheckCommand = new Command(obj => CloseCheck());
        }

        private void Clear()
        {
            CheckList = new ObservableCollection<ModelCheckPosition>();
            CurrentPosition = new ModelCheckPosition();
            Cash = 0;
            ProductList = _dataSource.GetListProduct();
        }

        private void CloseCheck()
        {
            if(_dataSource.CloseCheck(Id, CheckList.ToList()))
            {
                Clear();
            }
        }
    }
}
