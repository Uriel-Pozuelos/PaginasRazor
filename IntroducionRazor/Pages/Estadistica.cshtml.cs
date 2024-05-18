using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroducionRazor.Pages
{
    public class EstadisticaModel : PageModel
    {
        public int[] Numeros { get; set; }
        public int Sum { get; set; }
        public double Prom { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }


        //agrega una variable que contenga el arreglo pero ordenado
        public int[] NumerosOrdenados { get; set; }

        public void OnGet()
        {
            GenerateRandomNumbers();
            CalcularEstadisticas();
        }

        private void GenerateRandomNumbers()
        {
            Random random = new Random();
            Numeros = new int[20];
            for (int i = 0; i < Numeros.Length; i++)
            {
                Numeros[i] = random.Next(0, 101);
            }
        }

        private void CalcularEstadisticas()
        {
            Sum = Numeros.Sum();
            Prom = Numeros.Average();
            Moda = CalcularModa(Numeros);
            Mediana = CalcularMediana(Numeros);
        }

        private List<int> CalcularModa(int[] numeros)
        {
            var numberGroups = numeros.GroupBy(n => n)
                                      .Select(group => new { Number = group.Key, Count = group.Count() })
                                      .OrderByDescending(g => g.Count)
                                      .ToList();

            int maxCount = numberGroups.First().Count;
            return numberGroups.Where(g => g.Count == maxCount).Select(g => g.Number).ToList();
        }

        private double CalcularMediana(int[] numeros)
        {
            var sortedNumbers = numeros.OrderBy(n => n).ToArray();
            NumerosOrdenados = sortedNumbers;
            int size = sortedNumbers.Length;
            if (size % 2 == 0)
            {
                return (sortedNumbers[size / 2 - 1] + sortedNumbers[size / 2]) / 2.0;
            }
            else
            {
                return sortedNumbers[size / 2];
            }
        }
    }
}
