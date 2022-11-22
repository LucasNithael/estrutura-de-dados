using System;

class Program{
  public static void Main(){
    int[] vetor = new int[5];
    vetor[0] = 1;
    vetor[1] = 2;
    vetor[2] = 3;
    vetor[3] = 4;
    vetor[4] = 5;
    int index = Busca_Binaria(5, vetor);
    Console.WriteLine(index);
  }
  public static int Busca_Binaria(int valor, int[] vetor){
    int limite_inferior = 0;
    int limite_superior = vetor.Length-1;
     while(true){
       int posicao_atual = (int)(limite_inferior + limite_superior)/2;
       // Achou na primeira
       if(vetor[posicao_atual] == valor)
         return posicao_atual;
       // Se não achou
       else if(limite_inferior > limite_superior)
         return -1;
       // Divide os limites
       else{
         // Limite inferior
         if(vetor[posicao_atual] < valor)
           limite_inferior = posicao_atual + 1;
         // Limite superior
         else
           limite_superior = posicao_atual - 1;
       }
     }
  }
}

