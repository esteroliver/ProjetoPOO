using System;
using System.Collections.Generic;
//using view.cs;

class Program{
    public static void Main(){
        Console.WriteLine("ListUP");
        int op = Login();
        switch(op){
            case 1: //cadastrar
                Cadastrar();
                break;
            case 2: //entrar
                int op2 = TipoUser();
                //ADMINISTRADOR
                if(op2 == 1){
                    bool entrar = EntrarAdministrador();
                    if(!entrar) break;
                    int op3 = MenuAdministrador();
                    if(op3 == 5) break;
                    else int op4 = op3;
                    switch(op4){
                        case 1: MostrarMidias(1); break;
                        case 2: MostrarMidias(2); break;
                        case 3: MostrarMidias(3); break;
                        case 4: AdicionarMidiaSistema(); break;
                    }
                }
                //USUÁRIO
                if(op2 == 2){
                    bool entrar = EntrarUsuario();
                    if(!entrar) break;
                    int op3 = MenuUsuario();
                    if(op3 == 5) break;
                    switch(op3){
                        case 1: MostrarMidias(1); break;
                        case 2: MostrarMidias(2); break;
                        case 3: MostrarMidias(3); break;
                    }
                }
        }
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

        Console.WriteLine("Insira seu email:");
        string email = Console.ReadLine();

        Console.WriteLine("Insira sua senha:");
        string senha = Console.ReadLine();

        return View.CadastrarUser(email, username, senha);
    }
    public static int TipoUser(){
        Console.WriteLine("1 - Administrador");
        Console.WriteLine("2 - Usuario");
        int op = int.Parse(Console.ReadLine());
        if(op == 1 || op == 2) return op;
        else return 0;
    }
    public static bool EntrarAdministrador(){
        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        return View.EntrarAdm(senha);
    }
    public static bool EntrarUsuario(){
        Console.WriteLine("Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();

        return View.EntrarUser(username, senha);
    }
    //MENUS
    public static int MenuUsuario(){
        Console.WriteLine("1 - Ver filmes");
        Console.WriteLine("2 - Ver séries");
        Console.WriteLine("3 - Ver livros");
        Console.WriteLine("4 - Minhas listas");
        Console.WriteLine("5 - Sair do sistema");

        int op = int.Parse(Console.ReadLine());
        return op;
    }
    public static int MenuAdministrador(){
        Console.WriteLine("1 - Ver filmes");
        Console.WriteLine("2 - Ver séries");
        Console.WriteLine("3 - Ver livros");
        Console.WriteLine("4 - Adicionar mídia");
        Console.WriteLine("5 - Sair do sistema");

        int op = int.Parse(Console.ReadLine());
        return op;
    }
    //OPÇÕES DO MENU
    public static void MostrarMidias(int tipo){
        if (tipo == 1){
            List<Filme> fs = View.ListarFilmes();
            foreach(Filme f in fs){
                Console.WriteLine($"{f.Id} - {f.Titulo}");
            }
        }
        if (tipo == 2){
            List<Serie> ss = View.ListarSeries();
            foreach(Serie s in ss){
                Console.WriteLine($"{s.Id} - {s.Titulo}")
            }
        }
        if (tipo == 2){
            List<Livro> ls = View.ListarLivros();
            foreach(Livro l in ls){
                Console.WriteLine($"{l.Id} - {l.Titulo}")
            }
        }
    }
    public static void AdicionarMidiaSistema(){
        Console.WriteLine("Selecione o tipo da mídia")
        Console.WriteLine("1 - Filme");
        Console.WriteLine("2 - Série");
        Console.WriteLine("3 - Livro");
        
        int add = int.Parse(Console.ReadLine());
        if (add < 4 && add > 0){
            Console.WriteLine("Título:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Descrição:");
            string descricao = Console.ReadLine();
            Console.WriteLine("Autor/diretor:");
            string autor_diretor = Console.ReadLine();
            View.AdicionarMidia(titulo, descricao, autor_diretor, add);
        }
    }
}