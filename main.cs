using System;
using MinhaPilha;

class Program{
  public static void Main(){
    Pilha p = new Pilha();

    p.Push(1);
    Console.Write(p.Top());
  }
}