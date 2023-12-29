using System;
using System.Collections.Generic;

class Avaliacao{
    private int id_midia{
        get { return id; }
        set { id = value; }
    }
    private int id_av{
        get { return id; }
        set { id = value; }
    }
    private int nota{
        get { return nota; }
        set { if (value >= 0 && value <= 10) nota = value; }
    }
    private string comentario{
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
        av.id_midia = id;
        int obj_id = 0;
        foreach (Avaliacao a in avaliacoes){
            if (a.id > obj_id) obj_id = a.id;
        }
        av.id_av = obj_id + 1; //além do id da mídia, cada avaliação terá seu próprio id
        avaliacoes.Add(av);
        ToXML();
    }
    public List<Avaliacao> ListarAvaliacoes(int id){ //irá listar as avaliações de uma mídia com determinado id
        FromXML();
        List<Avaliacao> avs = new List<Avaliacao>();
        foreach (Avaliacao a in avaliacoes){
            if (a.id_midia == id) avs.Add(a);
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
            if (a.id_av == id_av) return a;
        }
        return default(Avaliacao);
    }
    public void Atualizar(Avaliacao av){
        FromXML();
        Avaliacao a = ObterId(av.id_av);
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