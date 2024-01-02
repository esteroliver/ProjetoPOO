using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Lista{
    private int id_lista, id_midia, tipo;

    public int Id_lista{
        get { return id_lista; }
        set { id_lista = value; }
    }

    public int Id_midia{
        get { return id_midia; }
        set { id_midia = value; }
    }

    public int Tipo{
        get { return tipo; }
        set { tipo = value; }
    }
    public override string ToString(){
        return $"{Id_lista} - {Id_midia} - {Tipo}";
    }
}

class NLista{
    private List<Lista> listas = new List<Lista>();
    public ToXML(){
         XmlSerializer xml =  new XmlSerializer(typeof(List<Lista>));
        StreamWriter w = new StreamWriter("Lista.xml");
        xml.Serialize(w, listas);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Lista>));
            StreamReader r = new StreamReader("Lista.xml");
            listas = (List<Avaliacao>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
    public void Inserir(int id, int tipo, Lista l){
        FromXML();
        l.Id_midia = id;
        l.Tipo = tipo;
        // existirão várias mídias, mas só haverá 3 tipos de mídias
        // o objetivo é listar as mídias de acordo com o tipo
        int obj_id = 0;
        foreach (Lista li in listas){
            if(li.Id_lista > obj_id) obj_id = li.Id_lista;
        }
        l.Id_lista = obj_id + 1;
        listas.Add(l);
        ToXML();
    }
    public List<Filme> ListaFilmes(){
        FromXML();
        List<Filme> lista = new List<Filme>();
        foreach (Lista a in listas){
            if (a.Tipo == 1) lista.Add(a);
        }
        return lista;
    }
    public List<Serie> ListaSeries(){
        FromXML();
        List<Serie> lista = new List<Serie>();
        foreach (Lista a in listas){
            if (a.Tipo == 2) lista.Add(a);
        }
        return lista;
    }
    public List<Livro> ListaLivros(){
        FromXML();
        List<Livro> lista = new List<Livro>();
        foreach (Lista a in listas){
            if (a.Tipo == 3) lista.Add(a);
        }
        return lista;
    }
    public Lista ObterMidia(int id_midia, int tipo){
        FromXML();
        foreach(Lista l in listas){
            if (l.Tipo == tipo && l.Id_midia == id) return l;
        }
        return default(Lista);
    }
    public void Ataulizar(Lista l){
        FromXML();
        Lista la = ObterMidia(l.Id_midia, l.Tipo);
        if (la != null){
            listas.Remove(la);
            listas.Add(l);
        }
        ToXML();
    }
    public void Excluir(int tipo, int id_midia){
        FromXML();
        Lista f = ObterMidia(id_midia, tipo);
        if (f != null) listas.Remove(f);
        ToXML();
    }
}