﻿using System;
using System.Collections.Generic;

class Program{
    public static void Main(){
        Administrador();
        int op = 0;
        while(op != 3){
            op = Login();
            switch(op){
                case 1:
                    bool cadastro = Cadastrar();
                    if (cadastro){
                        Console.WriteLine();
                        Console.WriteLine("Usuário cadastrado.");
                        Console.WriteLine();
                        break;
                    }
                    else {
                        Console.WriteLine();
                        Console.WriteLine("Esse nome de usuário já existe.");
                        Console.WriteLine();
                        break;
                    }
                case 2:
                    int op2 = TipoUser();
                    if (op2 == 1){
                        bool entrar = EntrarAdministrador();
                        if (!entrar){
                            Console.WriteLine();
                            Console.WriteLine("Senha inválida.");
                            Console.WriteLine();
                            break;
                        }
                        int op3 = 0;
                        while (op3 != 5){
                            op3 = MenuAdministrador();
                            switch(op3){
                                case 1: MostrarMidiasAdministrador(1); break;
                                case 2: MostrarMidiasAdministrador(2); break;
                                case 3: MostrarMidiasAdministrador(3); break;
                                case 4: AdicionarMidiaSistema(); break;
                            }
                        }
                    }
                    if (op2 == 2){
                        bool entrar = EntrarUsuario();
                        if (!entrar){
                            Console.WriteLine();
                            Console.WriteLine("Senha ou usuário inválidos.");
                            Console.WriteLine();
                            break;
                        }
                        int op3 = 0;
                        while(op3 != 4){
                            op3 = MenuUsuario();
                            switch(op3){
                                case 1: MostrarMidias(1); break;
                                case 2: MostrarMidias(2); break;
                                case 3: MostrarMidias(3); break;
                            }
                        }
                    } break;
            }
        }
    }
    
