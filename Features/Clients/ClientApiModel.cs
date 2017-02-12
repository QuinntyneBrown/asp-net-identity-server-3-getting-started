using AspNetIdentityServerGettingStarted.Data.Model;

namespace AspNetIdentityServerGettingStarted.Features.Clients
{
    public class ClientApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromClient<TModel>(Client client) where
            TModel : ClientApiModel, new()
        {
            var model = new TModel();
            model.Id = client.Id;
            return model;
        }

        public static ClientApiModel FromClient(Client client)
            => FromClient<ClientApiModel>(client);

    }
}
