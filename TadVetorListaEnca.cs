using System;

class MainClass{
  public static void Main(){
    Vector v = new Vector();
    v.insertAtRank(0, 1);
    v.insertAtRank(1, 2);
    v.insertAtRank(2, 3);
    v.insertAtRank(3, 4);
    v.replaceAtRank(3, "P");
    v.removeAtRank(1);
    Console.WriteLine("ElementAtRank:"+v.elementAtRank(3));
    v.Ver_Lista_i();
    
    v.Ver_Lista_f();
    
  }
}


/************ Classe Do Vetor **************/
class Vector{
  private Node i,f;
  private int size;
  
  public Vector(){
    i = new Node(null);
    f = new Node(null);
    i.SetNext(f);
    f.SetPrev(i);
  }
  public object elementAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node current = i;
    while(r!=0){
      current = current.GetNext(); 
      r--;
    }
    return current.GetNext().GetElement();
  }

  public object replaceAtRank(int r, object o){
    if(isEmpty())
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node current = i;
    while(r!=0){
      current = current.GetNext();
      r--;
    }
    object temp = current.GetNext().GetElement(); 
    Node current_next = current.GetNext();
    current_next.SetElement(o);
    return temp;
  }

  public void insertAtRank(int r, object o){
    if(r>size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node new_ = new Node(o);
    if(r==0 && isEmpty()){
      new_.GetPrev(i);
      new_.GetNext(f);
      i.SetNext(new_);
      f.SetPrev(new_);
    }
    else if(r==size){
      Node previus_f = f.GetPrev();
      new_.SetNext(f);
      new_.SetPrev(f.GetPrev());
      previus_f.SetNext(new_);
      f.SetPrev(new_);
    }
    else{
      Node current = i;
      while(r!=0){
        current = current.GetNext();
        r--;
      }
      if(current==i){
        Node previus_next_i = i.GetNext();
        new_.SetNext(i.GetNext());
        new_.SetPrev(i);
        previus_next_i.SetPrev(new_);
        i.SetNext(new_);
      }
      else{
        new_.SetPrev(current);
        new_.SetNext(current.GetNext());
        Node current_next = current.GetNext();
        current_next.SetPrev(new_);
        current.SetNext(new_);
      }
    }
    size++;
  }

  public object removeAtRank(int r){
    if(isEmpty())
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node current = i;
    while(r!=0){
      current = current.GetNext();
      r--;
    }
    
    object temp = current.GetNext().GetElement();
    Node current_next = current.GetNext();
    Node current_next_next = current_next.GetNext();
    current.SetNext(current_next_next);
    current_next_next.SetPrev(current);
    size--;
    return temp;
  }

  public int Size(){
    return size;
  }
  
  public Boolean isEmpty(){
    return size==0;
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

/************ Classe Do Nó **************/
class Node{
  private object element;
  private Node next;
  private Node prev;
  public Node(object e){
    SetElement(e);
  }
  public void SetElement(object o){
    this.element = o;
  }
  public void SetNext(Node no){
    this.next = no;
  }
  public object GetElement(){
    return element;
  }
  public Node GetNext(){
    return next;
  }
  public void SetPrev(Node o){
    this.prev = o;
  }
  public Node GetPrev(){
    return prev;
  }
}

  
public class VectorVazia : Exception { 
    public VectorVazia(String err){ }
  }
  
public class IndiceForadeFaixa : Exception { 
  public IndiceForadeFaixa(String err){ }
}