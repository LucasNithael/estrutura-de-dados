using System;

class Program{
  public static void Main(){
    int[] v = new int[6];
    v[0] = -2;
    v[1] = 11;
    v[2] = -4;
    v[3] = 13;
    v[4] = -5;
    v[5] = -2;
    //{−2, 11,−4, 13,−5, 2},
    int x = Seq(v);
    Console.WriteLine(x);
  }
  public static int Seq(int[] v){
    int soma1 = 0;
    int soma2 = 0;
    int cont = 0;
    for(int i=0; i<v.Length; i++){
      soma2 = 0;
      for(int j=i; j<v.Length; j++){
        soma2 += v[j];
        if(soma2>soma1){
          soma1=soma2;
          cont++;
        }
      }
      
      //Console.WriteLine("Soma1:"+soma1);
      } 
    Console.WriteLine("\nSoma1:"+soma1);
    return cont;
  }
}

