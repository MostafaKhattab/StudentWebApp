namespace StudentWebApp.UserTemplate
{
    public class User
    {
        public string Email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string usertype { get; set; }
        public int userId { get; set; }


        public User() { }
        public User(string email, string password, string username, string usertype, int userId)
        {
            this.Email = email;
            this.password = password;
            this.username = username;
            this.usertype = usertype;
            this.userId = userId;
        }


    }
}
