using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace BlogApi
{
    public class SwaggerClientGenerator 
    {
        public async Task GenerateClient() {
            var httpClient = new HttpClient();

            var swaggerJson = await httpClient.GetStringAsync("http://localhost:5048/swagger/v1/swagger.json");

            var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "BlogApiClient",
                CSharpGeneratorSettings =
                {
                    Namespace = "BlogApi",
                }
            };

            var generator = new CSharpClientGenerator(document, settings);

            var code = generator.GenerateFile();

            await File.WriteAllTextAsync("BlogApiClient.cs", code);
        }
    }
}