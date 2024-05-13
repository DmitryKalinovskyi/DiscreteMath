using MatrixRelation.Core;
using MatrixRelation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRelation.ViewModels
{
    public class MainWindowViewModel
    {
        public BindableProperty<string> P { get; set; }

        //public BindableProperty<List<Dictionary<string, bool>>> RelationMatrix { get; set; }
        public BindableProperty<double[,]> RelationMatrix { get; set; }

        public BindableProperty<string> SetA { get; set; }

        public BindableProperty<string> SetB { get; set; }

        //public BindableProperty<long[]> SetAReal { get; set; }
        //public BindableProperty<long[]> SetBReal { get; set; }

        private IMatrixRelationService<double> _matrixRelationServcie;
        private SetParser _setParser;

        public MainWindowViewModel()
        {
            _matrixRelationServcie = new MatrixRelationService<double>(MatrixRelationCondition);

            RelationMatrix = new BindableValue<double[,]>();
            //RelationMatrix = new BindableValue<List<Dictionary<string, bool>>>();
            SetA = new BindableValue<string>();
            SetB = new BindableValue<string>();
            P = new BindableValue<string>("\\rho=\\{(a, b) \\,|\\, (a\\in A) \\& (b\\in B) \\& (5a-b)\\vdots 3 \\}");

            //SetAReal = new BindableValue<long[]>();
            //SetAReal = new BindableValue<long[]>();
            _setParser = new SetParser();
        }

        private bool MatrixRelationCondition(double a, double b)
        {
            return (5 * a - b) % 3 == 0;
        }

        public void UpdateRelationMatrix()
        {
            try
            {

                // get list from set a, get list from set b
                double[] setA = [.. _setParser.ParseSetDouble(SetA.Value ?? "")];
                double[] setB = [.. _setParser.ParseSetDouble(SetB.Value ?? "")];

                var relationMatrix = _matrixRelationServcie.GetRelationMatrix(setA, setB);

                // build rows and columns
                var resultingMatrix = new double[relationMatrix.GetLength(0) + 1, relationMatrix.GetLength(1) + 1];
                for(int i = 0; i < setA.Length; i++)
                {
                    resultingMatrix[i+1, 0] = setA[i];
                }

                for(int i = 0; i < setB.Length; i++)
                {
                    resultingMatrix[0, i+1] = setB[i];
                }

                for(int i = 0; i <  relationMatrix.GetLength(0); i++)
                {
                    for(int j = 0; j < relationMatrix.GetLength(1); j++)
                    {
                        resultingMatrix[i + 1, j + 1] = relationMatrix[i, j] ? 1: 0;
                    }
                }

                RelationMatrix.Value = resultingMatrix;
            }
            catch { }
        }

        public RelayCommand UpdateRelationMatrixCommand => new RelayCommand(null, (obj) => UpdateRelationMatrix());
    }
}
