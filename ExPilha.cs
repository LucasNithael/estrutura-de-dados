using System;
using System.Collections;

class Program {
  public static void Main (string[] args) {
    try{
    Pilha p = new Pilha();
    p.Push(1);
    Console.WriteLine(p.Pop());
    Console.WriteLine(p.Top());
    Console.WriteLine(p.Size());
    }catch(PilhaVazia){
      Console.WriteLine("Pilha Vazia");
    }
  }
}

//Interface com as assinaturas dos métodos
interface IPilha{
  
  object Top();
  
  void Push(object e);
  
  object Pop();
  
  int Size();
  
}

//Classe Pilha implementada da Interface IPilha
class Pilha : IPilha{
  private ArrayList l = new ArrayList();
  
  public object Top(){
    if(Size() == 0)
      throw new PilhaVazia("Pilha vazia");
    object x = l[l.Count-1]; 
    return x;
  }
  public void Push(object e){
    l.Add(e);
  }
  public object Pop(){
    if(Size() == 0)
      throw new PilhaVazia("Pilha vazia");
    object x = Top();
    l.Remove(x);
    return x;
  }
  public int Size(){
    return l.Count;
  }
  
}

//Classe de Execeção
public class PilhaVazia : Exception { 
  public PilhaVazia(String err){ }
}