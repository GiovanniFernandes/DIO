public class Pessoa {
    public int Idade { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }

    public Pessoa Clone(){
        return new Pessoa(){
            Idade = this.Idade,
            Nome = this.Nome,
            Documento = this.Documento
        };
    }
}