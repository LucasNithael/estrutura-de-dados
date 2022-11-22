using System;

class MainClass{
  public static void Main(){
    Vector v = new Vector(2);
    v.Insere_Fim(10);
    v.Insere_Fim(11);
    v.replaceAtRank(2,4);
    v.insertAtRank(3,-12);
    v.replaceAtRank(4,5);
    v.Ver_Vetor();
    v.Remove();
    Console.WriteLine("\nSize: "+v.Size());
    v.Ver_Vetor();
    
  }
}


interface IVector{
  //Adiciona no fim do vetor
  void Insere_Fim(object o);
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
  //Remove do inicio do vetor
  object Remove_Fim();
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
    foreach(object i in vetor)
      Console.Write(i+" ");
    Console.Write("]");
  }
  
  public void Capacity_Up(){
    object[] vetor_aux = new object[capacity*2];
    for(int i=0; i<capacity; i++)
      vetor_aux[i] = vetor[i];
    vetor = vetor_aux;
    capacity = capacity*2; 
  }
  
  public void Insere_Fim(object o){
    if(size==capacity)
      Capacity_Up();
    vetor[size] = o;
    size++;
  }
  
  public object elementAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    return vetor[r];
  }
  
  public object replaceAtRank(int r, object o){
    object temp;
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    if(r==size){
      if(size==capacity)
        Capacity_Up();
      temp = vetor[r];
      vetor[r] = o;
      size++;
    }
    else{
      temp = vetor[r];
      vetor[r] = o;
    }
    return temp;
  }
  public void insertAtRank(int r, object o){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    if(r==size){
      if(size==capacity)
        Capacity_Up();
      vetor[r] = o;
      size++;
    }
    else
      vetor[r] = o;
  }
  public object removeAtRank(int r){
    if(size==0)
      throw new VectorVazia("Vetor Vazio");
    if(r>=size)
      throw new IndiceForadeFaixa("índice fora de faixa");
    object temp = vetor[r];
    for(int i=r; i<size; i++)
      vetor[i]=vetor[i+1];
    size--;
    return temp;
  }
  public int Size(){
    return size;
  }
  public Boolean isEmpty(){
    return size!=0;
  }

  public Object Remove_Fim(){
    if(size==0)
        throw new VectorVazia("Vetor Vazio");
    object temp = vetor[size];
    size--;
    return temp;
  }
  
  public class VectorVazia : Exception { 
    public VectorVazia(String err){ }
  }
  
  public class IndiceForadeFaixa : Exception { 
    public IndiceForadeFaixa(String err){ }
  }
}
