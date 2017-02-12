using AspNetIdentityServerGettingStarted.Data.Model;

namespace AspNetIdentityServerGettingStarted.Features.Users
{
    public class UserApiModel
    {        
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }

        public static TModel FromUser<TModel>(User user) where
            TModel : UserApiModel, new()
        {
            var model = new TModel();
            model.Id = user.Id;
            return model;
        }

        public static UserApiModel FromUser(User user)
            => FromUser<UserApiModel>(user);

    }
}
