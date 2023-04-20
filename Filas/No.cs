using System;

//Classe do No
class No{
  private object element;
  private No next;
  public No(object e){
    SetElement(e);
  }
  public void SetElement(object e){
    this.element = e;
  }
  public void SetNext(No n){
    this.next = n;
  }
  public object GetElement(){
    return element;
  }
  public No GetNext(){
    return next;
  }
}