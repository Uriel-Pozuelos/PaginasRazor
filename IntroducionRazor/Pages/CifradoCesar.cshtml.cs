using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroducionRazor.Pages
{
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string Texto { get; set; } = "";

        [BindProperty]
        public int Salto { get; set; }

        [BindProperty]
        public string Salida { get; set; } = "";

        public void OnPostCodificar()
        {
            Salida = CaesarCipher(Texto, Salto);
        }

        public void OnPostDecodificar()
        {
            Salida = CaesarCipher(Texto, -Salto);
        }

        private string CaesarCipher(string texto, int salto)
        {
            char[] mensaje = texto.ToUpper().ToCharArray();
            for (int i = 0; i < mensaje.Length; i++)
            {
                char letra = mensaje[i];
                if (char.IsLetter(letra))
                {
                    char inicio = 'A';
                    letra = (char)((letra + salto - inicio) % 26 + inicio);
                    if (letra < 'A')
                    {
                        letra = (char)(letra + 26);
                    }
                    mensaje[i] = letra;
                }
            }
            return new string(mensaje);
        }
    }
}
