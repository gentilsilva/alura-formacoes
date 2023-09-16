import java.util.Scanner;

public class OutroLoop {
    public static void main(String[] args) {
        Scanner leia = new Scanner(System.in);
        double mediaAvaliacao = 0;
        double nota = 0;
        int totalDeNotas = 0;

        while (nota != -1) {
            System.out.print("Qual avaliação do filme (OU -1 PARA ENCERRAR): ");
            nota = leia.nextDouble();
            if(nota != -1) {
                mediaAvaliacao += nota;
                totalDeNotas++;
            }
        }

        System.out.println("Média de avaliações: " + mediaAvaliacao/totalDeNotas);
    }
}
