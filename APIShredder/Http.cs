namespace APIShredder;

public class Http
{
    private HttpClient client;
    private List<Task<HttpResponseMessage>> tasks = new();

    public Http(HttpClientHandler handler)
    {
        client = new HttpClient(handler);
    }

    private async Task HandleRequests(int reqNum, string uri)
    {
        try
        {

            for (int i = 0; i < reqNum; i++)
            {
                tasks.Add(client.GetAsync(uri));
            }
            await Task.WhenAll(tasks);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public async Task DoWork(int numSock, int reqNum, string uri)
    {
        await HandleRequests(reqNum, uri);
        tasks.Clear();
    }
}
