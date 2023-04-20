using System;

interface IPilha{
  
  object Top();
  
  void Push(object e);
  
  object Pop();
  
  int Size();
  
}