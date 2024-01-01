using System;
using System.Collections.Generic;

<<<<<<< HEAD
 static class View{
    public static bool CadastrarUser(string email, string username, string senha){
=======
static class View{
    public static void CriarAdm(){
        NUsuario usuarios = new NUsuario();
        Usuario adm = new Usuario{Senha = "IFRNtads2023"};
        usuarios.Inserir(adm);
    }
    public static bool CadastrarUser(string username, string senha){
>>>>>>> 4ab94b05a63769f6c6b59fe0a205bb765a28cd04
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
            if(u.Username == username) return false;
        }
        Usuario new_user = new Usuario{Username = username, Senha = senha};
        usuarios.Inserir(new_user);
        return true;
    }
    public static bool EntrarUser(string username, string senha){
        NUsuario usuarios = new NUsuario();
        List<Usuario> users = usuarios.Listar();
        foreach (Usuario u in users){
            if (u.Username == username && u.Senha == senha){
                return true;
            }
        }
        return false;
    }
    public static bool EntrarAdm(string senha){
        NUsuario usuarios = new NUsuario();
        Usuario u = usuarios.ObterId(1);
        //string s = "TADS2023.1"; // 1 é o id do usuário administrador
        if (u.Senha == senha) return true;
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
        NSerie series = new NSerie();
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
        foreach (Avaliacao a in avaliacoes.Listar()){
            if (a.Tipo == tipo && a.Id_midia == id){
                m++;
                n += a.Nota;
            }
        }
        return n/m;
    }
    //MÉTODOS EXCLUSIVOS PARA O ADMINISTRADOR
    public static void AdicionarMidia(string titulo, string descricao, string autor_diretor, int tipo){
        if(titulo == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(descricao == " ") throw new ArgumentOutOfRangeException("Descrição Inválida");
        if(autor_diretor == " ") throw new ArgumentOutOfRangeException("Autor/diretor Inválido");
        if(tipo > 3 || tipo < 0) throw new ArgumentOutOfRangeException("Tipo Inválido");
        if (tipo == 1){
            Filme f = new Filme{ Titulo = titulo, Descricao = descricao, Autor_diretor = autor_diretor, Tipo = tipo };
            NFilme filmes  = new NFilme();
            filmes.Inserir(f);
        }
        if (tipo == 2){
            Serie s = new Serie{ Titulo = titulo, Descricao = descricao, Autor_diretor = autor_diretor, Tipo = tipo };
            NSerie series = new NSerie();
            series.Inserir(s);
        }
        if (tipo == 3){
            Livro l = new Livro{ Titulo = titulo, Descricao = descricao, Autor_diretor = autor_diretor, Tipo = tipo };
            NLivro livros = new NLivro();
            livros.Inserir(l);
        }
        
    }
    public static void ExcluirMidia(int tipo, int id){
        if(tipo > 3 || tipo < 0) throw new ArgumentOutOfRangeException("Tipo Inválido");
        if (tipo == 1){
            NFilme filmes  = new NFilme();
            filmes.Excluir(id);
        }
        if (tipo == 2){
            NSerie series = new NSerie();
            series.Excluir(id);
        }
        if (tipo == 3){
            NLivro livros = new NLivro();
            livros.Excluir(id);
        }
    }
    //MÉTODOS PARA QUE OS USUÁRIOS CRIEM AS PRÓPRIAS LISTAS
}
