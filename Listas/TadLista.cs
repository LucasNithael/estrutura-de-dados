using System;

class Lista: ILista{
  private int size=0;
  private No first;

  private void Add(object o){
    No new_ = new No(o);
    new_.SetNext(first);
    first = new_;
    size++;
  }
  
}