    public static void Administrador(){
        Usuario user = new Usuario{Id = 1, Username = "admin", Senha = "IFRNtads2023"};
        NUsuario usuarios = new NUsuario();
        usuarios.Inserir(user);
        View.CriarAdm();
    }
    public static int Login(){
        Console.WriteLine("----------------");
        Console.WriteLine("TADSBoxD");
        Console.WriteLine("----------------");
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Entrar");
        Console.WriteLine("3 - Sair");
        Console.WriteLine();
        int op = int.Parse(Console.ReadLine());
        if(op == 1 || op == 2 || op == 3) return op;
        else return 0;
    }
    public static bool Cadastrar(){
        Console.WriteLine("Insira seu username:");
        string username = Console.ReadLine();

        Console.WriteLine("Insira sua senha:");
        string senha = Console.ReadLine();

        return View.CadastrarUser(username, senha);
    }
    public static int TipoUser(){
        Console.WriteLine();
        Console.WriteLine("1 - Administrador");
        Console.WriteLine("2 - Usuario");
        Console.WriteLine();
        int op = int.Parse(Console.ReadLine());
        if(op == 1 || op == 2) return op;
        else return 0;
    }
    public static bool EntrarAdministrador(){
        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();
        Console.WriteLine();
        return View.EntrarAdm(senha);
    }
    public static bool EntrarUsuario(){
        Console.WriteLine("Username:");
        string username = Console.ReadLine();

        Console.WriteLine("Senha:");
        string senha = Console.ReadLine();
        Console.WriteLine();
        return View.EntrarUser(username, senha);
    }
    //MENUS
    public static int MenuUsuario(){
        Console.WriteLine("MENU");
        Console.WriteLine("1 - Ver filmes");
        Console.WriteLine("2 - Ver séries");
        Console.WriteLine("3 - Ver livros");
        Console.WriteLine("4 - Sair do sistema");
        Console.WriteLine();
        int op = int.Parse(Console.ReadLine());
        return op;
    }
    public static int MenuAdministrador(){
        Console.WriteLine("MENU");
        Console.WriteLine("1 - Ver filmes");
        Console.WriteLine("2 - Ver séries");
        Console.WriteLine("3 - Ver livros");
        Console.WriteLine("4 - Adicionar mídia");
        Console.WriteLine("5 - Sair do sistema");
        Console.WriteLine();
        int op = int.Parse(Console.ReadLine());
        return op;
    }
    //OPÇÕES DO MENU
    public static void MostrarMidiasAdministrador(int tipo){
        if (tipo == 1){
            Console.WriteLine();
            foreach(Filme f in View.ListarFilmes()){
                Console.WriteLine($"{f.Id} - {f.Titulo}");
            }
        }
        if (tipo == 2){
            Console.WriteLine();
            foreach(Serie s in View.ListarSeries()){
                Console.WriteLine($"{s.Id} - {s.Titulo}");
            }
        }
        if (tipo == 3){
            Console.WriteLine();
            foreach(Livro l in View.ListarLivros()){
                Console.WriteLine($"{l.Id} - {l.Titulo}");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Digite o ID da mídia que deseja visualizar");
        int id_midia = int.Parse(Console.ReadLine()); 
        Console.WriteLine("");
        //colocar as opções
        if (tipo == 1){
            Filme f = new Filme();
            f = View.VerFilme(id_midia);
            Console.WriteLine($"{f.Titulo} - {f.Autor_diretor}");
            Console.WriteLine($"Sinopse: {f.Descricao}");
            Console.WriteLine("");
        }
        if (tipo == 2){
            Serie s = new Serie();
            s = View.VerSerie(id_midia);
            Console.WriteLine($"{s.Titulo} - {s.Autor_diretor}");
            Console.WriteLine($"Sinopse: {s.Descricao}");
            Console.WriteLine("");
        }
            
        if (tipo == 3){
            Livro l = new Livro();
            l = View.VerLivro(id_midia);
            Console.WriteLine($"{l.Titulo} - {l.Autor_diretor}");
            Console.WriteLine($"Sinopse: {l.Descricao}");
            Console.WriteLine("");
        }
         
        Console.WriteLine(" ");
        Console.WriteLine("Deseja realizar alguma operação?");
        Console.WriteLine("1 - Excluir");
        Console.WriteLine("2 - Editar");
        Console.WriteLine("3 - Voltar");

        int op = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        if(op == 1){
            View.ExcluirMidia(tipo, id_midia);
            Console.WriteLine("");
        }
        if(op == 2){
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Autor/diretor: ");
            string autor_diretor = Console.ReadLine();

            View.AtualizarMidia(titulo, descricao, autor_diretor, tipo, id_midia);
            Console.WriteLine("");
        }
        if(op == 3){
            Console.WriteLine("Voltando!");
            Console.WriteLine("");
        }
    }

    public static void MostrarMidias(int tipo){
        if (tipo == 1){
            Console.WriteLine();
            foreach(Filme f in View.ListarFilmes()){
                Console.WriteLine($"{f.Id} - {f.Titulo}");
            }
        }
        if (tipo == 2){
            Console.WriteLine();
            foreach(Serie s in View.ListarSeries()){
                Console.WriteLine($"{s.Id} - {s.Titulo}");
            }
        }
        if (tipo == 3){
            Console.WriteLine();
            foreach(Livro l in View.ListarLivros()){
                Console.WriteLine($"{l.Id} - {l.Titulo}");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Digite o ID da mídia que deseja visualizar");
        int id_midia = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        if (tipo == 1){
            Filme f = new Filme();
            f = View.VerFilme(id_midia);
            Console.WriteLine($"{f.Titulo} - {f.Autor_diretor}");
            Console.WriteLine($"Sinopse: {f.Descricao}");
            Console.WriteLine("");
        }
        if (tipo == 2){
            Serie s = new Serie();
            s = View.VerSerie(id_midia);
            Console.WriteLine($"{s.Titulo} - {s.Autor_diretor}");
            Console.WriteLine($"Sinopse: {s.Descricao}");
            Console.WriteLine("");
        }
            
        if (tipo == 3){
            Livro l = new Livro();
            l = View.VerLivro(id_midia);
            Console.WriteLine($"{l.Titulo} - {l.Autor_diretor}");
            Console.WriteLine($"Sinopse: {l.Descricao}");
            Console.WriteLine("");
        }
        //opções do usuário
            //avaliar
            //adicionar a lista
            //voltar
        Console.WriteLine(" ");
        Console.WriteLine("Deseja realizar alguma operação?");
        Console.WriteLine("1 - Avaliar");
        Console.WriteLine("2 - Ver nota");
        Console.WriteLine("3 - Voltar");
        
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        if (op == 1) AvaliacaoDeMidia(id_midia, tipo);
        if (op == 2){
            int nota = View.NotaMidia(tipo, id_midia);
            Console.WriteLine($"Nota: {nota}");
            Console.WriteLine("");
        }
        if(op == 3){
            Console.WriteLine("Voltando!");
        }
    }
    
    public static void AdicionarMidiaSistema(){
        Console.WriteLine("Selecione o tipo da mídia");
        Console.WriteLine("1 - Filme");
        Console.WriteLine("2 - Série");
        Console.WriteLine("3 - Livro");
        Console.WriteLine("");
        
        int add = int.Parse(Console.ReadLine());
        if (add < 4 && add > 0){
            Console.WriteLine("Título:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Descrição:");
            string descricao = Console.ReadLine();
            Console.WriteLine("Autor/diretor:");
            string autor_diretor = Console.ReadLine();
            View.AdicionarMidia(titulo, descricao, autor_diretor, add);
            Console.WriteLine("");
        }
    }
    
    public static void AvaliacaoDeMidia(int id, int tipo){
        Console.WriteLine("");
        Console.WriteLine("Nota (de 0 a 10):");
        int nota = int.Parse(Console.ReadLine());
        Console.WriteLine("Comentário:");
        string coment = Console.ReadLine();
        View.AvaliarMidia(tipo, id, nota, coment);
        Console.WriteLine("");
    }
}