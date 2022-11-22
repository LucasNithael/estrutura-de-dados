using System;

class MainClass{
  public static void Main(){
    Vector v = new Vector();
    v.Inserir_Inicio(111);
    v.Inserir_Inicio(100);
    v.Inserir_Inicio(5);
    v.Inserir_Inicio(6);
    Console.WriteLine("Size:"+v.size);
    Node x = (Node)v.elementAtRank(1);
    v.insertAtRank(4, x);
    //v.removeAtRank(1);
    //v.Remove_Fim();
    v.Ver_Lista();
    
  }
}

class Vector{
  private Node first, last;
  public int size;

  public void Inserir_Inicio(object o){
    Node new_ = new Node(o);
    if(size==0){
      first = new_;
      last = new_;
    }
    else{
      first.SetPrev(new_);
      new_.SetNext(first);
      first = new_;
    }
   size++;   
  }

  public object Remove_Fim(){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    object temp = last;
    Node anterior_last = last.GetPrev();
    anterior_last.SetNext(null);
    last = anterior_last;
    size--;
    return temp;
  }

  public object elementAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node current = first;
    while(r!=0){
      current = current.GetNext(); 
      r--;
    }
    return current;
  }

  public object replaceAtRank(int r, object o){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    if(r==size){
      Node node = (Node)o;
      Node novo = new Node(node.GetElement());
      novo.SetNext(null);
      novo.SetPrev(last);
      last.SetNext(novo);
      last = novo;
      size++;
      return null;
    }
    else{
      Node current = first;
      while(r!=0){
        current = current.GetNext();
        r--;
      }
      Node temp = current;
      Node aux = (Node)o;
      current.SetElement(aux.GetElement());
    return temp;
    }
  }

  public void insertAtRank(int r, object o){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    if(r==size){
      Node node = (Node)o;
      Node novo = new Node(node.GetElement());
      novo.SetNext(null);
      novo.SetPrev(last);
      last.SetNext(novo);
      last = novo;
      size++;
    }
    else{
      Node current = first;
      while(r!=0){
        current = current.GetNext();
        r--;
      }
      Node temp = current;
      Node aux = (Node)o;
      current.SetElement(aux.GetElement());
    }
  }

  public object removeAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node b = first;
    int indexAux = r;
    while(r!=0){
      b = b.GetNext();
      r--;
    }
    Node temp = b;
    Console.WriteLine(temp.GetElement());
    // [A] <-> [B] <-> [c]
    if(b==last){
      Node before_last = b.GetPrev();
      before_last.SetNext(null);
      last = before_last;
    }
    else if(indexAux==0)
      first = b.GetNext();
    else{
      Node a = b.GetPrev();
      Node c = b.GetNext();
      a.SetNext(c);
      c.SetPrev(a);
    }
    size--;
    return temp;
    
  }

  public int Size(){
    return size;
  }

  public Boolean isEmpty(){
    return size!=0;
  }
  
  public void Ver_Lista(){
    Node current = first;
    while(current!=null){
      Console.Write(current.GetElement()+"<->");
      current = current.GetNext();
    }
  }
}

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