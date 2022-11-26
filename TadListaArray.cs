using System;

class Program{
  public static void Main(){
    try{
      List l = new List();
      l.insertFirst(3);
      l.insertLast(4);
      l.insertLast(5);
      //Console.WriteLine(l.After(5));
      //l.replaceElement(5, 100);
      //l.swapElements(3, 100);
      l.insertAfter(3, 8);
      l.insertBefore(3, 10);
      l.Remove(8);
      Console.WriteLine("\nSize:"+l.size);
      l.ver_list();
    }
    catch(ListVazia){
      Console.WriteLine("Lista vazia");
    }
    catch(ElementoNaoExiste){
      Console.WriteLine("Elemento não existe");
    }
  }
}


/*--------- CLASSE DO TAD LIST ----------*/
class List: IList{
  public object[] list;
  public int size, capacity;
  public List(){
    capacity = 3;
    list = new object[capacity];
  }
  
  public Boolean isFirst(object n){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    return list[0].Equals(n);
  }

  public Boolean isLast(object n){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    return list[size-1].Equals(n);
  }

  public object First(){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    return list[0];
  }
  public object Last(){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    return list[size-1];
  }

  public object Before(object p){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(p)){
        index = i;
        break;
      }
    if(index==-1 || index==size-1)
      throw new ElementoNaoExiste("Elemente não existe");
    return list[index+1];
  }

  public object After(object p){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(p)){
        index = i;
        break;
      }
    if(index==-1 || index==0)
      throw new ElementoNaoExiste("Elemente não existe");
    return list[index-1];
  }
  public void insertFirst(object o){
    if(capacity==size)
      Capacity_Up();
    if(size==0)
      list[0] = o;
    else{
      for(int i=size-1; i>=0; i--)
        list[i] = list[i-1];
    }
    size++;
  }
    
  public void insertLast(object o){
    if(capacity==size)
      Capacity_Up();
    list[size++] = o;
  }

  public void replaceElement(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index = i;
        break;
      }
    if(index==-1)
      throw new ElementoNaoExiste("Elemente não existe");
    list[index] = o;
  }

  public void swapElements(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index1 = -1, index2 = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index1 = i;
        break;
      }
    for(int i=0; i<size; i++)
      if(list[i].Equals(o)){
        index2 = i;
        break;
      }
    if(index1==-1 || index2==-1)
      throw new ElementoNaoExiste("Elemente não existe");
    object aux = list[index1];
    list[index1] = list[index2];
    list[index2] = aux;
  }
  
  public void insertAfter(object n, object o){
    if(capacity==size)
      Capacity_Up();
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index = i;
        break;
      }
    if(index==-1)
      throw new ElementoNaoExiste("Elemente não existe");
    for(int i=size; i>index; i--){
      list[i] = list[i-1];
    }
    list[index+1] = o;
    size++;
  }

  public void insertBefore(object n, object o){
    if(capacity==size)
      Capacity_Up();
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index = i;
        break;
      }
    if(index==-1)
      throw new ElementoNaoExiste("Elemente não existe");
    for(int i=size; i>index; i--){
      list[i] = list[i-1];
    }
    list[index] = o;
    size++;
  }

  public object Remove(object n){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index = i;
        break;
      }
    if(index==-1)
      throw new ElementoNaoExiste("Elemento não existe");
    object temp = list[index];
    for(int i=index; i<size; i++)
      list[i] = list[i+1];
    size--;
    return temp;  
  }
  
  public Boolean isEmpty(){
    return size==0;
  }

  public int Size(){
    return size;
  }

  public void Capacity_Up(){
    object[] vetor_aux = new object[capacity*2];
    for(int i=0; i<capacity; i++)
      vetor_aux[i] = list[i];
    list = vetor_aux;
    capacity = capacity*2; 
  }
  
  public void ver_list(){
    Console.Write("[");
    for(int i=0; i<size; i++)
      Console.Write(list[i]+" ");
    Console.Write("]");
  }
}


/*---------- CLASSES DAS EXCEÇÕES ---------*/
public class ListVazia : Exception { 
  public ListVazia(String err){ }
}
  
public class IndiceForadeFaixa : Exception { 
  public IndiceForadeFaixa(String err){ }
}

public class ElementoNaoExiste : Exception { 
  public ElementoNaoExiste(String err){ }
}


/* ------INTERFACE DOS MÉTODOS--------*/ 
interface IList{
  //Verifica se o object é primeiro  *
  Boolean isFirst(object n);
  //Verifica se o object é último *
  Boolean isLast(object n);
  //Retorna o primeiro *
  object First();
  //Retorna o último *
  object Last();
  //Retorna o depois do obejct *
  object Before(object p);
  //Retorna o antes do object *
  object After(object p);
  //Substitui o object n pelo object o *
  void replaceElement(object n, object o);
  //Troca o object n com object o *
  void swapElements(object n, object o);
  //Insere o depois do n 
  void insertBefore(object n, object o);
  //Insere o antes do n
  void insertAfter(object n, object o);
  //Insere no inicio *
  void insertFirst(object o);
  //Insere no fim *
  void insertLast(object o);
  //Remove n 
  object Remove(object n);
  //retorna o tamanho
  int Size();
  //Retorna se há elementos ou nãobject
  Boolean isEmpty();
}
