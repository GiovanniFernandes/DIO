using static System.Console;
public class Program{
    static int Adicionar20(int x){
        x += 20;
        return x;
    }
    static void Demo1(){
        int a = 2;
        a = Adicionar20(a);

        WriteLine($"O valor de a é {a}!");
    }

    static void TrocaNome(Pessoa p1, string nomeNovo){
        p1.Nome = nomeNovo;
    }
    static void Demo2(){
        Pessoa p1 = new Pessoa(){
        Nome = "Gi",
        Idade = 21,
        Documento = "123.456.789-10"
        };

        // Pessoa p2 = p1;
        // Pessoa p2 = new Pessoa();
        // p2.Nome = p1.Nome;
        // p2.Documento = p1.Documento;
        // p2.Idade = p1.Idade;

        Pessoa p2 = p1.Clone();

        TrocaNome(p1, "Mickey");

        WriteLine($@"
        O nome de p1 é {p1.Nome}
        O nome de p2 é {p2.Nome}
        "); // o @ permite dar enter dentro do texto e o enter tbm vai pro console
    }

    static void TrocaNome(StructPessoa p1, string nomeNovo){
        p1.Nome = nomeNovo;
    }
    static void Demo3(){
        StructPessoa p1 = new StructPessoa{
        Nome = "Gi",
        Idade = 21,
        Documento = "123.456.789-10"
        };

        // Pessoa p2 = p1;
        // Pessoa p2 = new Pessoa();
        // p2.Nome = p1.Nome;
        // p2.Documento = p1.Documento;
        // p2.Idade = p1.Idade;

        StructPessoa p2 = p1;

        TrocaNome(p1, "Mickey"); // struct é value type então o método não muda o valor dela

        WriteLine($@"
        O nome de p1 é {p1.Nome}
        O nome de p2 é {p2.Nome}
        "); // o @ permite dar enter dentro do texto e o enter tbm vai pro console
    }

    static void TrocaNome(string nome, string nomeNovo){
        nome = nomeNovo;
    }
    static void Demo4(){
        string nome = "Ricardo";
        TrocaNome(nome, "José"); // apesar de ser reference type, a string se comporta como value type
        WriteLine($"{nome}");
    }

    static void MudaParaImpar(int[] pares){
        for(int i=0; i < pares.Length; i++){
            pares[i] += 1;
        }
    }
    static void Demo5(){
        int[] pares = new int[]{0, 2, 4, 6, 8}; // ou simplesmente var pares = new int[]{0, 2, 4, 6, 8};

        MudaParaImpar(pares); // como o array é reference type, os valores são alterados
        WriteLine($"Os ímpares {string.Join(",", pares)}");
    }

    static int EncontrarNumero(int[] numeros, int num){
        for(int i=0; i < numeros.Length; i++){
            if(numeros[i] == num){
                return i;
            } 
        }
        return -1;
    }
    static void Demo6(){
        int[] numeros = new int[] {0,1,2,3,4,5,6,7,8,9};
        WriteLine("Digite o número que deseja achar: ");
        var num = int.Parse(ReadLine());
        var indice = EncontrarNumero(numeros, num);
        if(indice == -1){
            WriteLine("O número não foi encontrado.");
        } else WriteLine($"A posição do número é {indice}");
    }

    static Boolean EncontrarPessoa(List<Pessoa> pessoas, Pessoa pessoa){
        foreach(var item in pessoas){
            if(item.Nome == pessoa.Nome) return true; // Pessoa é reference value, então só será true quando item e pessoa apontarem para o mesmo lugar da heap, o que não acontece, se botar o .Nome funciona
        }
        return false;
    }
    static void Demo7(){
        List<Pessoa> pessoas = new List<Pessoa>(){
            new Pessoa(){Nome = "João"},
            new Pessoa(){Nome = "Marco"},
            new Pessoa(){Nome = "Gabi"},
            new Pessoa(){Nome = "Fafa"}
        };
        WriteLine("Digite a pessoa que quer encontrar: ");
        var nome = ReadLine();
        var pessoa = new Pessoa() {Nome = nome};
        var encontrado = EncontrarPessoa(pessoas, pessoa);
        if(encontrado) WriteLine("Pessoa se encontra na lista");
        else WriteLine("Pessoa não encontrada.");
    }

    static Boolean EncontrarPessoa(List<StructPessoa> pessoas, StructPessoa pessoa){
        foreach(var item in pessoas){
            if(item.Equals(pessoa)) return true; // Pessoa é reference value, então só será true quando item e pessoa apontarem para o mesmo lugar da heap, o que não acontece, se botar o .Nome funciona
        }
        return false;
    }
    public static void Main(){
        List<StructPessoa> pessoas = new List<StructPessoa>(){
            new StructPessoa(){Nome = "João"},
            new StructPessoa(){Nome = "Marco"},
            new StructPessoa(){Nome = "Gabi"},
            new StructPessoa(){Nome = "Fafa"}
        };
        WriteLine("Digite a pessoa que quer encontrar: ");
        var nome = ReadLine();
        var pessoa = new StructPessoa() {Nome = nome};
        var encontrado = EncontrarPessoa(pessoas, pessoa);
        if(encontrado) WriteLine("Pessoa se encontra na lista");
        else WriteLine("Pessoa não encontrada.");
    }
}