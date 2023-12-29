using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

class Avaliacao{
    private int id_midia, id_av, nota;
    private string comentario;

    public int Id_midia{
        get { return id_midia; }
        set { id_midia = value; }
    }
    public int Id_av{
        get { return id_av; }
        set { id_av = value; }
    }
    public int Nota{
        get { return nota; }
        set { if (value >= 0 && value <= 10) nota = value; }
    }
    public string Comentario{
        get { return comentario; }
        set { comentario = value; }
    }
    public override string ToString(){
        return $"{nota} - {comentario}";
    }
}


class NAvaliacao{
    private List<Avaliacao> avaliacoes = new List<Avaliacao>();
    public void ToXML(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Avaliacao>));
        StreamWriter w = new StreamWriter("Avaliacao.xml");
        xml.Serialize(w, avaliacoes);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Avaliacao>));
            StreamReader r = new StreamReader("Avaliacao.xml");
            avaliacoes = (List<Avaliacao>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
    public void Inserir(int id, Avaliacao av){ //id da mídia que está sendo avaliada
        FromXML();
        av.Id_midia = id;
        int obj_id = 0;
        foreach (Avaliacao a in avaliacoes){
            if (a.Id_av > obj_id) obj_id = a.Id_av;
        }
        av.Id_av = obj_id + 1; //além do id da mídia, cada avaliação terá seu próprio id
        avaliacoes.Add(av);
        ToXML();
    }
    public List<Avaliacao> ListarAvaliacoes(int id){ //irá listar as avaliações de uma mídia com determinado id
        FromXML();
        List<Avaliacao> avs = new List<Avaliacao>();
        foreach (Avaliacao a in avaliacoes){
            if (a.Id_midia == id) avs.Add(a);
        }
        return avs;
    }
    public List<Avaliacao> Listar(){ //irá listar todas as avaliações
        FromXML();
        return avaliacoes;
    }
    public Avaliacao ObterId(int id_av){
        FromXML();
        foreach (Avaliacao a in avaliacoes){
            if (a.Id_av == id_av) return a;
        }
        return default(Avaliacao);
    }
    public void Atualizar(Avaliacao av){
        FromXML();
        Avaliacao a = ObterId(av.Id_av);
        if (a != null){
            avaliacoes.Remove(a);
            avaliacoes.Add(av);
        }
        ToXML();
    }
    public void Excluir(int id_av){
        FromXML();
        Avaliacao a = ObterId(id_av);
        if (a != null) avaliacoes.Remove(a);
        ToXML();
    }
}