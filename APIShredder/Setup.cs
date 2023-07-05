using System.Net;

namespace APIShredder;


public static class Setup {
    public static int GetIntegerData(string userPrompt) {
        int sockNum;
        do {
            Console.Clear();
            Console.WriteLine(userPrompt);
            int.TryParse(Console.ReadLine(),out sockNum);
        } while (sockNum <= 0);
        return sockNum;
    }

    public static string GetStringData(string userPrompt) {
        string auth;
        do {
            Console.Clear();
            Console.WriteLine(userPrompt);
            auth = Console.ReadLine();
        } while (string.IsNullOrEmpty(auth));
        return auth;
    }

    public static HttpClientHandler SetupHandler(CookieContainer cookieContainer, int numSock) {
        HttpClientHandler handler = new HttpClientHandler() {
            CookieContainer = cookieContainer,
            MaxConnectionsPerServer = numSock
        };
        return handler;
    }
}
