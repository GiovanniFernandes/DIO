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
    static void Demo2(){
        var nomes = new string[]{"José", "Maria", "Ricardo", "Alice", "Pedro"};
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        WriteLine("Qual nome você quer mudar? ");
        var nome = ReadLine();
        WriteLine("Para qual nome você quer mudar? ");
        var nomeNovo = ReadLine();
        AlterarNome(nomes, nome, nomeNovo);
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
    }

    static int LocalizaNome(string[] nomes, string nome){
        for(int i=0; i < nomes.Length; i++){
            if(nomes[i] == nome) return i;
        }
        return -1;
    }
    static void Demo3(){
        var nomes = new string[]{"José", "Maria", "Ricardo", "Alice", "Pedro"};
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        WriteLine("Qual nome você quer mudar? ");
        var nome = ReadLine();

        var indice = LocalizaNome(nomes, nome);
        if(indice == -1) WriteLine("Nome não se encontra na lista");
        else{
            WriteLine("Para qual nome você quer mudar? ");
            var nomeNovo = ReadLine();
            nomes[indice] = nomeNovo;
            WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        }
    }

    static ref string LocalizaNome_com_ref(string[] nomes, string nome){
        for(int i=0; i < nomes.Length; i++){
            if(nomes[i] == nome) return ref nomes[i];
        }
        throw new Exception("Nome não encontrado");
    }
    static void Main(){
        var nomes = new string[]{"José", "Maria", "Ricardo", "Alice", "Pedro"};
        WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        WriteLine("Qual nome você quer mudar? ");
        var nome = ReadLine();

        ref var nomeAchado = ref LocalizaNome_com_ref(nomes, nome);
        if(string.IsNullOrWhiteSpace(nomeAchado)) WriteLine("Nome não se encontra na lista");
        else{
            WriteLine("Para qual nome você quer mudar? ");
            var nomeNovo = ReadLine();
            nomeAchado = nomeNovo;
            WriteLine($"Lista de nomes: {string.Join(", \n", nomes)}");
        }
    }
}