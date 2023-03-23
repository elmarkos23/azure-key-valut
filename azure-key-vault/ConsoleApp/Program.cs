using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace ConsoleApp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //Para utilizar el servicio se debe tener instalado azure cli

        //ejecutar el comando:
        //az login


        var client = new SecretClient(vaultUri: new Uri("https://kv-prueba-key.vault.azure.net/"),
          credential: new DefaultAzureCredential());
        //insert
        //KeyVaultSecret secret = client.SetSecret("akv-insert", "Hello World!");

        //get
        KeyVaultSecret secret2 = client.GetSecret("akv-connectionString");


        //update
        //KeyVaultSecret secret3 = client.GetSecret("akv-insert");
        //secret3.Properties.ContentType = "text/plain";
        //SecretProperties secretProperties = client.UpdateSecretProperties(secret3.Properties);

        ////delete
        //DeleteSecretOperation operation = client.StartDeleteSecret("akv-insert");
        //DeletedSecret deleted = operation.Value;

        Console.WriteLine(secret2.Value);
      }
      catch (Exception ex)
      {
        if(ex.Message.Contains("authentication failed"))
          Console.WriteLine("Error de authentication - Login account");
        else
          Console.WriteLine(ex.Message);
      }

    }
  }
}
