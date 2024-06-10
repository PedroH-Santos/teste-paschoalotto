using System.Text.Json.Serialization;

namespace ApiTestePaschoalotto.Models
{
    public class UserAllResponseModel
    {
        [JsonPropertyName("results")]
        public List<UserResponseModel> Results { get; set; }



    }
    public class InfoUserResponseModel
    {
        [JsonPropertyName("seed")]
        public  string  Seed { get; set; }
        [JsonPropertyName("results")]
        public int Results { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }




    }
    public class UserResponseModel
    {
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("name")]
        public NameUserResponseModel Name { get; set; }
        [JsonPropertyName("location")]
        public LocationUserResponseModel Location { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("login")]
        public LoginUserResponseModel Login { get; set; }
        [JsonPropertyName("dob")]
        public DobUserResponseModel Dob { get; set; }
        [JsonPropertyName("registered")]
        public RegisteredUserResponseModel Registered { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("cell")]
        public string Cell { get; set; }
        [JsonPropertyName("id")]
        public IdUserResponseModel Id { get; set; }
        [JsonPropertyName("picture")]
        public PictureUserResponseModel Picture { get; set; }
        [JsonPropertyName("nat")]
        public string Nat { get; set; }


    }

    public class NameUserResponseModel
    {
        [JsonPropertyName("title")]

        public string Title { get; set; }
        [JsonPropertyName("first")]

        public string First { get; set; }
        [JsonPropertyName("last")]

        public string Last { get; set; }
    }

    public class LocationUserResponseModel
    {
        [JsonPropertyName("street")]

        public StreetUserResponseModel Street { get; set; }

        [JsonPropertyName("city")]

        public string City { get; set; }
        [JsonPropertyName("state")]

        public string State { get; set; }
        [JsonPropertyName("country")]

        public string Country { get; set; }
        [JsonPropertyName("postcode")]

        public dynamic Postcode { get; set; }
        [JsonPropertyName("coordinates")]

        public CoordinatesUserResponseModel coordinates { get; set; }
        [JsonPropertyName("timezone")]

        public TimeZoneUserResponseModel Timezone { get; set; }


    }
    public class StreetUserResponseModel
    {
        [JsonPropertyName("number")]

        public int Number{ get; set; }
        [JsonPropertyName("name")]

        public string Name { get; set; }
    }
    public class CoordinatesUserResponseModel
    {
        [JsonPropertyName("latitude")]

        public string Latitude { get; set; }
        [JsonPropertyName("longitude")]

        public string Longitude { get; set; }
    }
    public class TimeZoneUserResponseModel
    {
        [JsonPropertyName("offset")]

        public string OffSet { get; set; }
        [JsonPropertyName("description")]

        public string Description { get; set; }
    }
    public class LoginUserResponseModel
    {
        [JsonPropertyName("uuid")]

        public string UUID { get; set; }
        [JsonPropertyName("username")]

        public string Username { get; set; }
        [JsonPropertyName("password")]

        public string Password { get; set; }
        [JsonPropertyName("salt")]

        public string Salt { get; set; }
        [JsonPropertyName("md5")]

        public string Md5 { get; set; }
        [JsonPropertyName("sha1")]

        public string Sha1 { get; set; }
        [JsonPropertyName("sha256")]

        public string Sha256 { get; set; }
    }
    public class DobUserResponseModel
    {
        [JsonPropertyName("date")]

        public string Date { get; set; }
        [JsonPropertyName("age")]

        public int Age { get; set; }
      

    }
    public class RegisteredUserResponseModel
    {
        [JsonPropertyName("date")]

        public string Date { get; set; }
        [JsonPropertyName("age")]

        public int Age { get; set; }


    }
    public class IdUserResponseModel
    {
        [JsonPropertyName("name")]

        public string Name { get; set; }
        [JsonPropertyName("value")]

        public string Value { get; set; }


    }
    public class PictureUserResponseModel
    {
        [JsonPropertyName("large")]

        public string Large { get; set; }
        [JsonPropertyName("medium")]

        public string Medium { get; set; }
        [JsonPropertyName("thumbnail")]

        public string Thumbnail { get; set; }


    }
}
