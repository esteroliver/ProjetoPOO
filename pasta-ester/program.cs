using System;
using System.Collections.Generic;
using view;

class Program{
    public static void Main(){
        Console.WriteLine("ListUP");
        int operation_1 = Login();
        if (operation_1 == 1){
            bool cadastrado = Cadastrar();
            bool entrar = EntrarUsuario();
            if (entrar) MenuUsuario();
        }
        if (operation_1 == 2){
            int operation_2 = TipoUser();
            if (operation_2 == 1){
                bool entrar_adm = EntrarAdministrador();
                if (entrar_adm) MenuAdministrador();
            }
            if (operation_2 == 2){
                bool entrar_user = EntrarUsuario();
                if (entrar_user) MenuUsuario();
            }
            if (operation_2 == 3) Login(); //????
        }
        // else para retornar erro
    }
    public static int Login(){
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Entrar");
        int op = int.Parse(Console.ReadLine());
        if(op == 1 || op == 2) return op;
        else return 0;
    }
    public static bool Cadastrar(){
        Console.WriteLine("Insira seu username:");
        string username = Console.ReadLine();

        Console.WriteLine("Insira seu email:")
        string email = Console.ReadLine();

        Console.WriteLine("Insira sua senha:")
        string senha = Console.ReadLine();

        return CadastrarUser(email, username, senha);
    }
    public static int TipoUser(){
        Console.WriteLine("1 - Administrador");
        Console.WriteLine("2 - Usuario");
        Console.WriteLine("3 - Voltar");
        int op = int.Parse(Console.ReadLine());
        if(op == 1 || op == 2 || op == 3) return op;
        else return 0;
    }
    public static bool EntrarAdministrador(){
        Console.WriteLine("Senha:")
        string senha = Console.ReadLine();

        return EntrarAdm(senha);
    }
    public static bool EntrarUsuario(){
        Console.WriteLine("Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        return EntrarUser(username, senha);
    }
    //MENUS
    public static int MenuUsuario(){

    }
    public static int MenuAdministrador(){

    }
}