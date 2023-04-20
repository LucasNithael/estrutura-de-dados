using System;

//Class da Fila
class FilaComListaEncadeada{
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
