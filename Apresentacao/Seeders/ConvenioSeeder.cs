using Aplicacao.DTO.Convenio;
using Aplicacao.Interfaces;

namespace Apresentacao.Seeders;

public static class ConvenioSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        await CriarConvenio(scope, "Amil");
        await CriarConvenio(scope, "Unimed");
        await CriarConvenio(scope, "Bradesco");
        await CriarConvenio(scope, "Porto");
        await CriarConvenio(scope, "SulAmérica");
        await CriarConvenio(scope, "NotreDame");
    }
    private static async Task CriarConvenio(IServiceScope serviceScope, string nome)
    {
        var convenioService = serviceScope.ServiceProvider.GetRequiredService<IConvenioService>();
        if (await convenioService.GetByNameAsync(nome) is null)
            await convenioService.CreateAsync(new NovoConvenioDTO()
            {
                Nome = nome
            });

    }
}
