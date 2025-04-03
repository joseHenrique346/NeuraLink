namespace Arguments.Arguments.Registration.Consumer
{
    public class InputIdentityUpdateUser(long id, InputUpdateUser inputUpdateUser)
    {
        public long Id { get; set; } = id;
        public InputUpdateUser InputUpdateUser { get; set; } = inputUpdateUser;
    }
}