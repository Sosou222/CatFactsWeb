namespace CatFactsWeb.Classes
{
    public class CatFact
    {
        public required string Fact { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Fact:{Fact} Length:{Length}";
        }
    }
}
