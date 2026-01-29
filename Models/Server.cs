namespace LY_WebUI.Models
{
    public class Server
    {
        public Server()
        {
            Random rand = new Random();
            int randomId = rand.Next(0, 2);
            IsOnline = randomId == 1 ? true : false ;

        }

        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }

    }
}
