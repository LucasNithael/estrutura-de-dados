/*
- isFirst: Verifica se o parâmetro é o primeiro
- isLast: Verifica se o parâmetro é o último
- First: Retorna o primeiro elemento da lista
- Last: Retorna o último elemento da lista
- Before: Retorna o anterior do parâmetro (se primeiro retorna null)
- After: Retorna o sucessor do parâmetro (se último retorna null)
- replaceElement: Subescreve o elemento n por o 
- swapElements: Troca o elemento n de lugar com elemento o
- insertBefore: Insere antes do parâmetro o deslocando para abrir caminho
- insertAfter: Insere depois do parâmetro
- insertFirst: Insere no começo da lista
- insertLast: Insere no final da lista
- Remove: Remove o parâmetro
- Size: Retorna quantidade elementos da lista
- isEmpty: Verifica se há elementos na lista
*/

using System;

class Program{
  public static void Main(){
    try{
      List l = new List();
      l.insertFirst(1);
      l.insertFirst(2);
      l.insertFirst(3);
      l.insertLast(4);
      l.insertLast(5);
      //Console.WriteLine("isFirst: "+l.isFirst(2));
      //Console.WriteLine("isLast: "+l.isLast(1));
      //Console.WriteLine("First: "+l.First());
      //Console.WriteLine("Last: "+l.Last());
      //Console.WriteLine("Before: "+l.Before(3));
      //Console.WriteLine("After: "+l.After(1));
      //Console.WriteLine("replaceElement: "+l.replaceElement(3, 4));
      //l.swapElements(2, 3);
      //l.insertBefore(3, "P");
      //l.insertAfter(1, "Q");
      //Console.WriteLine("Remove: "+l.Remove(2));
      Console.WriteLine("Size:"+l.Size());
     
      l.Ver_Lista_i();
      Console.WriteLine();
      l.Ver_Lista_f();
    }
    catch(ListVazia){
      Console.WriteLine("Lista Vazia");
    }
    catch(ElementoNaoExiste){
      Console.WriteLine("Elemento não existe");
    }
  }
}

