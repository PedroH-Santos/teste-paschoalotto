using System.Text.Json.Serialization;

namespace ApiTestePaschoalotto.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime DobDate { get; set; }
        public string Phone { get; set; }
        public string Cell {  get; set; }
        public string Image { get; set; }

        public AddressModel Address { get; set; }

        public string Nat { get; set; }
    }
}
