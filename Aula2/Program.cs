using static System.Console;

class Aula2{

    static void Adiciona20(ref int a){
        a += 20;
    }
    static void Demo1(){
        int a = 5;
        Adiciona20(ref a);
        WriteLine($"O valor de a é {a}");
    }

    static void AlterarNome(string[] nomes, string nome, string nomeNovo){
        for(int i=0; i < nomes.Length; i++){
            if(nomes[i] == nome){
                nomes[i] = nomeNovo;
            }
        }
    }
    static void Main(){
        var nomes = new string[]{"José", "Maria", "Ricardo", "Alice", "Pedro"};
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        WriteLine("Qual nome você quer mudar? ");
        var nome = ReadLine();
        WriteLine("Para qual nome você quer mudar? ");
        var nomeNovo = ReadLine();
        AlterarNome(nomes, nome, nomeNovo);
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
    }
}