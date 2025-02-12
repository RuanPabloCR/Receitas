using System.Globalization;
namespace RecipeBook.APi.Middleware

{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /*public async Task Invoke(HttpContext context)
        {   
            var culture = context.Request.Headers["Accept-Language"].ToString();
            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = "en";
            }
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            await _next(context);
        } */
        public async Task Invoke(HttpContext context)
        {
            var cultureHeader = context.Request.Headers["Accept-Language"].ToString();
            string culture = "en"; // Cultura padrão caso nenhuma válida seja encontrada

            if (!string.IsNullOrWhiteSpace(cultureHeader))
            {
                var cultures = cultureHeader.Split(',')
                    .Select(c => c.Split(';')[0]) // Remove pesos como ";q=0.9"
                    .Select(c => c.Trim()) // Remove espaços em branco
                    .Where(c => !string.IsNullOrEmpty(c)); // Remove strings vazias

                foreach (var c in cultures)
                {
                    try
                    {
                        CultureInfo.CurrentCulture = new CultureInfo(c);
                        CultureInfo.CurrentUICulture = new CultureInfo(c);
                        culture = c; // Define a cultura válida encontrada
                        break; // Sai do loop assim que encontrar uma válida
                    }
                    catch (CultureNotFoundException)
                    {
                        // Ignora culturas inválidas e tenta a próxima
                    }
                }
            }

            await _next(context);
        }
    }
}