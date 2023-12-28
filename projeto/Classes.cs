using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Serialization;

public class Filme : IMidia{
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Tipo{get; set;}
    public override string ToString(){
        return $"{Id} - {Nome} - Tipo: {Tipo}";
    }
}
public class Livro : IMidia{
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Tipo {get; set;}
    public override string ToString(){
        return $"{Id} - {Nome} - Tipo: {Tipo}"; 
    }
}
public class Serie : IMidia{
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Tipo{get; set;}
    public override string ToString(){
        return $"{Id} - {Nome} - Tipo: {Tipo}";
    }
}
public class NFilme : NMidia<Filme>{
    public NFilme() : base("Filme.xml"){ }
    public List<Filme> Listar(TipoMidia m){
        List<Filme> filmes = new List<Filme>();
        foreach(Filme obj in Listar())
            if(obj.Tipo == m.Tipo) filmes.Add(obj);
        return filmes;        
    }
}
public class NLivro : NMidia<Livro>{
    public NLivro() : base("Livro.xml"){ }
    public List<Livro> Listar(TipoMidia m){
        List<Livro> livros = new List<Livro>();
        foreach(Livro obj in Listar())
            if(obj.Tipo == m.Tipo) livros.Add(obj);
        return livros;
    }
}
public class NSerie : NMidia<Serie>{
    public NSerie() : base("Serie.xml"){ }
    public List<Serie> Listar(TipoMidia m){
        List<Serie> series = new List<Serie>();
        foreach(Serie obj in Listar())
            if(obj.Tipo == m.Tipo) series.Add(obj);
        return series;
    }
}