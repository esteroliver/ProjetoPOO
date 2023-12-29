using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Serialization;
using System.IO;

class Midia{
    private int id, tipo;
    private string descricao, titulo, autor_diretor;
    public int Id {
        get { return id; }
        set { id = value; }
    }
    public int Tipo {
        get { return tipo; }
        set { if (value == 1 || value == 2 || value == 3) tipo = value; }
    }
    public string Descricao {
        get { return descricao; }
        set { if (value != "") descricao = value; }
    }
    public string Titulo {
        get { return titulo; }
        set { if (value != "") titulo = value; }
    }
    public string Autor_diretor {
        get { return autor_diretor; }
        set { if (value != "") autor_diretor = value; }
    }
    public override string ToString(){
        return $"{Id} - {Titulo} - Tipo: {Tipo}";
    }
}

class Filme : Midia{
    private DateTime duracao;
    public DateTime Duracao {
        get { return duracao; }
        set { duracao = value; }
    }
    public override string ToString(){
        return $"{Id} - {Titulo} - Duração: {Duracao}";
    }
}

class Serie : Midia{
    private int temporadas;
    public int Temporadas {
        get { return temporadas; }
        set { if (value >= 1) temporadas = value; }
    }
    public override string ToString(){
         return $"{Id} - {Titulo} - Temporadas: {Temporadas}";
    }
}

class Livro : Midia{
    private int paginas;
    public int Paginas {
        get { return paginas; }
        set { if (value >= 1) paginas = value; }
    }
    public override string ToString(){
         return $"{Id} - {Titulo} - Páginas: {Paginas}";
    }
}

class NFilme{
    private List<Filme> filmes = new List<Filme>();
    public void ToXML(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Filme>));
        StreamWriter w = new StreamWriter("Filme.xml");
        xml.Serialize(w, filmes);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Filme>));
            StreamReader r = new StreamReader("Filme.xml");
            filmes = (List<Filme>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
    public void Inserir(Filme f){
        FromXML();
        int id = 0;
        foreach (Filme fil in filmes){
            if(fil.Id > id) id = fil.Id;
        }
        f.Id = id + 1;
        filmes.Add(f);
        ToXML();
    }
    public List<Filme> Listar(){
        FromXML();
        return filmes;
    }
    public Filme ObterId(int id){
        FromXML();
        foreach (Filme fil in filmes){
            if(fil.Id == id) return fil;
        }
        return default(Filme);
    }
    public void Atualizar(Filme f){
        FromXML();
        Filme fil = ObterId(f.Id);
        if(fil != null){
            filmes.Remove(fil);
            filmes.Add(f);
        }
        ToXML();
    }
    public void Excluir(Filme f){
        FromXML();
        Filme fil = ObterId(f.Id);
        if(fil != null) filmes.Remove(fil);
        ToXML();
    }
}

class NSerie{
    private List<Serie> series = new List<Serie>();
    public void ToXML(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Serie>));
        StreamWriter w = new StreamWriter("Serie.xml");
        xml.Serialize(w, series);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Serie>));
            StreamReader r = new StreamReader("Serie.xml");
            series = (List<Serie>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
     public void Inserir(Serie f){
        FromXML();
        int id = 0;
        foreach (Serie fil in series){
            if(fil.Id > id) id = fil.Id;
        }
        f.Id = id + 1;
        series.Add(f);
        ToXML();
    }
    public List<Serie> Listar(){
        FromXML();
        return series;
    }
    public Serie ObterId(int id){
        FromXML();
        foreach (Serie fil in series){
            if(fil.Id == id) return fil;
        }
        return default(Serie);
    }
    public void Atualizar(Serie f){
        FromXML();
        Serie fil = ObterId(f.Id);
        if(fil != null){
            series.Remove(fil);
            series.Add(f);
        }
        ToXML();
    }
    public void Excluir(Serie f){
        FromXML();
        Serie fil = ObterId(f.Id);
        if(fil != null) series.Remove(fil);
        ToXML();
    }
}

class NLivro{
    private List<Livro> livros = new List<Livro>();
    public void ToXML(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Livro>));
        StreamWriter w = new StreamWriter("Livro.xml");
        xml.Serialize(w, livros);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Livro>));
            StreamReader r = new StreamReader("Livro.xml");
            livros = (List<Livro>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
     public void Inserir(Livro f){
        FromXML();
        int id = 0;
        foreach (Livro fil in livros){
            if(fil.Id > id) id = fil.Id;
        }
        f.Id = id + 1;
        livros.Add(f);
        ToXML();
    }
    public List<Livro> Listar(){
        FromXML();
        return livros;
    }
    public Livro ObterId(int id){
        FromXML();
        foreach (Livro fil in livros){
            if(fil.Id == id) return fil;
        }
        return default(Livro);
    }
    public void Atualizar(Livro f){
        FromXML();
        Livro fil = ObterId(f.Id);
        if(fil != null){
            livros.Remove(fil);
            livros.Add(f);
        }
        ToXML();
    }
    public void Excluir(Livro f){
        FromXML();
        Livro fil = ObterId(f.Id);
        if(fil != null) livros.Remove(fil);
        ToXML();
    }
}
