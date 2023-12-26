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

class NFilme2 {
    private List<Filme> filmes = new List<Filme>();
    public void ToXML(){
        XmlSerializer xml = new XmlSerializer(typeof(List<Filme>));
        StreamWriter f = new StreamWriter("Filme.xml");
        xml.Serialize(f, filmes);
        f.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Filme>));
            StreamReader f = new StreamReader("Filme.xml");
            filmes = (List<Filme>) xml.Deserialize(f);
            f.Close();
        }
        catch(FileNotFoundException) { }
    }
    public void Inserir(Filme f){
        FromXML();
        int id = 0;
        foreach(Filme obj in filmes)
            if(obj.Id > id) id = obj.Id;
        f.Id = id +1;
        filmes.Add(f);
        ToXML();
    }
    public List<Filme> Listar(){
        FromXML();
        return filmes;
    }
    public List<Filme> Listar(int id){
        FromXML();
        foreach(Filme obj in filmes)
            if(obj.Id == id) return obj;
        return null;
    }
    public void Atualizar(Filme f){
        FromXML();
        Filme obj = Listar(f.Id);
        if(obj != null){
            filmes.Remove(obj);
            filmes.Add(f);
        }
        ToXML();
    }
    public void Excluir(Filme f){
        FromXML();
        Filme obj = Listar(f.Id);
        if(obj != null) filmes.Remove(obj);
        ToXML();
    }
}
class NLivro2 {
    private List<Livro> livros = new List<Livro>();
    public void ToXML(){
        XmlSerializer xml = new XmlSerializer(typeof(List<Livro>));
        StreamWriter f = new StreamWriter("Livro.xml");
        xml.Serialize(f, livros);
        f.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Livro>));
            StreamReader f = new StreamReader("Livro.xml");
            livros = (List<Livro>) xml.Deserialize(f);
            f.Close();
        }
        catch(FileNotFoundException) { }
    }
    public void Inserir(Livro l){
        FromXML();
        int id = 0;
        foreach(Livro obj in livros)
            if(obj.Id > id) id = obj.Id;
        l.Id = id +1;
        livros.Add(l);
        ToXML();
    }
    public List<Livro> Listar(){
        FromXML();
        return livros;
    }
    public List<Livro> Listar(int id){
        FromXML();
        foreach(Livro obj in livros)
            if(obj.Id == id) return obj;
        return null;
    }
    public void Atualizar(Livro l){
        FromXML();
        Livro obj = Listar(l.Id);
        if(obj != null){
            livros.Remove(obj);
            livros.Add(l);
        }
        ToXML();
    }
    public void Excluir(Livro l){
        FromXML();
        Livro obj = Listar(l.Id);
        if(obj != null) livros.Remove(obj);
        ToXML();
    }
}
class NSerie2 {
    private List<Serie> series = new List<Serie>();
    public void ToXML(){
        XmlSerializer xml = new XmlSerializer(typeof(List<Serie>));
        StreamWriter f = new StreamWriter("Serie.xml");
        xml.Serialize(f, series);
        f.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Serie>));
            StreamReader f = new StreamReader("Serie.xml");
            series = (List<Serie>) xml.Deserialize(f);
            f.Close();
        }
        catch(FileNotFoundException) { }
    }
    public void Inserir(Serie s){
        FromXML();
        int id = 0;
        foreach(Serie obj in series)
            if(obj.Id > id) id = obj.Id;
        s.Id = id +1;
        series.Add(s);
        ToXML();
    }
    public List<Serie> Listar(){
        FromXML();
        return series;
    }
    public List<Serie> Listar(int id){
        FromXML();
        foreach(Serie obj in series)
            if(obj.Id == id) return obj;
        return null;
    }
    public void Atualizar(Serie s){
        FromXML();
        Serie obj = Listar(s.Id);
        if(obj != null){
            series.Remove(obj);
            series.Add(s);
        }
        ToXML();
    }
    public void Excluir(Serie s){
        FromXML();
        Serie obj = Listar(s.Id);
        if(obj != null) series.Remove(obj);
        ToXML();
    }
}