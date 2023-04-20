using System;


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
    if(index==0)
      return null;
    return list[index-1];
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
    if(index==size-1)
      return null;
    return list[index+1];
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
  public object replaceElement(object n, object o){
    if(isEmpty())
      throw new ListVazia("Lista Vazia");
    int index = -1;
    for(int i=0; i<size; i++)
      if(list[i].Equals(n)){
        index = i;
        break;
      }
    object temp = list[index];
    list[index] = o;
    return temp;
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
