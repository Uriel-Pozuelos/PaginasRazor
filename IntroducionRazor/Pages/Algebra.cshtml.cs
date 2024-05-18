using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroducionRazor.Pages
{
    public class AlgebraModel : PageModel
    {
        [BindProperty]
        public string a { get; set; } = "";

        [BindProperty]
        public string b { get; set; } = "";

        [BindProperty]
        public string x { get; set; } = "";

        [BindProperty]
        public string y { get; set; } = "";

        [BindProperty]
        public string n { get; set; } = "";

        public double res;

        public List<string> Sumatoria { get; set; } = new List<string>();
        public List<string> Factoriales { get; set; } = new List<string>();

        public void OnPost()
        {
            // Desarrollar una función que permita evaluar la expresión (ax + by)^n usando el binomio de Newton
            double a1 = double.Parse(a);
            double b1 = double.Parse(b);
            double x1 = double.Parse(x);
            double y1 = double.Parse(y);
            double n1 = double.Parse(n);

            res = EvaluarBinomio(a1, b1, x1, y1, (int)n1);

            ModelState.Clear();
        }

        private double EvaluarBinomio(double a, double b, double x, double y, int n)
        {
            double resultado = 0;
            Sumatoria.Clear();
            Factoriales.Clear();

            for (int k = 0; k <= n; k++)
            {
                double coefBinomial = CalcularCoeficienteBinomial(n, k);
                double termino = coefBinomial * Math.Pow(a * x, n - k) * Math.Pow(b * y, k);
                resultado += termino;

                Sumatoria.Add($"Término {k}: {coefBinomial} * ({a} * {x})^{n - k} * ({b} * {y})^{k} = {termino}");
            }

            return resultado;
        }

        private double CalcularCoeficienteBinomial(int n, int k)
        {
            double coef = Factorial(n) / (Factorial(k) * Factorial(n - k));
            Factoriales.Add($"C({n}, {k}): {n}! / ({k}! * ({n} - {k})!) = {coef}");
            return coef;
        }

        private double Factorial(int num)
        {
            if (num == 0)
                return 1;
            double resultado = 1;
            for (int i = 1; i <= num; i++)
            {
                resultado *= i;
            }
            Factoriales.Add($"{num}! = {resultado}");
            return resultado;
        }
    }
}
