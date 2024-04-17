using CombinatoricElements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.ViewModels
{
    public class PermutationPageViewModel
    {
        public BindableProperty<long> N { get; set; }
        public BindableProperty<long> M { get; set; } 
        public BindableProperty<long> CalculationResult { get; set; } 

        private ICombinatoricsService _combinatoricsService;

        public PermutationPageViewModel()
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = new CombinatoricsService();
        }

        public PermutationPageViewModel(ICombinatoricsService combinatoricsService)
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = combinatoricsService;
        }
        
        public void CalculatePermutation(object? param)
        {
            CalculationResult.Value = _combinatoricsService.Permutations_nm(N.Value, M.Value);
        }

        public RelayCommand CalculatePermutationCommand => new RelayCommand(null, CalculatePermutation);
    }
}
