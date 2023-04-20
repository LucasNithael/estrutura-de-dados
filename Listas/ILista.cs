using System;

interface IList{
  //Verifica se o object é primeiro  *
  Boolean isFirst(object n);
  //Verifica se o object é último *
  Boolean isLast(object n);
  //Retorna o primeiro *
  object First();
  //Retorna o último *
  object Last();
  //Retorna o depois do obejct *
  object Before(object p);
  //Retorna o antes do object *
  object After(object p);
  //Substitui o object n pelo object o *
  object replaceElement(object n, object o);
  //Troca o object n com object o *
  void swapElements(object n, object o);
  //Insere o depois do n 
  void insertBefore(object n, object o);
  //Insere o antes do n
  void insertAfter(object n, object o);
  //Insere no inicio *
  void insertFirst(object o);
  //Insere no fim *
  void insertLast(object o);
  //Remove n 
  object Remove(object n);
  //retorna o tamanho
  int Size();
  //Retorna se há elementos ou nãobject
  Boolean isEmpty();
}
