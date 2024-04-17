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
        public BindableProperty<bool[,]> RelationMatrix { get; set; }

        public BindableProperty<string> SetA { get; set; }

        public BindableProperty<string> SetB { get; set; }

        private IMatrixRelationService<long> _matrixRelationServcie;
        private SetParser _setParser;

        public MainWindowViewModel()
        {
            _matrixRelationServcie = new MatrixRelationService<long>(MatrixRelationCondition);
            
            RelationMatrix = new();
            SetA = new();
            SetB = new();
            _setParser = new SetParser();
        }

        private bool MatrixRelationCondition(long a, long b)
        {
            return (5 * a - b) % 3 == 0;
        }

        public void UpdateRelationMatrix()
        {
            // get list from set a, get list from set b
            var setA = _setParser.ParseSetConcrete<long>(SetA.Value ?? "");
            var setB = _setParser.ParseSetConcrete<long>(SetB.Value ?? "");

            RelationMatrix.Value = _matrixRelationServcie.GetRelationMatrix(setA, setB);
        }
    }
}
