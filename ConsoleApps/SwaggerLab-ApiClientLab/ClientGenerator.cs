
using Microsoft.OpenApi.Models;
using NSwag.CodeGeneration.CSharp;
using NSwag;

namespace SwaggerLab_ApiClientLab
{
    public class ClientGenerator
    {
        public async Task GenerateClient()
        {
            using var httpClient = new HttpClient();
            var swaggerJson = await httpClient.GetStringAsync("http://localhost:5000/swagger/v1/swagger.json");
            var document = await NSwag.OpenApiDocument.FromJsonAsync(swaggerJson);

            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "CustomApiClient",
                CSharpGeneratorSettings = { Namespace = "SwaggerLab_ApiClientLab" }
            };

            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();

            await File.WriteAllTextAsync("CustomApiClient.cs", code);
        }
    }
}