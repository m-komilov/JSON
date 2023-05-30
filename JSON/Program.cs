using JSON;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
       string url = "https://my-json-server.typicode.com/typicode/demo/posts";

        HttpClient httpClient = new HttpClient();

        try
        {
            var httpResponseMessage = httpClient.GetAsync(url).Result;

            string jsonResponce = httpResponseMessage.Content.ReadAsStringAsync().Result;

            Console.WriteLine(jsonResponce);

            var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponce);

            //Console.WriteLine(myPosts);

            foreach (var post in myPosts)
            {
                Console.WriteLine($" ID: {post.Id},  Title: {post.Title} ");
            }

        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            httpClient.Dispose();
        }

    }
}
