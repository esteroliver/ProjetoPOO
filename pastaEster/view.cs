using System;
using System.Collections.Generic;

static class View{
    public bool CadastrarUser(string email, string username, string senha){
        if (username == ""){
            throw new ArgumentOutOfRangeException("Nome Inválido");
            return false;
        }
        if (senha == ""){
            throw new ArgumentOutOfRangeException("Senha Inválida");
            return false;
        }
        
        NUsuario usuarios = new NUsuario();
        foreach (Usuario u in usuarios.Listar()){
            if(u.username == username) return false;
        }
        Usuario new_user = new Usuario{username = username, senha = senha};
        usuarios.Inserir(new_user);
        return true;
    }
    public bool EntrarUser(string username, string senha){
        NUsuario usuarios = new NUsuario();
        List<Usuario> users = usuarios.Listar();
        foreach (Usuario u in users){
            if (u.username == username && u.senha == senha){
                return true;
            }
        }
        return false;
    }
    public void EntrarAdm(string senha){
        NUsuario usuarios = new NUsuario();
        Usuario u = usuarios.ObterId(1); // 1 é o id do usuário administrador
        if (u.senha == senha) return true;
        return false;
    }
    //listar mídia
    public static List<Filme> ListarFilmes(){
        NFilme filmes = new NFilme();
        return filmes.Listar();
    }

    public static List<Serie> ListarSeries(){
        NSerie series = new NSerie();
        return series.Listar();
    }
    public static List<Livro> ListarLivros(){
        NLivro livros = new NLivro();
        return livros.Listar();
    }
    //ver mídia
    public static Filme VerFilme(int id){
        NFilme filmes = new NFilme();
        return filmes.ObterId(id);
    }

    public static Serie VerSerie(int id){
        NSerie series = new NSeries();
        return series.ObterId(id);
    }

    public static Livro VerLivro(int id){
        NLivro livros = new NLivro();
        return livros.ObterId(id);
    }
    //MÉTODOS PARA AVALIAÇÃO
    public static void AvaliarMidia(int tipo, int id, int nota, string comentario){
        Avaliacao av = new Avaliacao();
        NAvaliacao avaliacoes = new NAvaliacao();
        av.Nota = nota;
        av.Comentario = comentario;
        avaliacoes.Inserir(id, tipo, av);
    }
    public static int NotaMidia(int tipo, int id){ //id e tipo da mídia
        NAvaliacao avaliacoes = new NAvaliacao();
        int m = 0;
        int n = 0;
        foreach (Avaliacao a in avaliacoes){
            if (a.Tipo == tipo && a.Id_midia == id){
                m++;
                n += a.Nota;
            }
        }
        return n/m;
    }
    //MÉTODOS EXCLUSIVOS PARA O ADMINISTRADOR
    public static void AdicionarFilme(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Filme") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Filme f = new Filme{ Nome = nome, Id = id, Tipo = tipomidia};
        NFilme nf  = new NFilme();
        nf.Inserir(f);
    }
    public static void AdicionarLivro(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Livro") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Livro l = new Livro{ Nome = nome, Id = id, Tipo = tipomidia};
        NLivro nl  = new NLivro();
        nl.Inserir(l);
    }
    public static void AdicionarSerie(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Serie") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Serie s = new Serie{ Nome = nome, Id = id, Tipo = tipomidia};
        NSerie ns  = new NSerie();
        ns.Inserir(s);
    }
}