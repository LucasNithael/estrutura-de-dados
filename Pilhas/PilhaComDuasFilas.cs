using System;
using System.Collections;
using Exception;

class Pilha{
  Queue f1 = new Queue();
  Queue f2 = new Queue();
  public void Push(object e){
    if(f1.Count!=0)
      f1.Enqueue(e);
    else
      f2.Enqueue(e);
  }
  public object Pop(){
    if(Size() == 0)
      throw new PilhaVazia("Pilha vazia");
    if(f1.Count!=0){
     Troca();
     return f1.Dequeue();
    }
    Troca();
    return f2.Dequeue();
  }
  public int Size(){
    return f1.Count+f2.Count;
  }
  public object Top(){
    if(Size() == 0)
      throw new PilhaVazia("Pilha vazia");
    object temp;
    if(f1.Count!=0){
      Troca();
      temp = f1.Dequeue();
      Push(temp);
      return temp;
    }
    Troca();
    temp = f2.Dequeue();
    Push(temp);
    return temp;
  }
  private void Troca(){
    if(f1.Count!=0){
      int aux = f1.Count;
      for(int i=0; i<aux-1; i++)
        f2.Enqueue(f1.Dequeue());
    }
    else{
      int aux = f2.Count;
      for(int i=0; i<aux-1; i++)
        f1.Enqueue(f2.Dequeue());
    }
  }
}
