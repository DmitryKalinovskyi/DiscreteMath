using CombinatoricElements.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatoricElements.ViewModels
{
    public class PermutationPViewModel
    {
        public BindableProperty<long> N { get; set; }
        public BindableProperty<string> Pieces { get; set; }

        public BindableProperty<long> CalculationResult { get; set; }

        private ICombinatoricsService _combinatoricsService;
        private IArrayConvertor<long> _arrayConvertor;

        public PermutationPViewModel()
        {
            N = new();
            Pieces = new();
            CalculationResult = new();
            _combinatoricsService = new CombinatoricsService();
            _arrayConvertor = new ArrayConvertor<long>();
        }

        public PermutationPViewModel(ICombinatoricsService combinatoricsService)
        {
            N = new();
            Pieces = new();
            CalculationResult = new();
            _combinatoricsService = combinatoricsService;
            _arrayConvertor = new ArrayConvertor<long>();
        }

        public void CalculatePermutation(object? param)
        {
            // use convertor for pieces, to get array of numbers.
            var pieces = _arrayConvertor.ConvertFromString(Pieces.Value ?? "");

            CalculationResult.Value = _combinatoricsService.Permutations(N.Value, pieces);
        }

        public RelayCommand CalculatePermutationCommand => new RelayCommand(null, CalculatePermutation);
    }
}
