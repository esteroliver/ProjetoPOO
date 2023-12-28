using System;
using System.Collections.Generic;

static class View{
    public static void AdicionarFilme(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Filme") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Filme f = new Filme{ Nome = nome, Id = id, Tipo = tipomidia};
        NFilme nf  = new NFilme();
        nf.Inserir(f);
    }
    // public static List<Filme> ListarFilme(){
    //     Filme f = new Filme();
    //     return f.Listar();
    // }
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
    public static void ExcluirFilme(int id){
        Filme f = new Filme{Id = id};
        NFilme nf = new NFilme();
        nf.Excluir(f);
    }
    public static void ExcluirLivro(int id){
        Livro f = new Livro{Id = id};
        NLivro nf = new NLivro();
        nf.Excluir(f);
    }
    public static void ExcluirSerie(int id){
        Serie f = new Serie{Id = id};
        NSerie nf = new NSerie();
        nf.Excluir(f);
    }
    public static void AtualizarLivro(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Livro") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Livro l = new Livro{ Nome = nome, Id = id, Tipo = tipomidia};
        NLivro nl  = new NLivro();
        nl.Atualizar(l);
    }
    public static void AtualizarSerie(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Serie") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Serie s = new Serie{ Nome = nome, Id = id, Tipo = tipomidia};
        NSerie ns  = new NSerie();
        ns.Atualizar(s);
    }
    public static void AtualizarFilme(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Filme") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Filme f = new Filme{ Nome = nome, Id = id, Tipo = tipomidia};
        NFilme nf  = new NFilme();
        nf.Atualizar(f);
    }
    public static List<Filme> ListarFilme(string tipomidia){
        NFilme nf = new NFilme();
        return nf.Listar(new NFilme{Tipo = tipomidia});
    }
    public static List<Livro> ListarLivro(string tipomidia){
        NLivro nl = new NLivro();
        return nl.Listar(new NLivro{Tipo = tipomidia});
    }
    public static List<Serie> ListarSerie(string tipomidia){
        NSerie ns = new NSerie();
        return ns.Listar(new NSerie{Tipo = tipomidia});
    }
}
