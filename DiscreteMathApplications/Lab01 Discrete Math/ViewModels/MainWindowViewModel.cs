using Lab01_Discrete_Math.Services;
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
        Intersection,
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
                OnPropertyChanged(nameof(C));
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
                OnPropertyChanged(nameof(C));
            }
        }

        public string C
        {
            get
            {
                try
                {
                    var aSet = _setParser.ParseSet<double>(_a);
                    var bSet = _setParser.ParseSet<double>(_b);

                    return _c = _setParser.SetToString(_setOperations[OperationType](aSet, bSet));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error: {ex.Message}");
                }

                return _c;
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

        public SetOperationType OperationType
        {
            get
            {
                return _operationType;
            }
            set
            {
                _operationType = value;
                OnPropertyChanged(nameof(C));
                UpdateImage();
                OnPropertyChanged(nameof(OperationType));
            }
        }

        private string _a = "";
        private string _b = "";
        private string _c = "";

        private string _operationTypeImage = "";

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
