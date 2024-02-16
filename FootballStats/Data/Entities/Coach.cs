namespace FootballStats.Data.Entities
{
    public class Coach : Person
    {
        public string Licence { get; set; }
        public int YearsOfExperience { get; set; }
        public string FavoriteFormation { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Age} years old. Licence: {Licence} Exp: {YearsOfExperience} Fav form: {FavoriteFormation}";
        }
    }
}
