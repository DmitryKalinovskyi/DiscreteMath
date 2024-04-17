using CombinatoricElements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.ViewModels
{
    public class CombinationsViewModel
    {
        public BindableProperty<long> N { get; set; }
        public BindableProperty<long> M { get; set; }
        public BindableProperty<long> CalculationResult { get; set; }

        private ICombinatoricsService _combinatoricsService;

        public CombinationsViewModel()
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = new CombinatoricsService();
        }

        public CombinationsViewModel(ICombinatoricsService combinatoricsService)
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = combinatoricsService;
        }

        public void CalculateCombination(object? param)
        {
            CalculationResult.Value = _combinatoricsService.Combinations_nm(N.Value, M.Value);
        }

        public RelayCommand CalculatePermutationCommand => new RelayCommand(null, CalculateCombination);
    }
}
