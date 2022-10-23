using System;

class Program{
  public static void Main(){
    Fila f = new Fila();
    for(int i=1; i<=4; i++) 
      f.Enqueue(i);
    Console.WriteLine("Dequeue: " + f.Dequeue());
    Console.WriteLine("Dequeue: " + f.Dequeue());
    Console.WriteLine("Size: " + f.Size());
    Console.WriteLine("isEmpty: " + f.IsEmpty());
    f.print();
  }
}


//Classe do No
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


//Class da Fila
class Fila{
  private No first;
  private No last;
  private int size;

  public void Enqueue(object e){
    No new_ = new No(e);
    new_.SetNext(null);
    if(size==0){
      last = new_;
      first = last;
    }
    else{
      last.SetNext(new_);
      last = new_;
    }
    size++;
  }
  public object Dequeue(){
    object x;
    if(size==0)
      throw new FilaVazia("Fila Vazia");
    if(size==1){
      x = first.GetElement();
      first = null;
      last = first;
      return x;
    }
    x = first.GetElement();
    first = first.GetNext();
    size--;
    return x;
  }
  public object First(){
    return first.GetElement();
  }
  public int Size(){
    return size;
  }
  public Boolean IsEmpty(){
    return size != 0;
  }
  
  public void print(){
    No current = first;
    while(current != null){
      Console.Write(current.GetElement() + "->");
      current = current.GetNext();
    }
  }
}


//Classe da Exceção
public class FilaVazia : Exception { 
  public FilaVazia(String err){ }
}