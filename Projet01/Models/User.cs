namespace Projet01.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public User()
        {
                
        }

        public User(string userName, string password, string fullName)
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
        }

        public User(string userString)
        {
            Deserialize(userString);
                
        }

        public string Serialize()
        {
            return $"{UserName}|{Password}|{FullName}";
        }

        public string SerializeForDb()
        {
            return $"INSERT INTO user(user_name, password, full_name) VALUES('{UserName}', '{Password}', '{FullName}')";
        }
        public void Deserialize(string value)
        {
            string[] tab = value?.Split('|');
        }
    }
}