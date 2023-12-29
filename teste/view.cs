using System;
using System.Collections.Generic;

static class View{
    public static bool CadastrarUser(string email, string username, string senha){
        if (username == ""){
            throw new ArgumentOutOfRangeException("Nome Inválido");
            return false;
        }
        if (senha == ""){
            throw new ArgumentOutOfRangeException("Senha Inválida");
            return false;
        }
        
        NUsuario usuarios = new NUsuario();
        foreach (Usuario u in usuarios.Listar()){
            if(u.Username == username) return false;
        }
        Usuario new_user = new Usuario{Username = username, Senha = senha};
        usuarios.Inserir(new_user);
        return true;
    }
    public static bool EntrarUser(string username, string senha){
        NUsuario usuarios = new NUsuario();
        List<Usuario> users = usuarios.Listar();
        foreach (Usuario u in users){
            if (u.Username == username && u.Senha == senha){
                return true;
            }
        }
        return false;
    }
    public static bool EntrarAdm(string senha){
        NUsuario usuarios = new NUsuario();
        Usuario u = usuarios.ObterId(1); // 1 é o id do usuário administrador
        if (u.Senha == senha) return true;
        return false;
    }

    

    public static void ColocarNota(int nota){

    }
    public static int VerNota(){
        
    }
}