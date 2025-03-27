using Newtonsoft.Json;

namespace Ambev.GestaoFuncionarios.UnitTest.Util
{
    public static class CreateObject
    {
        public static T? Create<T>()
        {
            return JsonConvert.DeserializeObject<T>("{\r\n  \"id\": \"0c3dffa2-30eb-4b08-97fc-ab2df0dafd14\",\r\n  \"nome\": \"Gustavo\",\r\n  \"sobrenome\": \"Antunes Barroso\",\r\n  \"documento\": \"4240888860\",\r\n  \"email\": \"ads.gustavo85@gmail.com\",\r\n  \"senha\": \"testeambev321\",\r\n  \"telefone\": \"11972880629\",\r\n  \"nomeGestor\": null,\r\n  \"dataNascimento\": \"1994-05-28\",\r\n  \"idGestor\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"isGestor\": false\r\n}");
        }

        public static T? CreateList<T>()
        {
            return JsonConvert.DeserializeObject<T>("[{\r\n  \"id\": \"0c3dffa2-30eb-4b08-97fc-ab2df0dafd14\",\r\n  \"nome\": \"Gustavo\",\r\n  \"sobrenome\": \"Antunes Barroso\",\r\n  \"documento\": \"4240888860\",\r\n  \"email\": \"ads.gustavo85@gmail.com\",\r\n  \"senha\": \"testeambev321\",\r\n  \"telefone\": \"11972880629\",\r\n  \"nomeGestor\": null,\r\n  \"dataNascimento\": \"1994-05-28\",\r\n  \"idGestor\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\r\n  \"isGestor\": false\r\n}]");
        }
    }
}
