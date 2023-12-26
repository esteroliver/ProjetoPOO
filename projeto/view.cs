using System;
using System.Collections.Generic;

static class View{
    public static void AdicionarFilme(string nome, int id, string tipomidia){
        if(nome == " ") throw new ArgumentOutOfRangeException("Nome Inválido");
        if(id == 0) throw new ArgumentOutOfRangeException("Id inválido");
        if(tipomidia != "Filme" || tipomidia != "Serie" || tipomidia != "Livro") throw new ArgumentOutOfRangeException("Tipo Inválido");

        Filme f = new Filme{ Nome = nome, Id = id, Tipomidia = tipomidia};
        NFilme nf  = new NFilme();
        nf.Inserir(f);
    }
    public static List<Filme> ListarMidia(){
        Filme f = new Filme();
        return f.Listar();
    }
    public static List<Filme> ListarMidia(string tipomidia){
        NFilme nf = new NFilme();
        return nf.Listar(new NFilme{Tipo = tipomidia});
    }
    
}
