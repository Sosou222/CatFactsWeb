namespace CatFactsWeb.Classes
{
    public class ConnectionClient
    {
        private HttpClient client;

        public ConnectionClient(HttpClient client)
        {
            this.client = client;
        }

        public bool TryGetRandomFact(out CatFact fact)
        {
            try
            {
                var response = client.GetAsync("fact").Result;
                response.EnsureSuccessStatusCode();
                fact = response.Content.ReadFromJsonAsync<CatFact>().Result!;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                fact = new CatFact()
                {
                    Fact = "Invalid",
                    Length = 0,
                };
                return false;
            }

            return true;
        }
    }
}
