import java.util.Scanner;

public class Loop {
    public static void main(String[] args) {
        Scanner leia = new Scanner(System.in);
        double mediaAvaliacao = 0;
        double nota = 0;

        for (int i = 0; i < 3; i++) {
            System.out.print("Qual avaliação do filme: ");
            nota = leia.nextDouble();
            mediaAvaliacao += nota;
        }

        System.out.println("Média de avaliações " + mediaAvaliacao/3);
    }
}
