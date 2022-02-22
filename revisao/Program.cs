// See https://aka.ms/new-console-template for more information
string opcaoSelecionada = ObterOpcao();

Aluno[] alunos = new Aluno[3];
int indiceAluno = 0;

while(opcaoSelecionada.ToUpper() != "X"){

    switch(opcaoSelecionada){

        case "1":
            Aluno aluno = new Aluno();
            Console.WriteLine("Informe o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Informe a nota do aluno: ");
            //var nota = decimal.Parse(Console.ReadLine());
            if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
            aluno.Nota = nota;
            } else{
                throw new ArgumentException("A nota precisa ser decimal.");
            }
            alunos[indiceAluno] = aluno;
            indiceAluno++;

            break;

        case "2":
            foreach(var a in alunos){
                if(!string.IsNullOrEmpty(a.Nome))
                    Console.WriteLine($"Aluno: {a.Nome}, Nota: {a.Nota}");
            }
            break;

        case "3":
            decimal soma = 0;
            for(int i=0; i < 3; i++){
                soma += alunos[i].Nota;
            }
            Console.WriteLine($"A média geral é {soma/3}");
            break;

        default:
            throw new ArgumentOutOfRangeException();
    }

    Console.WriteLine();
    opcaoSelecionada = ObterOpcao();
}

static string ObterOpcao(){
    Console.WriteLine("Informe a opção desejada: ");
    Console.WriteLine("1 - Inserir novo aluno");
    Console.WriteLine("2 - Listar alunos");
    Console.WriteLine("3 - Calcular média geral");
    Console.WriteLine("X - Sair");
    Console.WriteLine();

    string opcaoSelecionada = Console.ReadLine();
    return opcaoSelecionada;
}
