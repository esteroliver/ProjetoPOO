using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class TipoMidia : IMidia{
    public int Id {get; set;}
    public string Tipo {get; set;}
    public override string ToString(){
        return $"{Id} - {Tipo}";
    }
}

class NTipoMidia : NMidia<TipoMidia>{
    public NTipoMidia() : base("TipoMidia.xml"){ }
}

class NTipoMidia2 {
    private List<TipoMidia> objetos = new List<TipoMidia>();
    public void ToXML(){
        XmlSerializer xml = new XmlSerializer(typeof(List<TipoMidia>));
        StreamWriter f = new StreamWriter("TipoMidia.xml");
        xml.Serialize(f, objetos);
        f.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<TipoMidia>));
            StreamReader f = new StreamReader("TipoMidia.xml");
            objetos = (List<TipoMidia>) xml.Deserialize(f);
            f.Close();
        }
        catch(FileNotFoundException) { }
    }
    public void Inserir(TipoMidia p){
        FromXML();
        int id = 0;
        foreach(TipoMidia obj in objetos)
            if(obj.Id > id) id = obj.Id;
        p.Id = id + 1;
        objetos.Add(p);
        ToXML();
    }
    public List<TipoMidia> Listar(){
        FromXML();
        return objetos;
    }
    public TipoMidia Listar(int id){
        FromXML();
        foreach(TipoMidia obj in objetos)
            if(obj.Id == id) return obj;
        return null;
    }
    public void Atualizar(TipoMidia p){
        FromXML();
        TipoMidia obj = Listar(p.Id);
        if(obj != null){
            objetos.Remove(obj);
            objetos.Add(p);
        }
        ToXML();
    }
    public void Excluir(TipoMidia p){
        FromXML();
        TipoMidia obj = Listar(p.Id);
        if(obj != null) objetos.Remove(obj);
        ToXML();
    }
}