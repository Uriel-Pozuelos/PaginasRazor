using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroducionRazor.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public string Peso { get; set; } = "";

        [BindProperty]
        public string Altura { get; set; } = "";

        public double res;

        public void OnPost()
        {
            double p = double.Parse(Peso);
            double a = double.Parse(Altura);
            res = p / Math.Pow(a,2);
            ModelState.Clear();
        }

    }
}
