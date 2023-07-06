namespace APIShredder;

public class Http
{
    private HttpClient client;
    private List<Task<HttpResponseMessage>> tasks = new();

    public Http(HttpClientHandler handler)
    {
        client = new HttpClient(handler);
    }

    private async void HandleRequests(int reqNum, string uri)
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

    public void DoWork(int numSock, int reqNum, string uri)
    {
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            Console.WriteLine(numSock + " Sockets, " + reqNum + " Requests");
            Console.WriteLine("Tasks are being performed...");
            HandleRequests(reqNum, uri);
            Console.WriteLine("Done.");
            Console.WriteLine("Again? (y/n):");
            while (Console.KeyAvailable)
                Console.ReadKey(false);
            keyInfo = Console.ReadKey();
        } while (keyInfo.KeyChar == 'y' || keyInfo.KeyChar == 'Y');
    }

}
