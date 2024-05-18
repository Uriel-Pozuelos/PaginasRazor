using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroducionRazor.Pages
{
    public class SumaNumerosModel : PageModel
    {
        [BindProperty]
        public string num1 { get; set; } = "";

        [BindProperty]
        public string num2 { get; set; } = "";

        public double res;
        //Obten la suma de los numeros ingresados en los inputs y luego muestra el resultado en
        // el respectivo input de resultado
        
        public void OnPost()
        {
            double n1 = double.Parse(num1);
            double n2 = double.Parse(num2);
            res = n1 + n2;

            ModelState.Clear();
        }

    }
}
