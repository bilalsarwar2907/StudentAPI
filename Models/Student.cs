using System.Text.Json.Serialization;

namespace StudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("yearOfBirth")]
        public int YearOfBirth { get; set; }


   
        public override string ToString()
        {
            return $"Student Id: {Id}, Name: {Name}, Born in : {YearOfBirth}";
        }



  
    }
}
