using CombinatoricElements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.ViewModels
{
    public class CombintationsRepViewModel
    {
        public BindableProperty<long> N { get; set; }
        public BindableProperty<long> M { get; set; }
        public BindableProperty<long> CalculationResult { get; set; }

        private ICombinatoricsService _combinatoricsService;

        public CombintationsRepViewModel()
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = new CombinatoricsService();
        }

        public CombintationsRepViewModel(ICombinatoricsService combinatoricsService)
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = combinatoricsService;
        }

        public void CalculateCombinationRep(object? param)
        {
            CalculationResult.Value = _combinatoricsService.Combinations_nm_Repeats(N.Value, M.Value);
        }

        public RelayCommand CalculatePermutationCommand => new RelayCommand(null, CalculateCombinationRep);
    }
}
