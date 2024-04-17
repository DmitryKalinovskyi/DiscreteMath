using CombinatoricElements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.ViewModels
{
    public class PermutationRepViewModel
    {
        public BindableProperty<long> N { get; set; }
        public BindableProperty<long> M { get; set; }
        public BindableProperty<long> CalculationResult { get; set; }

        private ICombinatoricsService _combinatoricsService;

        public PermutationRepViewModel()
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = new CombinatoricsService();
        }

        public PermutationRepViewModel(ICombinatoricsService combinatoricsService)
        {
            N = new();
            M = new();
            CalculationResult = new();
            _combinatoricsService = combinatoricsService;
        }

        public void CalculatePermutationRep(object? param)
        {
            CalculationResult.Value = _combinatoricsService.Permutations_nm_Repeats(N.Value, M.Value);
        }

        public RelayCommand CalculatePermutationCommand => new RelayCommand(null, CalculatePermutationRep);
    }
}
