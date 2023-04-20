using System;
using System.Collections;
using Exception;


namespace MinhaPilha{
  class Pilha : IPilha{
    private ArrayList l = new ArrayList();
    
    public object Top(){
      if(Size() == 0)
        throw new PilhaVazia("Pilha vazia");
      object x = l[l.Count-1]; 
      return x;
    }
    public void Push(object e){
      l.Add(e);
    }
    public object Pop(){
      if(Size() == 0)
        throw new PilhaVazia("Pilha vazia");
      object x = Top();
      l.Remove(x);
      return x;
    }
    public int Size(){
      return l.Count;
    }
    
  }
}