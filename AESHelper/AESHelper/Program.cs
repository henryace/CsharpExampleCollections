// See https://aka.ms/new-console-template for more information
using AuthorizationHelper;

await StreamWriterTwo.ConnectStringAesEncrypt(@"name", @"connectionString");

internal class StreamWriterTwo
{
    public static async Task ConnectStringAesEncrypt(string name, string connectionString)
    {
        string _conn = AuthorizationHelper.AES.Encrypt(connectionString);
        //Console.WriteLine(_conn);
        //Console.WriteLine(AuthorizationHelper.AesDecrypt(_conn));

        var decryptString = AES.Decrypt(_conn);

        using StreamWriter file = new("WriteLines2.txt", append: true);
        await file.WriteLineAsync($"{name}");
        await file.WriteLineAsync($"{connectionString}");
        if (decryptString != connectionString)
        {
            await file.WriteLineAsync($"not same");
            throw new ArgumentException();
        }
        else
        {
            //Console.WriteLine("same");
            await file.WriteLineAsync($"{_conn}");

            await file.WriteLineAsync($"same");
        }

        await file.WriteLineAsync($"\n");
    }
}