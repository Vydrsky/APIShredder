using System.Net;
using APIShredder;

Console.WriteLine("This software can load test any accessible API.");
Console.WriteLine("DISCLAIMER: Use only for testing purposes.");
Console.WriteLine("Press any key to continue...");
Console.ReadLine();

int numSock = Setup.GetIntegerData("Choose the number of sockets (possible concurrent slots for api calls):");
string auth = Setup.GetStringData("Please enter authentication cookie value:");
int reqNum = Setup.GetIntegerData("How many requests to perform? (in total):");

var cookieContainer = new CookieContainer();
cookieContainer.Add(new Uri("https://baconipsum.com/"), new Cookie("sanoweb_authentication",auth));

var handler = Setup.SetupHandler(cookieContainer, numSock);

Http http = new Http(handler);

Console.WriteLine(numSock + " Sockets, " + reqNum + " Requests");
Console.WriteLine("Tasks are being performed...");

http.HandleRequests(reqNum, "https://baconipsum.com/api/?type=meat-and-filler");
Console.WriteLine("Done.");