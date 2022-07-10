using Bogus;
using Bogus.Extensions.Brazil;
using LetsMarket.Enums;
using LetsMarket.Logic;

namespace LetsMarket.Db
{
    public static class ClientFaker
    {
        public static Faker<Client> Gerar()
        {
            Faker<Client> client = new Faker<Client>("pt_BR")
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.Document, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<ClientCategory>());

            return client;
        }
    }
}
