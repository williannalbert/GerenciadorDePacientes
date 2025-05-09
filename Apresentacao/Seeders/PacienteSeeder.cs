using Aplicacao.DTO.Paciente;
using Aplicacao.Interfaces;
using Dominio.Enums;

namespace Apresentacao.Seeders;

public static class PacienteSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        await CriarPaciente(scope,
            "Amil",
            "Bruno",
            "Souza",
            Convert.ToDateTime("1987-03-22T00:00:00"),
            Genero.Masculino,
            "42123288012",
            "7654321",
            Estado.MG,
            "bruno.souza@example.com",
            "12988888888",
            "1234445678",
            "0987654321",
            "11/24",
            true
            );

        await CriarPaciente(scope,
            "Porto",
            "Carla",
            "Medeiros",
            Convert.ToDateTime("1990-08-10T00:00:00"),
            Genero.Feminino,
            "26181397043",
            "1234599",
            Estado.AL,
            "carla.medeiros@example.com",
            "21923457890",
            "2133447788",
            "2345678901",
            "10/26",
            true
            );

        await CriarPaciente(scope,
            "Amil",
            "Diego",
            "Alves",
            Convert.ToDateTime("1983-12-01T00:00:00"),
            Genero.Masculino,
            "26181397043",
            "1122334",
            Estado.MS,
            "diego.alves@example.com",
            "51999991234",
            "5133334444",
            "3456789012",
            "01/27",
            true
            );

        await CriarPaciente(scope,
            "SulAmérica",
            "Eduarda",
            "Campos",
            Convert.ToDateTime("2001-02-18T00:00:00"),
            Genero.Feminino,
            "53839944082",
            "9988776",
            Estado.SP,
            "eduarda.campos@example.com",
            "41912341234",
            "4132322121",
            "4567890123",
            "06/25",
            true
            );

        await CriarPaciente(scope,
            "Bradesco",
            "Fábio",
            "Lima",
            Convert.ToDateTime("1992-09-09T00:00:00"),
            Genero.Masculino,
            "53815441030",
            "1234569",
            Estado.PB,
            "fabio.lima@example.com",
            "71987654321",
            "7134567890",
            "5678901234",
            "09/24",
            true
            );

        await CriarPaciente(scope,
            "Unimed",
            "Gisele",
            "Ferreira",
            Convert.ToDateTime("1988-07-20T00:00:00"),
            Genero.Feminino,
            "39913515017",
            "1111222",
            Estado.TO,
            "gisele.ferreira@example.com",
            "85934567890",
            "8533445566",
            "6789012345",
            "03/26",
            false
            );
    }

    private static async Task CriarPaciente(IServiceScope serviceScope, 
        string convenioNome,
        string nome,
        string sobrenome,
        DateTime dataNascimento,
        Genero genero,
        string cpf,
        string rg,
        Estado estado,
        string email,
        string celular,
        string telefone,
        string numCarteirinha,
        string validadeCarteirinha,
        bool status = true
        )
    {
        var convenioService = serviceScope.ServiceProvider.GetRequiredService<IConvenioService>();
        var pacienteService = serviceScope.ServiceProvider.GetRequiredService<IPacienteService>();

        var convenio = await convenioService.GetByNameAsync(convenioNome);
        if (await pacienteService.GetByCpfAsync(cpf) is null)
            await pacienteService.CreateAsync(new NovoPacienteDTO()
            {
                Nome = nome,
                Sobrenome = sobrenome,
                DataNascimento = dataNascimento,
                Genero = genero,
                CPF = cpf,
                RG = rg,
                Estado = estado,
                Email = email,
                Celular = celular,
                TelefoneFixo = telefone,
                ConvenioId = convenio.Id,
                NumeroCarteirinha = numCarteirinha,
                ValidadeCarteirinha = validadeCarteirinha,
                Status = status
            });

    }
}
