namespace animeWebApi.Models
{
    public class Characters
    {
        
        /* 

            Declaring the getters and setters to be use in the controler AnimeCharactes.cs

        */

        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string name { get; set; }

        public string description { get; set; }
        public decimal level { get; set; }
        public string primaryAttack { get; set; }
        public string secundaryAttack { get; set; }
        public string specialAttack { get; set; }

    }
}
