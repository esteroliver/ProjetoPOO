using System;
using System.Collections.Generic;

class Avaliacao{
    private int id{
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
    public void ToXml(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Avaliacao>));
        StreamWriter w = new StreamWriter("Avaliacao.xml");
        xml.Serialize(w, avaliacoes);
        w.Close();
    }
    public void FromXml(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Avaliacao>));
            StreamReader r = new StreamReader("Avaliacao.xml");
            avaliacoes = (List<Avaliacao>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
}