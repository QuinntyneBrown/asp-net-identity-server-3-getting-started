using AspNetIdentityServerGettingStarted.Data.Model;

namespace AspNetIdentityServerGettingStarted.Features.Scopes
{
    public class ScopeApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromScope<TModel>(Scope scope) where
            TModel : ScopeApiModel, new()
        {
            var model = new TModel();
            model.Id = scope.Id;
            return model;
        }

        public static ScopeApiModel FromScope(Scope scope)
            => FromScope<ScopeApiModel>(scope);

    }
}
