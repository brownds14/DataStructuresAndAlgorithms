using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SortingAlgorithmsPresenter.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataStructuresAndAlgorithms.SortingAlgorithms;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;

namespace SortingAlgorithmsPresenter.ViewModel
{
    using System.Runtime.CompilerServices;
    using SortAlg = Tuple<string, Action<int[]>>;

    public class MainViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> propErrors = new Dictionary<string, List<string>>();
        private SortAlg[] SortingAlgorithms =
            {
                new SortAlg("BubbleSort", Sorting.BubbleSort),
                new SortAlg("SelectionSort", Sorting.SelectionSort),
                new SortAlg("InsertionSort", Sorting.InsertionSort),
                new SortAlg("MergeSort", Sorting.MergeSort),
                new SortAlg("HeapSort", Sorting.HeapSort)
        };

        #region Binding Properties
        private ObservableCollection<TimedResultModel> _results;
        public ObservableCollection<TimedResultModel> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged("Results");
            }
        }

        private string _min;
        public string Min
        {
            get { return _min; }
            set
            {
                _min = value;
                RaisePropertyChanged("Min");
            }
        }

        private string _max;
        public string Max
        {
            get { return _max; }
            set
            {
                _max = value;
                RaisePropertyChanged("Max");
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                RaisePropertyChanged("Size");
            }
        }

        private bool _sorted;
        public bool Sorted
        {
            get { return _sorted; }
            set
            {
                _sorted = value;
                RaisePropertyChanged("Sorted");
            }
        }

        private bool _canRun;

        public bool CanRun
        {
            get { return _canRun; }
            set
            {
                _canRun = value;
                RaisePropertyChanged("CanRun");
            }
        }

        public ICommand RunAlgorithmsCommand { get; private set; }
        #endregion

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void RaiseErrorsChanged(string propertyName)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            var args = new DataErrorsChangedEventArgs(propertyName);
            handler.Invoke(this, args);
        }

        public bool HasErrors
        {
            get { return propErrors.Count > 0; }
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName) || !propErrors.ContainsKey(propertyName))
                return null;
            else
                return propErrors[propertyName];
        }

        private void AddError(string propertyName, string errorMsg)
        {
            if (!propErrors.ContainsKey(propertyName))
                propErrors.Add(propertyName, new List<string>() { errorMsg });
            RaiseErrorsChanged(propertyName);
        }

        private void RemoveError(string propertyName)
        {
            propErrors.Remove(propertyName);
            RaiseErrorsChanged(propertyName);
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Results = new ObservableCollection<TimedResultModel>();
            RunAlgorithmsCommand = new RelayCommand(RunAlgorithms);
            _min = "0";
            _max = "1000";
            _size = "10000";
            _sorted = false;
            _canRun = true;
        }

        public void MinValidate()
        {
            string intError = "Value is not an integer";
            int tmp;

            if (Int32.TryParse(_min, out tmp))
            {
                RemoveError("Min");
                MinMaxValidate();
            }
            else
                AddError("Min", intError);
        }

        public void MaxValidate()
        {
            string intError = "Value is not an integer";
            int tmp;

            if (Int32.TryParse(_max, out tmp))
                RemoveError("Max");
            else
                AddError("Max", intError);

            MinValidate();
        }

        public void SizeValidate()
        {
            string uintError = "Value must be a positive integer";
            uint tmp;

            if (UInt32.TryParse(_size, out tmp))
                RemoveError("Size");
            else
                AddError("Size", uintError);
        }

        public void MinMaxValidate()
        {
            string minError = "Minimum value must be less than maximum value";
            string maxError = "Maximum value must be greater than minimum value";

            if (propErrors.ContainsKey("Min") || propErrors.ContainsKey("Max"))
                return;

            if (Int32.Parse(_min) > Int32.Parse(_max))
            {
                AddError("Min", minError);
                AddError("Max", maxError);
            }
            else //_min <= _max
            {
                RemoveError("Min");
                RemoveError("Max");
            }
        }

        private void RunAlgorithms()
        {
            _results.Clear();

            int[] testArray;
            if (Sorted)
                testArray = Sorting.CreateSortedList(UInt32.Parse(_size), Int32.Parse(_min), Int32.Parse(_max));
            else
                testArray = Sorting.CreateRandomList(1000, 0, 1000);

            foreach (var alg in SortingAlgorithms)
            {
                _results.Add(RunAlgorithm(alg, (int[])testArray.Clone()));
            }
        }

        private TimedResultModel RunAlgorithm(SortAlg alg, int[] arr)
        {
            Stopwatch watch = new Stopwatch();
            Action<int[]> action = alg.Item2;
            string name = alg.Item1;

            watch.Start();
            action(arr);
            watch.Stop();

            return new TimedResultModel(name, watch.Elapsed.ToString());
        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);

            if (propertyName == null)
                return;

            switch (propertyName)
            {
                case "Min":
                    MinValidate();
                    break;
                case "Max":
                    MaxValidate();
                    break;
                case "Size":
                    SizeValidate();
                    break;
                case "CanRun":
                    return;
            }

            CanRun = !this.HasErrors;
        }
    }
}