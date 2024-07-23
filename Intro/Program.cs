// See https://aka.ms/new-console-template for more information
using System;

Console.Write("Who would you like to say hello to? ");

string name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Fine, don't say 'hello'!");
}
else
{
    Console.WriteLine($"Hello, {name}!");
}