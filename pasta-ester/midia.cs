using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Serialization;

namespace midias{

class Midia{
    private int id {
        get { return id; }
        set { id = value; }
    }
    private int tipo {
        get { return tipo; }
        set { if (value == 1 || value == 2 || value == 3) tipo = value; }
    }
    private string descricao {
        get { return descricao; }
        set { if (value != "") descricao = value; }
    }
    private string titulo {
        get { return titulo; }
        set { if (value != "") titulo = value; }
    }
    private string autor_diretor {
        get { return autor_diretor; }
        set { if (value != "") autor_diretor = value; }
    }
    public override string ToString(){
        return $"{id} - {titulo} - Tipo: {tipo}";
    }
}

class Filme : Midia{
    private DateTime duracao {
        get { return duracao; }
        set { duracao = value; }
    }
    public override string ToString(){
        return $"{id} - {titulo} - Duração: {duracao}";
    }
}

class Serie : Midia{
    private int temporadas {
        get { return temporadas; }
        set { if (value >= 1) temporadas = value; }
    }
    public override string ToString(){
         return $"{id} - {titulo} - Temporadas: {temporadas}";
    }
}

class Livro : Midia{
    private int paginas {
        get { return paginas; }
        set { if (value >= 1) paginas = value; }
    }
    public override string ToString(){
         return $"{id} - {titulo} - Páginas: {paginas}";
    }
}

class NFilme{
    private List<Filme> filmes = new List<Filme>();
    public void ToXml(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Filme>));
        StreamWriter w = new StreamWriter("Filme.xml");
        xml.Serialize(w, filmes);
        w.Close();
    }
    public void FromXml(){
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
            if(fil.id > id) id = fil.id;
        }
        f.id = id + 1;
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
            if(fil.id == id) return fil;
        }
        return default(Filme);
    }
    public void Atualizar(Filme f){
        FromXML();
        Filme fil = ObterId(f.id);
        if(fil != null){
            filmes.Remove(fil);
            filmes.Add(f);
        }
        ToXML();
    }
    public void Excluir(Filme f){
        FromXML();
        Filme fil = ObterId(f.id);
        if(fil != null) filmes.Remove(fil);
        ToXML();
    }
}

class NSerie{
    private List<Serie> series = new List<Serie>();
    public void ToXml(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Serie>));
        StreamWriter w = new StreamWriter("Serie.xml");
        xml.Serialize(w, series);
        w.Close();
    }
    public void FromXml(){
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
            if(fil.id > id) id = fil.id;
        }
        f.id = id + 1;
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
            if(fil.id == id) return fil;
        }
        return default(Serie);
    }
    public void Atualizar(Serie f){
        FromXML();
        Serie fil = ObterId(f.id);
        if(fil != null){
            series.Remove(fil);
            series.Add(f);
        }
        ToXML();
    }
    public void Excluir(Serie f){
        FromXML();
        Serie fil = ObterId(f.id);
        if(fil != null) series.Remove(fil);
        ToXML();
    }
}

class NLivro{
    private List<Livro> livros = new List<Livro>();
    public void ToXml(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Livro>));
        StreamWriter w = new StreamWriter("Livro.xml");
        xml.Serialize(w, livros);
        w.Close();
    }
    public void FromXml(){
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
            if(fil.id > id) id = fil.id;
        }
        f.id = id + 1;
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
            if(fil.id == id) return fil;
        }
        return default(Livro);
    }
    public void Atualizar(Livro f){
        FromXML();
        Livro fil = ObterId(f.id);
        if(fil != null){
            livros.Remove(fil);
            livros.Add(f);
        }
        ToXML();
    }
    public void Excluir(Livro f){
        FromXML();
        Livro fil = ObterId(f.id);
        if(fil != null) livros.Remove(fil);
        ToXML();
    }
}

}