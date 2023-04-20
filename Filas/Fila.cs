using System;


//Classe da Fila 
class Fila{
  private object[] v = new object[0];
  private int capacidade;
  private int tamanho;
  private int inicio;
  private int fim;
  
  public Fila(int capacidade){
    this.capacidade = capacidade;
    this.v = new object[capacidade];
  }
  
  public void Crescer(){
    object[] novo = new object[capacidade*2];
    for(int i = 0; i<capacidade; i++){
      novo[i] = v[inicio];
      inicio = (inicio+1)%capacidade;
    }
    inicio = 0;
    fim = capacidade;
    capacidade = capacidade*2;
    v = novo;
  }
  
  public void Enqueue(object e){
    if(tamanho==capacidade-1)
      Crescer();
    v[fim] = e;
    fim = (fim+1)%capacidade;
    tamanho++;
  }
  
  public object Dequeue(){
    if(tamanho==0)
      throw new FilaVazia("Fila vazia");
    object x = v[inicio];
    inicio = (inicio + 1)%capacidade;
    tamanho--;
    return x;
  }
  
  public object First(){
    return v[inicio];
  }
  
  public int Size(){
    return tamanho;
  }
  
  public Boolean IsEmpty(){
    return tamanho != 0;
  }
  
}

