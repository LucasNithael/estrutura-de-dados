using System;

class Program{
  public static void Main(){
    Pilha p = new Pilha();
    for(int i=1; i<=5; i++)
      p.Push(i);

    Console.WriteLine(p.Pop());
    //p.Pop();
    Console.WriteLine(p.Top());
    Console.WriteLine(p.Size());
    p.print();
  }
}


//Classe No
class No{
  private object element;
  private No next;
  public No(object e){
    SetElement(e);
  }
  public void SetElement(object e){
    this.element = e;
  }
  public void SetNext(No n){
    this.next = n;
  }
  public object GetElement(){
    return element;
  }
  public No GetNext(){
    return next;
  }
}

//Classe Pilha
class Pilha{
  private No first;
  private int size = 0;

  public void Push(object e){
    No new_ = new No(e);
    new_.SetNext(first);
    first = new_;
    size++;
  }
  public object Pop(){
    if(size==0)
      throw new PilhaVazia("Pilha Vazia");
    object x = first.GetElement();
    first = first.GetNext();
    size--;
    return x;
  }
  public int Size(){
    return size;
  }
  public object Top(){
    if(size==0)
      throw new PilhaVazia("Pilha Vazia");
    return first.GetElement();
  }
  //Método apenas para ver a lista inteira
  public void print(){
    No current = first;
    while(current != null){
      Console.Write(current.GetElement() + "->");
      current = current.GetNext();
    }
  }
}

//Classe da Exceção
public class PilhaVazia : Exception { 
  public PilhaVazia(String err){ }
}