/*---------CLASSE DA LISTA----------*/
class List{
  private Node i = new Node(null); 
  private Node f = new Node(null);
  private int size;
  public List(){
    i.SetNext(f);
    f.SetPrev(i);
  }
  public Boolean isFirst(object o){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return i.GetNext().GetElement().Equals(o);
  }
  public Boolean isLast(object o){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return f.GetPrev().GetElement().Equals(o);
  }
  public object First(){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return i.GetNext().GetElement();
  }
  public object Last(){
    if(isEmpty())
      throw new ListVazia("Lista Vaiza");
    return f.GetPrev().GetElement();
  }
  public object Before(object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    int index_aux = size;
    Node current = i.GetNext();
    while(index_aux!=0){
      if(current.GetElement().Equals(o))
        break;
      current = current.GetNext();
      index_aux--;
    }
    if(index_aux==0)
      throw new ElementoNaoExiste("Elemento não existe");
    return current.GetPrev().GetElement();
  }
  public object After(object o){
     if(isEmpty())
      throw new ListVazia("Lista vazia");
    int index_aux = size;
    Node current = f.GetPrev();
    while(index_aux!=0){
      if(current.GetElement().Equals(o))
        break;
      current = current.GetPrev();
      index_aux--;
    }
    if(index_aux==0)
     throw new ElementoNaoExiste("Elemento não existe");
    return current.GetNext().GetElement();
  }
  public object replaceElement(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node current = i.GetNext();
    while(current!=null){
      if(current.GetElement().Equals(n))
        break;
      current = current.GetNext();
    }
    if(current==null)
      throw new ElementoNaoExiste(n+" Não existe na lista");
    object temp = current.GetElement();
    current.SetElement(o);
    return temp;
  }
  public void swapElements(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node a = i.GetNext();
    while(a!=null){
      if(a.GetElement().Equals(n))
        break;
      a = a.GetNext();
    }
    if(a==null)
      throw new ElementoNaoExiste(n+" não existe na lista");
    Node b = i.GetNext();
    while(b!=null){
      if(b.GetElement().Equals(o))
        break;
      b = b.GetNext();
    }
    if(b==null)
      throw new ElementoNaoExiste(o+" não existe na lista");
    object c = b.GetElement();
    b.SetElement(a.GetElement());
    a.SetElement(c);
  }
  public void insertBefore(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node current = i.GetNext();
    while(current!=null){
      if(current.GetElement().Equals(n))
        break;
      current = current.GetNext();
    }
    if(current==null)
      throw new ElementoNaoExiste(n+" não existe na lista");
    Node new_ = new Node(o);
    Node current_prev = current.GetPrev();
    new_.SetNext(current);
    new_.SetPrev(current_prev);
    current.SetPrev(new_);
    current_prev.SetNext(new_);
    size++;
  }
  public void insertAfter(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node current = i.GetNext();
    while(current!=null){
      if(current.GetElement().Equals(n))
        break;
      current = current.GetNext();
    }
    if(current==null)
      throw new ElementoNaoExiste(n+" não existe na lista");
    Node new_ = new Node(o);
    Node current_next = current.GetNext();
    new_.SetPrev(current);
    new_.SetNext(current_next);
    current.SetNext(new_);
    current_next.SetPrev(new_);
    size++;
  }
  public void insertFirst(object o){
    Node new_ = new Node(o);
    if(isEmpty()){
      new_.SetPrev(i);
      new_.SetNext(f);
      i.SetNext(new_);
      f.SetPrev(new_);
    }
    else{
      Node i_next = i.GetNext();
      i.SetNext(new_);
      i_next.SetPrev(new_);
      new_.SetNext(i_next);
      new_.SetPrev(i);
    }
    size++;
  }
  public void insertLast(object o){
    Node new_ = new Node(o);
    if(isEmpty()){
      new_.SetPrev(i);
      new_.SetNext(f);
      i.SetNext(new_);
      f.SetPrev(new_);
    }
    else{
      Node f_prev = f.GetPrev();
      new_.SetPrev(f_prev);
      new_.SetNext(f);
      f.SetPrev(new_);
      f_prev.SetNext(new_);
    }
    size++;
  }

  public object Remove(object o){
    if(isEmpty())
      throw new ListVazia("Lista vazia");
    Node current = i.GetNext();
    while(current!=null){
      if(current.GetElement().Equals(o))
        break;
      current = current.GetNext();
    }
    if(current==null)
      throw new ElementoNaoExiste("Elemento não existe na lista");
    Node current_next = current.GetNext();
    Node current_prev = current.GetPrev();
    current_prev.SetNext(current_next);
    current_next.SetPrev(current_prev);
    size--;
    return current.GetElement();
  }
  public Boolean isEmpty(){
    return size==0;
  }
  public int Size(){
    return size;
  }
  public void Ver_Lista_i(){
    Node current = i;
    while(current!=null){
      Console.Write(current.GetElement()+"<->");
      current = current.GetNext();
    }
  }
  
  public void Ver_Lista_f(){
   Node current = f;
   while(current!=null){
     Console.Write(current.GetElement()+"<->");
     current = current.GetPrev();
   }
  }
}

/*---------- CLASSES DAS EXCEÇÕES ---------*/
public class ListVazia : Exception { 
  public ListVazia(String err){ }
}
  
public class ElementoNaoExiste : Exception { 
  public ElementoNaoExiste(String err){ }
}

/*----------CLASSE NÓ-------------*/
class Node{
  private object element;
  private Node next, prev;
  public Node(object e){
    SetElement(e);
  }
  public void SetElement(object e){
    this.element = e;
  }
  public void SetNext(Node n){
    this.next = n;
  }
  public void SetPrev(Node n){
    this.prev = n;
  }
  public object GetElement(){
    return element;
  }
  public Node GetNext(){
    return next;
  }
  public Node GetPrev(){
    return prev;
  }
}