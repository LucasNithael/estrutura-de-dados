using System;

class Program{
  public static void Main(){
    int[] v = new int[6];
    v[0] = 4;
    v[1] = 11;
    v[2] = -4;
    v[3] = 133;
    v[4] = -500;
    v[5] = 2;
    //{−2, 11,−4, 13,−5, 2},
    int x = Seq(v);
    Console.WriteLine("\nNº elementos:\n"+x);
  }
  public static int Seq(int[] v){
    int soma1 = 0;
    int soma2 = 0;
    int cont = 0;
    int mcont = 0;
    int index_j=0;
    for(int i=0; i<v.Length; i++){
      soma2 = 0;
      cont=0;
      for(int j=i; j<v.Length; j++){
        soma2 += v[j];
        cont++;
        if(soma2>soma1){
          soma1=soma2;
          index_j = j;
          mcont = cont;
        }
      }
      
    } 
    Console.WriteLine("Soma:" + soma1);
    return mcont;
  }
}

