using Sytem;

class MainClass{
  public static void Main(){
    
  }
}

interface ILista{
/*
  //Fala se o object é o primeiro ou não
  Boolean isFirst(object n);
  //Fala se o objeto é o último ou não
  Boolean isLast(object n);
  //Retorna o primeiro objeto da lista
  object first();
  //Retorna o último objeto da lista
  object last();
*/
  swapElements(object n, object);
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