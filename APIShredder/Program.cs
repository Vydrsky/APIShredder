using System.Net;
using APIShredder;

Console.WriteLine("This software can load test any accessible API.");
Console.WriteLine("DISCLAIMER: Use only for testing purposes.");
Console.WriteLine("Press any key to continue...");
Console.ReadLine();

int numSock = Setup.GetIntegerData("Choose the number of sockets (possible slots for concurrent api calls):");
string uri = Setup.GetStringData("Please enter API Uri:");
string cookieName = Setup.GetStringData("Please enter authentication cookie NAME:");
string cookieValue = Setup.GetStringData("Please enter authentication cookie VALUE:");
int reqNum = Setup.GetIntegerData("How many requests to perform? (in total):");

var cookieContainer = new CookieContainer();
cookieContainer.Add(new Uri(uri), new Cookie(cookieName, cookieValue));

var handler = Setup.SetupHandler(cookieContainer, numSock);

Http http = new Http(handler);

ConsoleKeyInfo keyInfo;
do
{
    Console.Clear();
    Console.WriteLine(numSock + " Sockets, " + reqNum + " Requests");
    Console.WriteLine("Tasks are being performed...");

    await http.DoWork(numSock, reqNum, uri);

    Console.WriteLine("Done.");
    Console.WriteLine("Again? (y/n):");
    while (Console.KeyAvailable)
        Console.ReadKey(false);
    keyInfo = Console.ReadKey();
} while (keyInfo.KeyChar == 'y' || keyInfo.KeyChar == 'Y');