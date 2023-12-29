using System;
using System.Collections.Generic;
using midias;
using usuarios;
using avaliacoes;

namespace view{

static class View{
    public bool CadastrarUser(string email, string username, string senha){
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
            if(u.username == username) return false;
        }
        Usuario new_user = new Usuario{username = username, senha = senha};
        usuarios.Inserir(new_user);
        return true;
    }
    public bool EntrarUser(string username, string senha){
        NUsuario usuarios = new NUsuario();
        List<Usuario> users = usuarios.Listar();
        foreach (Usuario u in users){
            if (u.username == username && u.senha == senha){
                return true;
            }
        }
        return false;
    }
    public void EntrarAdm(string senha){
        NUsuario usuarios = new NUsuario();
        Usuario u = usuarios.ObterId(1); // 1 é o id do usuário administrador
        if (u.senha == senha) return true;
        return false;
    }

    public void ColocarNota(int nota){

    }
    public int VerNota(){
        
    }
}
}