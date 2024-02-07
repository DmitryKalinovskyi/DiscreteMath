using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_Discrete_Math.ViewModels
{
    public enum SetOperationType
    {
        Union = 0,
        Intersection = 1,
        Difference,
        SymmetricDifference
    }

    public class MainWindowViewModel: NotifyViewModel
    {
        
        public string A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                OnPropertyChanged(nameof(A));
            }
        }

        public string B
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value;
                OnPropertyChanged(nameof(B));
            }
        }

        public string C
        {
            get
            {
                return _c;
            }
            set
            {
                _c = value;
                OnPropertyChanged(nameof(C));
            }
        }

        public SetOperationType OperationType
        {
            get
            {
                return _operationType;
            }
            set
            {
                _operationType = value;
                UpdateImage();
                OnPropertyChanged(nameof(OperationType));
            }
        }

        public string OperationTypeImage
        {
            get
            {
                if (string.IsNullOrEmpty(_operationTypeImage))
                    UpdateImage();

                return _operationTypeImage;
            }
            set
            {
                _operationTypeImage = value;
                OnPropertyChanged(nameof(OperationTypeImage));
            }
        }

        private string _operationTypeImage = "";

        private string _a = "", _b = "", _c = "";


        private SetOperationType _operationType = SetOperationType.Union;

        private SetParser _setParser;
        private IDiscreteCalculator _discreteCalculator;

        private delegate List<T> SetOperation<T>(List<T> a, List<T> b);

        private Dictionary<SetOperationType, SetOperation<double>> _setOperations;

        public MainWindowViewModel()
        {
            _setParser = new SetParser();
            _discreteCalculator = new DiscreteCalculator();
            _setOperations = new()
            {
                { SetOperationType.Union, _discreteCalculator.Union },
                { SetOperationType.Intersection, _discreteCalculator.Intersection },
                { SetOperationType.Difference, _discreteCalculator.Difference },
                { SetOperationType.SymmetricDifference, _discreteCalculator.SymmetricDifference }
            };

            PropertyChanged += (s, args) =>
            {
                if (args.PropertyName == nameof(A) || args.PropertyName == nameof(B) || args.PropertyName == nameof(OperationType))
                {
                    UpdateC();
                }
            };
        }

        public void UpdateC()
        {
            try
            {
                var aSet = _setParser.ParseSet<double>(_a);
                var bSet = _setParser.ParseSet<double>(_b);

                C = _setParser.SetToString(_setOperations[OperationType](aSet, bSet));
            }
            catch(Exception ex)
            {
                Trace.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateImage()
        {

            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            var route = $"/{assemblyName};component/Images/";


            OperationTypeImage = route + (_operationType switch
            {
                SetOperationType.Union => "Union.png",
                SetOperationType.Intersection => "Intersection.png",
                SetOperationType.Difference => "Difference.png",
                SetOperationType.SymmetricDifference => "SymmetricDifference.png"
            });
        }
    }
}
