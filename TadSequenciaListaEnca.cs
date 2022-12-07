using System;

class MainClass{
  public static void Main(){
    Sequence s = new Sequence();
    try{
    Node a = s.insertFirst(1);
    Node b = s.insertFirst(2);
    Node c = s.insertLast(3);
    }
    catch(IndiceForadeFaixa){
      Console.WriteLine("Índice fora de faixa");
    }
    
    s.print_header();
    Console.WriteLine();
    s.print_trailer();
  }
}

//CLASSE DO TAD SEQUÊNCIA
class Sequence{
  public int size;
  private Node header, trailer;
  public Sequence(){
    header = new Node(null);
    trailer = new Node(null);
    header.SetNext(trailer);
    trailer.SetPrev(header);
  }
  //Métodos pontes
  public int rankOf(Node n){
    Node current = header.GetNext();
    int r = 0;
    while(current != n && current != trailer){
      current = current.GetNext();
      r++;
    }
    return r;
  }
  public Node atRank(int r){
    Node current;
    if(r<=Size()/2){
      current = header.GetNext();
      for(int i=0; i<r; i++)
        current = current.GetNext();
    }
    else{
      current = trailer.GetPrev();
      for(int i=0; i<Size()-r-1; i++)
        current = current.GetPrev();
    }
    return current;
  }
  //Métodos de Vetor
  public Node elementAtRank(int r){
    if(size==0)
      throw new SequenceVazia("Sequência Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    return atRank(r);
  }

  public object replaceAtRank(int r, object o){
    if(isEmpty())
      throw new SequenceVazia("Sequência Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node n = atRank(r);
    object temp = n.GetElement();
    n.SetElement(o);
    return temp;
  }

  public Node insertAtRank(int r, object o){
    if(r>size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node new_ = new Node(o);
    Node n;
    if(r==Size())
      n = trailer;
    else
      n = atRank(r);
    Node n_prev = n.GetPrev();
    new_.SetNext(n);
    new_.SetPrev(n_prev);
    n.SetPrev(new_);
    n_prev.SetNext(new_);
    size++;
    return new_;
  }

  public object removeAtRank(int r){
    if(isEmpty())
      throw new SequenceVazia("Sequência Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("Índice fora de faixa");
    Node n = atRank(r);
    object temp = n.GetElement();
    Node n_next = n.GetNext();
    Node n_prev = n.GetPrev();
    n_next.SetPrev(n_prev);
    n_prev.SetNext(n_next);
    n.SetNext(null);
    n.SetPrev(null);
    n = null;
    size++;
    return temp;
  }
  //Métodos de Lista
  public Node First(){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    return header.GetNext();
  }
  public Node Last(){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    return trailer.GetPrev();
  }
  public Node Before(Node n){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    Node before_n = atRank(rankOf(n)).GetPrev();
    return before_n;
  }
  public Node After(Node n){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    Node after_n = atRank(rankOf(n)).GetNext();
    return after_n;
  }
  public object replaceElement(Node n, object o){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    object temp = n.GetElement();
    n.SetElement(o);
    return temp;
  }
  public void swapElements(Node n, Node q){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    object x = n.GetElement();
    n.SetElement(q.GetElement());
    q.SetElement(x);
  }
  public Node insertBefore(Node n, object o){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    Node new_ = new Node(o);
    Node before_n = n.GetPrev();
    new_.SetNext(n);
    new_.SetPrev(before_n);
    n.SetPrev(new_);
    before_n.SetNext(new_);
    size++;
    return new_;
  }
  public Node insertAfter(Node n, object o){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    Node new_ = new Node(o);
    Node after_n = n.GetNext();
    new_.SetPrev(n);
    new_.SetNext(after_n);
    n.SetNext(new_);
    after_n.SetPrev(new_);
    size++;
    return new_;
  }
  public Node insertFirst(object o){
    Node new_ = new Node(o);
    Node first = header.GetNext();
    new_.SetPrev(header);
    new_.SetNext(first);
    header.SetNext(new_);
    first.SetPrev(new_);
    size++;
    return new_;
  }
  public Node insertLast(object o){
    Node new_ = new Node(o);
    Node last = trailer.GetPrev();
    new_.SetNext(trailer);
    new_.SetPrev(last);
    last.SetNext(new_);
    trailer.SetPrev(new_);
    size++;
    return new_;
  }
  public object Remove(Node n){
    if(isEmpty())
      throw new SequenceVazia("Sequência vazia");
    Node n_next = n.GetNext();
    Node n_prev = n.GetPrev();
    n_next.SetPrev(n_prev);
    n_prev.SetNext(n_next);
    object temp = n.GetElement();
    n.SetNext(null);
    n.SetPrev(null);
    n = null;
    size--;
    return temp;
  }
  
  public void print_header(){
    Node current = header;
    while(current!=null){
      Console.Write(current.GetElement()+"<->");
      current = current.GetNext();
    }
  }
  public void print_trailer(){
   Node current = trailer;
   while(current!=null){
     Console.Write(current.GetElement()+"<->");
     current = current.GetPrev();
   }
  } 
  public Boolean isEmpty(){
    return Size()==0;
  }
  public int Size(){
    return size;
  }
  
}


//CLASSE DA INTERFACE 
interface ISequence{
  //Métdos genéricos
  int Size();
  Boolean isEmpty();
  //Métodos de Vetor
  Node elementAtRank();
  object replaceAtRank();
  Node insertAtRank(int r, object o);
  object removeAtRank(int r);
  //Métodos de Lista
  Node First();
  Node Last();
  Node Before(Node n);
  Node After(Node n);
  object replaceElement();
  void swapElements(Node n, Node q);
  Node insertBefore(Node n, object o);
  Node insertAfter(Node n, object o);
  Node insertFirst(object o);
  Node insertLast(object o);
  object Remove(Node n);
  //Métodos ponte
  Node AtRank(int r);
  int RankOf(Node n);
  
}

//CLASSE DO NÓ
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

//CLASSES DE EXCEÇÕES 
public class SequenceVazia : Exception { 
  public SequenceVazia(String err){ }
}
  
public class IndiceForadeFaixa : Exception { 
  public IndiceForadeFaixa(String err){ }
}