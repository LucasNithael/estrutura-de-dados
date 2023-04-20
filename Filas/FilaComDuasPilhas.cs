using System;
using System.Collections;

class FilaComDuasPilhas{
  public Stack p1 = new Stack();
  public Stack p2 = new Stack();
  public void Enqueue(object e){
    if(p1.Count==0)
      Inverter2();
    p1.Push(e);
  }
  public object Dequeue(){
    if(p1.Count!=0)
      Inverter1();
    return p2.Pop();
  }
  public object First(){
    if(p1.Count!=0)
      return p1.Peek();
    return p2.Peek();
  }
  public int Size(){
    return p2.Count+p1.Count;
  }
  public Boolean isEmpty(){
    return p1.Count!=p2.Count;
  }
  private void Inverter1(){
    for(int i=0; i<Size(); i++)
       p2.Push(p1.Pop());

    for(int i=0; i<Size(); i++)
      p1.Push(p2.Pop());
  }
}