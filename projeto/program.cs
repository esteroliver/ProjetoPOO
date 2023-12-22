using System;

namespace projeto{

    class Program{
        static void Main(string[] args){
            Console.WriteLine("TADSBox");
            if(Login() == "admin"){
                int op = 0;
                while(op != 99){
                    try{
                        op = MenuAdm();
                        switch(op){
                            case 1: AdicionarFilme(); break;
                            case 2: AdicionarLivro(); break;
                            case 3: AdicionarSerie(); break;
                            case 4: AdicionarMidia(); break;
                            case 5: ExcluirMidia(); break;
                            case 6: ExcluirFilme(); break;
                            case 7: ExcluirLivro(); break;
                            case 8: ExcluirSerie(); break;
                            case 9: AtualizarFilme(); break;
                            case 10: AtualizarLivro(); break;
                            case 11: AtualizarSerie(); break;
                            case 12: AtualizarMidia(); break;
                            case 13: ListarFilme(); break;
                            case 14: ListarLivro(); break;
                            case 15: ListarSerie(); break;
                            case 16: ListarMidia(); break;
                        }
                    }
                    catch (Exception obj){
                        Console.WriteLine("Erro: " + obj.Message);
                    }
                }
                Console.WriteLine("Adeus");
            }
            else{
                int op = 0;
                while(op != 99){
                    try{
                        op = MenuUser();
                        switch(op){
                            case 1: VerFilme(); break;
                            case 2: VerLivro(); break;
                            case 3: VerSerie(); break;
                            case 4: AvaliarFilme(); break;
                            case 5: AvaliarLivro(); break;
                            case 6: AvaliarSerie(); break;
                            case 7: ComentarFilme(); break;
                            case 8: ComentarLivro(); break;
                            case 9: ComentarSerie(); break;
                            case 10: VerNotaFilme(); break;
                            case 11: VerNotaLivro(); break;
                            case 12: VerNotaSerie(); break;
                        }
                    }
                    catch(Exception obj){
                        Console.WriteLine("Erro: " + obj.Message);
                    }
                }
                Console.WriteLine("Adeus");
            }
        }
        public static string Login(){
            Console.WriteLine();
            Console.WriteLine("Usuário: ");
            string user = Console.ReadLine();
            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            if(user == "admin" && senha = "LE101404"){
                return "admin";
            }
            return "usuario";
        }
        public static int MenuUser(){
            Console.WriteLine();
            Console.WriteLine("Menu Usuário");
            Console.WriteLine("01 - Ver Filme");
            Console.WriteLine("02 - Ver Livro");
            Console.WriteLine("03 - Ver Serie");
            Console.WriteLine("04 - Avaliar Filme");
            Console.WriteLine("05 - Avaliar Livro");
            Console.WriteLine("06 - Avaliar Serie");
            Console.WriteLine("07 - Comentar Filme");
            Console.WriteLine("08 - Comentar Livro");
            Console.WriteLine("09 - Comentar Serie");
            Console.WriteLine("10 - Ver Nota(Filme)");
            Console.WriteLine("11 - Ver Nota(Livro)");
            Console.WriteLine("12 - Ver Nota(Serie)");
            Console.WriteLine();
            Console.WriteLine("99 - Sair");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }
        public static int MenuAdm(){
            Console.WriteLine();
            Console.WriteLine("Menu Admin");
            Console.WriteLine("01 - Adicionar Filme");
            Console.WriteLine("02 - Adicionar Livro");
            Console.WriteLine("03 - Adicionar Serie");
            Console.WriteLine("04 - Adicionar Midia");
            Console.WriteLine("05 - Excluir Filme");
            Console.WriteLine("06 - Excluir Livro");
            Console.WriteLine("07 - Excluir Serie");
            Console.WriteLine("08 - Excluir Midia");
            Console.WriteLine("09 - Atualizar Filme");
            Console.WriteLine("10 - Atualizar Livro");
            Console.WriteLine("11 - Atualizar Serie");
            Console.WriteLine("12 - Atualizar Midia");
            Console.WriteLine("13 - Listar Filme");
            Console.WriteLine("14 - Listar Livro");
            Console.WriteLine("15 - Listar Serie");
            Console.WriteLine("16 - Listar Midia");
            Console.WriteLine();
            Console.WriteLine("99 - Sair");
            Console.Write("\nOpção: ");
            return int.Parse(Console.ReadLine());
        }
    }
}