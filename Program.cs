﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using static Plataforma_do_Aluno.Conta;

namespace Plataforma_do_Aluno
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> Listaconta = new List<Conta>();
            bool login = true;

            string directoryPath = @"C:\Users\Alunos\source\repos\Plataforma de Alunos\Plataforma de Alunos";
            string fileName = "Contas.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            while (true)
            {
                if (login)
                {
                    Console.WriteLine("Escolha uma operação : \r\n[1] Login \r\n[2] Cadastro");
                    int operação = int.Parse(Console.ReadLine());

                    if (operação == 1)
                    {
                        Console.WriteLine("Insira o seu e-mail");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Insira sua senha");
                        string Senha = Console.ReadLine();

                        foreach (Conta conta in Listaconta)
                        {
                            if ((conta.GetEmail() == Email) && (conta.GetSenha() == Senha))
                            {
                                login = false;
                            }
                            else
                            {
                                Console.WriteLine("Email ou a senha ta errado");
                            }
                        }
                    }
                    else if (operação == 2)
                    {
                        Console.WriteLine("Insira o seu e-mail");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Insira o nome da sua conta");
                        string Nome = Console.ReadLine();
                        Console.WriteLine("Insira a senha da conta");
                        string Senha = Console.ReadLine();

                        Conta conta = new Conta(Email, Nome, Senha);
                        Listaconta.Add(conta);

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine($"{Email},{Nome},{Senha}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Um erro ocorreu : " + ex.Message);
                        }

                    }
                    else
                    {
                        Console.WriteLine("\r\nOperação não existe \r\n");
                    }
                }
                else
                {
                    //Botar o codigo aq
                }
            }
        }
    }
}
