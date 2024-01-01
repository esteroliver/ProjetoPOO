using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Usuario{
    private int id;
    private string username, senha;

    public int Id{
        get{ return id; }
        set{ id = value; }
    }
    public string Username{
        get{ return username; }
        set{ if(value != "") username = value; }
    }
    public string Senha{
        get{ return senha; }
        set{ if(value != "") senha = value; }
    }
    public override string ToString(){
        return $"{id} - {username}";
    }
}

public class NUsuario{
    public List<Usuario> users = new List<Usuario>();
    public void ToXML(){
        XmlSerializer xml =  new XmlSerializer(typeof(List<Usuario>));
        StreamWriter w = new StreamWriter("Usuario.xml");
        xml.Serialize(w, users);
        w.Close();
    }
    public void FromXML(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
            StreamReader r = new StreamReader("Usuario.xml");
            users = (List<Usuario>) xml.Deserialize(r);
            r.Close();
        }
        catch (FileNotFoundException){

        }
    }
    public void Inserir(Usuario us){
        FromXML();
        int id = 0;
        foreach (Usuario u in users){
            if (u.Id > id) id = u.Id;
        }
        us.Id = id + 1;
        users.Add(us);
        ToXML();
    }
    public List<Usuario> Listar(){
        FromXML();
        return users;
    }
    public Usuario ObterId(int id){
        FromXML();
        foreach (Usuario u in users){
            if (u.Id == id) return u;
        }
        return default(Usuario);
    }
    public void Atualizar(Usuario us){
        FromXML();
        Usuario us_sus = ObterId(us.Id);
        if (us_sus != null){
            users.Remove(us_sus);
            users.Add(us);
        }
        ToXML();
    }
    public void Excluir(int id){
        FromXML();
        Usuario us = ObterId(id);
        if(us != null) users.Remove(us);
        ToXML();
    }
}