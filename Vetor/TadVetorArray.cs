using System;

class MainClass{
  public static void Main(){
    Vector v = new Vector(2);
    v.insertAtRank(0, 1);
    v.insertAtRank(1, 2);
    v.insertAtRank(2, 3);
    v.insertAtRank(3, "P");
    v.insertAtRank(5, "A");
    v.Ver_Vetor();
    v.removeAtRank(0);
    Console.WriteLine();
    v.Ver_Vetor();
    
  }
}


interface IVector{
  //Retorna sem remover o elemento na posição r
  object elementAtRank(int r);
  //Substitui o elemento na posição r por o e retorna o antigo elemento
  object replaceAtRank(int r, object o);
  //Substitui o elemento na posição r por o
  void insertAtRank(int r, object o);
  //Remove e retorna o elemento na posição r
  object removeAtRank(int r);
  //Retorna quantidade de elementos
  int Size();
  //Retorna se há elementos ou nãobject
  Boolean isEmpty();
}


class Vector: IVector{
  private object[] vetor = new object[0];
  private int capacity, size;

  public Vector(int capacity){
    this.capacity = capacity;
    this.vetor = new object[capacity];
  }

  // Método para verificar o vetor
  public void Ver_Vetor(){
    Console.Write("[");
    for(int i=0; i<size; i++)
      Console.Write(" "+vetor[i]);
    Console.Write("]");
  }
  
  public void Capacity_Up(){
    object[] vetor_aux = new object[capacity*2];
    for(int i=0; i<capacity; i++)
      vetor_aux[i] = vetor[i];
    vetor = vetor_aux;
    capacity = capacity*2; 
  }
  
  public object elementAtRank(int r){
    if(isEmpty())
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    return vetor[r];
  }
  
  public object replaceAtRank(int r, object o){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    object temp = vetor[r];
    vetor[r] = o;
    return temp;
  }
  public void insertAtRank(int r, object o){
    if(r>size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    if(size==capacity)
        Capacity_Up();
    if(r==size)
      vetor[r] = o;
    else{
      for(int i=size; i>r; i--)
        vetor[i] = vetor[i-1];
      vetor[r] = o;
    }
    size++;
  }
  
  public object removeAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    object temp = vetor[r];
    for(int i=r; i<size-1; i++)
      vetor[i]=vetor[i+1];
    size--;
    return temp;
  }
  public int Size(){
    return size;
  }
  public Boolean isEmpty(){
    return size==0;
  }

}

public class VectorVazia : Exception { 
  public VectorVazia(String err){ }
}
  
public class IndiceForadeFaixa : Exception { 
  public IndiceForadeFaixa(String err){ }
}